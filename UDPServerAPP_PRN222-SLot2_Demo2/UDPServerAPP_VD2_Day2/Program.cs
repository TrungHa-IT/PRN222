using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPServerAPP_VD2_Day2
{
     class Program
    {
        const int listenPort = 11000;
        const string host = "127.0.0.1";

        private static void StartLestener()
        {
            string message  ;
            UdpClient listener = new UdpClient(listenPort);
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndpoint = new IPEndPoint(address, listenPort);

            Console.Title = "UDP server";

            Console.WriteLine(new string('*', 30));

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref remoteEndpoint);
                    message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine("Received broadcast from {0} :\n {1}\n", remoteEndpoint, message);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                listener.Close();
            }
        }
        static void Main(string[] args)
        {
            Thread thread= new Thread(new ThreadStart(StartLestener));
            thread.Start();
        }
    }
}
