
namespace VisibiliPi
{
    using BBP;
    using System;

    public static class DigitConversion
    {
        public static BBPResult GetDigit(int digit)
        {
            return new PiDigit().Calc(digit);
        }

        public static byte DigitToHexDigit(int digit)
        {
            // 1/16th of the total bandwidth
            var bbpResult = GetDigit(
                digit: digit);
            return Convert.ToByte(
                value: bbpResult.HexDigits.Substring(0, 1),
                fromBase: 16);
        }

        // the n'th digit of Pi (in hex), which is technically a nibble, is now a 0-15 value
        //0->243f6a8885
        //1->43F6A8885A
        public static double DigitToWavelength(int digit)
            => WavelengthToRGB.VISIBLE_SPECTRUM_LOW_NM + (DigitToHexDigit(digit) * WavelengthToRGB.NM_PER_COUNT);

        public static double HexDigitToWavelength(byte hexDigit) =>
            WavelengthToRGB.VISIBLE_SPECTRUM_LOW_NM + (hexDigit * WavelengthToRGB.NM_PER_COUNT);

        public static RGBValue DigitToRGB(int digit) =>
            WavelengthToRGB.WaveLengthToRGB(
                Wavelength: DigitToWavelength(
                    digit: digit));
    }
}
