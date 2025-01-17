using System.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Net;
namespace ClientApp_day2_VD1
{
     class Program
    {
        static void ConnectServer(string server, int port)
        {
            string message, responseData;
            int bytes;

            try
            {
                TcpClient client = new TcpClient(server, port);
                Console.Title = "Client Application";

                NetworkStream stream = null;

                while (true)
                {
                    Console.Write("Enter the message: ");
                    message = Console.ReadLine();
                    if(message == string.Empty)
                    {
                        break;
                    }

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                    stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);
                    data = new byte[256];
                    bytes = stream.Read(data, 0, data.Length);

                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                client.Close();
            }catch(Exception e)
            {
                Console.WriteLine("Eception: {0}", e.Message);
            }
        }
        static void Main(string[] args)
        {
            string server = "127.0.0.1";
            int port = 13000;

            ConnectServer(server, port);

        }
    }
}
