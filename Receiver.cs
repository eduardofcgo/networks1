using System;

namespace server
{
    public class Receiver

    {
        private readonly Sender sender;

        public Receiver(Sender sender)
        {
            this.sender = sender;
        }

        public void Receive(Packet packet)
        {
            Console.Write(packet.ConvertASCII());

            //Console.WriteLine(packet.convertBinaryString());
        }
    }
}
