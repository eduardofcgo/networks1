using System;
using System.Linq;

namespace server
{
    public class NoisyMedium
    {
        private readonly int nerrors;
        private static readonly Random random = new Random();

        public NoisyMedium(int nerrors)
        {
            this.nerrors = nerrors;
        }

        public Packet Transmit(Packet packet)
        {
            var erroredIndexes = Enumerable.Range(0, Packet.Length - 1)
                .OrderBy(i => random.NextDouble())
                .Take(nerrors);

            var transmitted = new Packet((byte) packet.Byte);

            foreach (int i in erroredIndexes)
                transmitted[i] = !transmitted[i];

            return transmitted;
        }
    }
}
