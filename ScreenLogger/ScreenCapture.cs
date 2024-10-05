using ScreenLogger.Extension;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ScreenLogger
{
    public class ScreenCapture
    {
        [DllImport("User32.dll")]
        public static extern bool GetCursorInfo(ref CursorInfo pci);

        public static Image GetScreen()
        {
            var rectangle = SystemInformation.VirtualScreen;
            return GetScreenBitmap(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, PixelFormat.Format16bppRgb565);
        }

        public static Bitmap GetScreenBitmap(int x, int y, int width, int height, PixelFormat pixelFormat)
        {
            var bmp = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.CopyFromScreen(x, y, 0, 0, bmp.Size);
                var cursorInfo = new CursorInfo();
                cursorInfo.Initialize();
                GetCursorInfo(ref cursorInfo);
                if (cursorInfo.hCursor != IntPtr.Zero)
                {
                    var cursor = new Cursor(cursorInfo.hCursor);
                    var cursor_position = new System.Drawing.Point(Cursor.Position.X - x, Cursor.Position.Y - y);
                    cursor.Draw(graphics, new Rectangle(cursor_position, new Size(cursor.Size.Width, cursor.Size.Height)));
                }
            }
            Thread.Sleep(10);
            return bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), pixelFormat);
        }

        public static void SaveImage(Image image, string outputFilePath, ImageFormat imageFormat)
        {
            var bytes = image.ToByteArray(imageFormat);
            File.WriteAllBytes(outputFilePath, bytes);
        }
    }
}
