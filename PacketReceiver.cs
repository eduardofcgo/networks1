using System;

namespace server
{
    public class PacketReceiver

    {
        private readonly Sender sender;

        public PacketReceiver(Sender sender)
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
