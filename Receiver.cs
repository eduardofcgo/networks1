using System;

namespace server
{
    public class Receiver

    {
        private readonly Writer writer;

        public Receiver(Writer writer)
        {
            this.writer = writer;
        }

        public void Receive(Packet packet)
        {
            Console.Write(packet.ConvertASCII());
        }
    }
}
