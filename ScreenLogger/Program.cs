using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ScreenLogger
{
    internal static class Program
    {
        static void Main()
        {
            while (true)
            {
                var screen = ScreenCapture.GetScreen();
                var outputFilePath = Path.Combine(Application.StartupPath, "capture.png");
                ScreenCapture.SaveImage(screen, outputFilePath, ImageFormat.Png);
                Thread.Sleep(1000);
            }
        }
    }
}
