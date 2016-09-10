using System;
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

namespace UpdateServer
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            //更新界面信息
            String configFileName = "config.xml";
            if (File.Exists(configFileName))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(configFileName);
                XmlElement root = xmldoc.DocumentElement;
                IPTextBox.Text = root.SelectSingleNode("ip/pre").InnerText;
                BeginTextBox.Text = root.SelectSingleNode("ip/begin").InnerText;
                EndTextBox.Text = root.SelectSingleNode("ip/end").InnerText;
                PortTextbox.Text = root.SelectSingleNode("ip/fileport").InnerText;
                PortTextbox2.Text = root.SelectSingleNode("ip/cmdport").InnerText;
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
            UdpClient receiveUdpClient = new UdpClient(22229);
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
            String msg = "";
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
                        int num = Convert.ToInt32(NumLable.Text)+1;
                        NumLable.Text = num.ToString();
                    });
                    Thread.Sleep(500);
                }
            }
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog1.FileName;
            }  
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            //获取ip组
            String ipPre = IPTextBox.Text;
            int ipBegin = Convert.ToInt32(BeginTextBox.Text);
            int ipEnd = Convert.ToInt32(EndTextBox.Text);
            String filePort = PortTextbox.Text;
            List<String> ips = new List<String>();
            for (int i = ipBegin; i <= ipEnd; i++)
            {
                ips.Add(ipPre + i);
            }
            String filePath = fileTextBox.Text;

            //开始发送 
            Updatebutton.Enabled = false;
            Updatebutton.Text = "升级中";
            NumLable.Text = "0";
            Task.Factory.StartNew(delegate
            {
                List<Task> threadPool = new List<Task>();
                foreach (String ip in ips)
                {
                    Task task = new Task(() => sendFile(filePath, ip, filePort));
                    task.Start();
                    threadPool.Add(task);
                }
                Task.WaitAll(threadPool.ToArray());
                invokeFunc(delegate
                {
                    ResultTextBox.AppendText("执行完毕\n");
                    Updatebutton.Enabled = true;
                    Updatebutton.Text = "发送";
                });
            });
        }

        private void sendFile(String filePath, String ip, String port)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ip, Convert.ToInt32(port));
                }
                catch (Exception e)
                {
                    invokeFunc(delegate
                    {
                        ResultTextBox.AppendText(ip + " 连不上\n");
                    });
                }
                try
                {                  
                    NetworkStream ns = client.GetStream();
                    using (FileStream fs = File.OpenRead(filePath))
                    {                      
                        byte[] b = new byte[1024];
                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            ns.Write(b,0,b.Length);
                        }
                    }
                    String command = CommandTextBox.Text;
                    String commandPort = PortTextbox2.Text;
                    if (!String.IsNullOrEmpty(command))
                    {
                        UdpClient sendUdpclient = new UdpClient(ip, Convert.ToInt32(commandPort));
                        byte[] sendByte = Encoding.UTF8.GetBytes(command);
                        sendUdpclient.Send(sendByte, sendByte.Length);
                    }
                    invokeFunc(delegate
                    {
                        ResultTextBox.AppendText(ip + " 传输成功\n");
                    });
                }
                catch (Exception e)
                {
                    invokeFunc(delegate
                    {
                        ResultTextBox.AppendText(ip + " 升级失败\n");
                    });
                    return;
                } 
            }

        }
        //将任务发送回主线程执行
        private void invokeFunc(Action action)
        {
            Invoke(action);
        }

        private void fileTextBox_TextChanged(object sender, EventArgs e)
        {
            String configFileName = "config.xml";
            if (File.Exists(configFileName))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(configFileName);
                XmlElement root = xmldoc.DocumentElement;
                String fileName = fileTextBox.Text.Substring(fileTextBox.Text.LastIndexOf("\\")+1);
                CommandTextBox.Text = root.SelectSingleNode("command/data").InnerText.Replace("???", fileName);
            }
            
        }

    }
}
