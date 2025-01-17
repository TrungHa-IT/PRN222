using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPClientApp_Day2_VD2
{
     class Program
    {

        static void ConnectServer(string host, int port)
        {
            UdpClient client = new UdpClient();
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, port);

            string message;
            int count = 0;
            bool done = false;

            try
            {
                Console.WriteLine(new string('*', 40));

                client.Connect(remoteEndPoint);

                while (!done)
                {
                    message = $"Message {++count:D2}";

                    byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                    client.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine($"Sent: {message}");
                    Thread.Sleep(2000);
                    if (count == 10)
                    {
                        done = true;
                        Console.WriteLine("Done.");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }finally
            {
                client.Close();
            }
        }
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int port = 11000;
            ConnectServer(host, port);
            Console.Read();
        }
    }
}
