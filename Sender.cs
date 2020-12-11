using System.IO;

namespace server
{
    public class Sender
    {
        private readonly BinaryWriter writer;

        public Sender(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public void Send(Packet packet)
        {
            this.writer.Write(packet.Byte);
        }
    }
}
