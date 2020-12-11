using System;
namespace server
{
    public class Packet
    {
        public int Byte;
        public static int Length = 8;

        public Packet(byte Byte)
        {
            this.Byte = Byte;
        }

        public Boolean this[int index] 
        {
            get => (Byte & (1 << Length - 1 - index)) != 0;
            set
            {
                byte mask = (byte)(1 << Length - 1 - index);

                if (value)
                {
                    Byte |= mask;
                } else
                {
                    Byte &= ~mask;
                }
            }
        }

        public char ConvertASCII()
        {
            int ignoredAccent = Byte & 127;
            return (char) ignoredAccent;
        }

        public string ConvertBinaryString()
        {
            return Convert.ToString(this.Byte, 2).PadLeft(Length, '0');
        }
    }
}
