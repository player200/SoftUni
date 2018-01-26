namespace _03.SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            const int port = 1337;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            TcpListener tcpListener = new TcpListener(ipAddress, port);

            tcpListener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients on 127.0.0.1:{port}");

            Task.Run(() => Connect(tcpListener))
                .GetAwaiter()
                .GetResult();
        }

        public static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                TcpClient client = await listener.AcceptTcpClientAsync();

                byte[] buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                string cliendMessage = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(cliendMessage.Trim('\0'));

                //ако не тръгва с този стринг сложи Content-Type: text/plain{ Environment.NewLine}{ Environment.NewLine}  на втория ред от стринга
                //по неже при мен тръгва и само с тези неща
                string responceMessage = $@"HTTP / 1.1 200 OK{Environment.NewLine}
                                            Hello from server!";
                var dataMessage = Encoding.UTF8.GetBytes(responceMessage);
                await client.GetStream().WriteAsync(dataMessage, 0, dataMessage.Length);

                Console.WriteLine("Closing connection");
                client.Dispose();
            }
        }
    }
}