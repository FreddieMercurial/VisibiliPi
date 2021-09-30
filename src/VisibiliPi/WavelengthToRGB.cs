namespace VisibiliPi
{
    using System;

    /// <summary>
    /// Improved from https://stackoverflow.com/a/14917481
    /// </summary>
    public class WavelengthToRGB
    {
        public const int VISIBLE_SPECTRUM_LOW_NM = 380;
        public const int VISIBLE_SPECTRUM_HIGH_NM = 780;
        public const byte NM_PER_COUNT = (WavelengthToRGB.VISIBLE_SPECTRUM_HIGH_NM - WavelengthToRGB.VISIBLE_SPECTRUM_LOW_NM) / 16;

        private const double Gamma = 0.80;
        private const double IntensityMax = 255;

        /// <summary>
        /// Improved from Earl F. Glynn's web page:
        /// <a href="http://www.efg2.com/Lab/ScienceAndEngineering/Spectra.htm">Spectra Lab Report</a>
        /// </summary>
        public static RGBValue WaveLengthToRGB(double Wavelength)
        {
            double factor;
            double Red, Green, Blue;

            if ((Wavelength >= VISIBLE_SPECTRUM_LOW_NM) && (Wavelength < 440))
            {
                Red = -(Wavelength - 440) / (440 - VISIBLE_SPECTRUM_LOW_NM);
                Green = 0.0;
                Blue = 1.0;
            }
            else if ((Wavelength >= 440) && (Wavelength < 490))
            {
                Red = 0.0;
                Green = (Wavelength - 440) / (490 - 440);
                Blue = 1.0;
            }
            else if ((Wavelength >= 490) && (Wavelength < 510))
            {
                Red = 0.0;
                Green = 1.0;
                Blue = -(Wavelength - 510) / (510 - 490);
            }
            else if ((Wavelength >= 510) && (Wavelength < 580))
            {
                Red = (Wavelength - 510) / (580 - 510);
                Green = 1.0;
                Blue = 0.0;
            }
            else if ((Wavelength >= 580) && (Wavelength < 645))
            {
                Red = 1.0;
                Green = -(Wavelength - 645) / (645 - 580);
                Blue = 0.0;
            }
            else if ((Wavelength >= 645) && (Wavelength <= VISIBLE_SPECTRUM_HIGH_NM))
            {
                Red = 1.0;
                Green = 0.0;
                Blue = 0.0;
            }
            else
            {
                Red = 0.0;
                Green = 0.0;
                Blue = 0.0;
            }

            // Let the intensity fall off near the vision limits

            if ((Wavelength >= VISIBLE_SPECTRUM_LOW_NM) && (Wavelength < 420))
            {
                factor = 0.3 + 0.7 * (Wavelength - VISIBLE_SPECTRUM_LOW_NM) / (420 - VISIBLE_SPECTRUM_LOW_NM);
            }
            else if ((Wavelength >= 420) && (Wavelength < 701))
            {
                factor = 1.0;
            }
            else if ((Wavelength >= 701) && (Wavelength <= VISIBLE_SPECTRUM_HIGH_NM))
            {
                factor = 0.3 + 0.7 * (VISIBLE_SPECTRUM_HIGH_NM - Wavelength) / (VISIBLE_SPECTRUM_HIGH_NM - 700);
            }
            else
            {
                factor = 0.0;
            }

            return new RGBValue(
                // Don't want 0^x = 1 for x <> 0
                red: Red == 0.0 ? 0 : Math.Round(IntensityMax * Math.Pow(Red * factor, Gamma)),
                green: Green == 0.0 ? 0 : Math.Round(IntensityMax * Math.Pow(Green * factor, Gamma)),
                blue: Blue == 0.0 ? 0 : Math.Round(IntensityMax * Math.Pow(Blue * factor, Gamma))
            );
        }
    }
}
