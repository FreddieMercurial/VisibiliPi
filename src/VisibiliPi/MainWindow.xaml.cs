using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace VisibiliPi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int CurrentDigit = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = true;
            this.WindowState = System.Windows.WindowState.Normal;
            this.Visibility = System.Windows.Visibility.Visible;
            
            this.btn1.MouseUp += Btn1_MouseUp;
        }

        private void Btn1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var piHexDigit = DigitConversion.DigitToPiHexDigit(this.CurrentDigit);
            var wavelength = DigitConversion.PiHexDigitToWavelength(
                    piHexDigit: piHexDigit);
            var rgb = WavelengthToRGB.WaveLengthToRGB(Wavelength: wavelength);
            this.Background = new SolidColorBrush(Color.FromRgb(
                    r: (byte)rgb.Red,
                    g: (byte)rgb.Green,
                    b: (byte)rgb.Blue));
            lblDigit.Content = string.Format(
                "n: {0}, pi hex: {1:X}, lambda: {2}, r: {3}, g: {4}, b: {5}",
                this.CurrentDigit++,
                piHexDigit,
                wavelength,
                rgb.Red,
                rgb.Green,
                rgb.Blue);
        }
    }
}
