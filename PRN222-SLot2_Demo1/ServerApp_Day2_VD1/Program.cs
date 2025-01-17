using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace ServerApp_Day2_VD1
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";

            int port = 13000; 

            ExcuteServer(host, port);
        }

        static void ProcessMessage(object pram)
        {
            string data;
            int count;

            try
            {
                TcpClient client = pram as TcpClient;

                IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                Byte[] bytes = new Byte[256];

                NetworkStream stream = client.GetStream();
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data} at {DateTime.Now:t} IP: {clientEndPoint.Address} , Port: {clientEndPoint.Port}");
                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");


                }

                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
                Console.WriteLine("Watiting message.....");

            }
        }

        static void ExcuteServer(string host, int port)
        {
            int Count = 0;

            TcpListener server = null;

            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);

                server.Start();
                Console.WriteLine(new string('*', 30));
                Console.WriteLine("Waitting for a connection..........");
                Console.WriteLine($"Server started. Listening on port {port}...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine($"Number of client connected: {++Count}");

                    Console.WriteLine(new string('*', 30));

                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }

            }catch(Exception e)
            {
                Console.WriteLine("Exception: ",e.Message);
            }
            finally
            {
                server.Stop();

                Console.WriteLine("Server stopped. Press any key to exit....");
            }
            Console.Read();
        }
    }
}

