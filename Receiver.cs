namespace server
{
    public class Receiver

    {
        private readonly Writer writer;

        public Receiver(Writer sender)
        {
            this.writer = sender;
        }

        public void Receive(Packet packet)
        {
            //Console.Write(packet.ConvertASCII());
        }
    }
}
