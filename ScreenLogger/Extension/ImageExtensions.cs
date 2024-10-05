using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenLogger.Extension
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            if (image == null)
            {
                return null;
            }
            var memoryStream = new MemoryStream();
            image.Save(memoryStream, format);
            return memoryStream.ToArray();
        }
    }
}
