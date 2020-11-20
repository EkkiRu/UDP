using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var udpClient = new UdpClient(8000);
            IPEndPoint endpoint = null;

            //var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            try
            {
                //udpClient.Connect(IPAddress.Parse("127.0.0.1"), 8000);
                while (true)
                {
                    var data = await udpClient.ReceiveAsync();
                    if (data.Buffer.Length > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(data.Buffer));
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}