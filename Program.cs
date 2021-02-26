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

                Console.WriteLine("Server started at port " + port);

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    BinaryWriter binaryWriter = new BinaryWriter(stream);
                    Writer writer = new Writer(binaryWriter);
                    var receiver = new Receiver(writer);

                    int firstByte = stream.ReadByte();

                    if (firstByte != -1)
                    {
                        Packet packet = new Packet((byte) firstByte);

                        var noisyMedium = new NoisyMedium(nerrors);
                        var maybeErrored = noisyMedium.Transmit(packet);

                        receiver.Receive(maybeErrored);
                    }

                    binaryWriter.Close();
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
