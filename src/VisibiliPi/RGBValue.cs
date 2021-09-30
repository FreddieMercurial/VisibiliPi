namespace VisibiliPi
{
    using System;

    public record RGBValue
    {
        public readonly double Red;
        public readonly double Green;
        public readonly double Blue;

        public RGBValue(double red, double green, double blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public RGBValue(double[] rgb)
        {
            if (rgb.Length != 3)
            {
                throw new ArgumentException(nameof(rgb));
            }
            this.Red = rgb[0];
            this.Green = rgb[1];
            this.Blue = rgb[2];
        }

        public double[] ToRGBDoubleArray() => new double[]
             {
                Red,
                Green,
                Blue
             };

        public ulong[] ToRGBUlongArray() => new ulong[]
            {
                (ulong)Red,
                (ulong)Green,
                (ulong)Blue
            };

        public uint[] ToRGBUintArray() => new uint[]
            {
                (uint)Red,
                (uint)Green,
                (uint)Blue
            };

        public int[] ToRGBIntArray() => new int[]
            {
                (int)Red,
                (int)Green,
                (int)Blue
            };

        public byte[] ToRGBByteArray() => new byte[]
            {
                (byte)Red,
                (byte)Green,
                (byte)Blue
            };
    }
}
