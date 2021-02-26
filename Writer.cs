using System.IO;

namespace server
{
    public class Writer
    {
        private readonly BinaryWriter writer;

        public Writer(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public void Write(Packet packet)
        {
            this.writer.Write(packet.Byte);
        }

        public void WriteText(Packet packet)
        {
            this.writer.Write(packet.ConvertASCII());
        }
    }
}
