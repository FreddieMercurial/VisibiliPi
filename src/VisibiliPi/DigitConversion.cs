
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

        public static byte DigitToPiHexDigit(int digit)
        {
            // 1/16th of the total bandwidth
            var bbpResult = GetDigit(
                digit: digit);
            return Convert.ToByte(
                value: bbpResult.HexDigits.Substring(0, 1),
                fromBase: 16);
        }

        public static double DigitToWavelength(int digit)
            => PiHexDigitToWavelength(DigitToPiHexDigit(digit));

        public static double PiHexDigitToWavelength(byte piHexDigit) =>
            WavelengthToRGB.VISIBLE_SPECTRUM_LOW_NM + (piHexDigit * WavelengthToRGB.NM_PER_COUNT);

        public static RGBValue PiHexDigitToRGB(byte piHexDigit) =>
            WavelengthToRGB.WaveLengthToRGB(
                Wavelength: PiHexDigitToWavelength(piHexDigit: piHexDigit));

        public static RGBValue DigitToRGB(int digit) =>
            WavelengthToRGB.WaveLengthToRGB(
                Wavelength: DigitToWavelength(
                    digit: digit));
    }
}
