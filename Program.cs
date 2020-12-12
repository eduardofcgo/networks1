using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Program
    {
        private static readonly int nerrors = 0;
        private static readonly Int32 port = 2222;
        private static readonly IPAddress addr = IPAddress.Parse("0.0.0.0");

        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(addr, port);

                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    int firstByte = stream.ReadByte();

                    if (firstByte != -1)
                    {
                        Packet packet = new Packet((byte) firstByte);

                        var noisyMedium = new NoisyMedium(nerrors);
                        var maybeErrored = noisyMedium.Transmit(packet);

                        BinaryWriter writer = new BinaryWriter(stream);
                        Sender sender = new Sender(writer);
                        var receiver = new Receiver(sender);

                        receiver.Receive(maybeErrored);
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
