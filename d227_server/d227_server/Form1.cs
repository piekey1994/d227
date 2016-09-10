using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace d227_server
{
    public partial class CommandLauncher : Form
    {
        public CommandLauncher()
        {
            InitializeComponent();
            //更新界面信息
            String configFileName = "config.xml";
            if (File.Exists(configFileName))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(configFileName);
                XmlElement root = xmldoc.DocumentElement;
                ipBegin1TextBox.Text = root.SelectSingleNode("ip/pre").InnerText;
                ipBegin2TextBox.Text = root.SelectSingleNode("ip/begin").InnerText;
                ipEnd2TextBox.Text = root.SelectSingleNode("ip/end").InnerText;
                PortTextBox.Text = root.SelectSingleNode("ip/port").InnerText;
                commandTextBox.Text = root.SelectSingleNode("command/data").InnerText;
            }
            //将消息更新到窗口
            ConcurrentQueue<String> messages = new ConcurrentQueue<String>();
            Thread appendThread = new Thread(() => appendMessage(messages));
            appendThread.IsBackground = true;
            appendThread.Start();
            //开始等待接收信息
            Thread receiveThread = new Thread(() => receiveMessage(messages));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void receiveMessage(ConcurrentQueue<String> messages)
        {
            UdpClient receiveUdpClient = new UdpClient(11228);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                Byte[] receiveBytes = receiveUdpClient.Receive(ref RemoteIpEndPoint);
                String returnData = Encoding.UTF8.GetString(receiveBytes);
                messages.Enqueue(returnData);
            }
        }

        private void appendMessage(ConcurrentQueue<String> messages)
        {
            String msg="";
            while (true)
            {
                if (messages.TryDequeue(out msg))
                {
                    invokeFunc(delegate
                    {
                        int selectBegin = ResultTextBox.Text.Length;
                        ResultTextBox.AppendText(msg);
                        int selectEnd = ResultTextBox.Text.LastIndexOf(":\t\t\n");
                        ResultTextBox.Select(selectBegin, selectEnd);
                        ResultTextBox.SelectionColor = Color.Red;
                        int num = Convert.ToInt32(NumberLable.Text) + 1;
                        NumberLable.Text = num.ToString();
                    });
                    Thread.Sleep(500);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ipEnd1TextBox.Text = ipBegin1TextBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取ip组
            String ipPre = ipBegin1TextBox.Text;
            int ipBegin = Convert.ToInt32(ipBegin2TextBox.Text);
            int ipEnd = Convert.ToInt32(ipEnd2TextBox.Text);
            String port = PortTextBox.Text;
            List<String> ips = new List<String>();
            for (int i = ipBegin; i <= ipEnd; i++)
            {
                ips.Add(ipPre + i);
            }
            String command = commandTextBox.Text;
            //开始发送 
            button1.Enabled = false;
            button1.Text = "发送中";
            NumberLable.Text = "0";
            Task.Factory.StartNew(delegate {
                List<Task> threadPool = new List<Task>();
                foreach (String ip in ips)
                {
                    Task task = new Task(() => sendCommand(ip, port, command));
                    task.Start();
                    threadPool.Add(task);
                }
                Task.WaitAll(threadPool.ToArray());
                invokeFunc(delegate {
                    progressTextBox.AppendText("执行完毕\n");
                    button1.Enabled = true;
                    button1.Text = "发送";
                });
            });
        }

        private void sendCommand(String ip, String port, String command)
        {
            try
            {
                UdpClient sendUdpclient = new UdpClient(ip, Convert.ToInt32(port));
                byte[] sendByte = Encoding.UTF8.GetBytes(command);
                sendUdpclient.Send(sendByte, sendByte.Length);
            }
            catch (Exception e)
            {
                invokeFunc(delegate
                {
                    progressTextBox.AppendText("ip:" + ip + " 发送失败\n");
                });
            }
        }
        //将任务发送回主线程执行
        private void invokeFunc(Action action)
        {
            Invoke(action);
        }
    }
}
