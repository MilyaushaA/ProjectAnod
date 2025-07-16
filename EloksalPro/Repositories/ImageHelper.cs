using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public class ImageHelper
    {
        public static byte[] ResizeAndCompressImage(string imagePath, int maxWidth, int maxHeight, long quality)
        {
            using (Image originalImage = Image.FromFile(imagePath))
            {
                // Вычисляем новые размеры с учетом максимальных
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;

                if (originalImage.Width > maxWidth || originalImage.Height > maxHeight)
                {
                    if (originalImage.Width > originalImage.Height)
                    {
                        newHeight = (int)(originalImage.Height * ((float)maxWidth / originalImage.Width));
                        newWidth = maxWidth;
                    }
                    else
                    {
                        newWidth = (int)(originalImage.Width * ((float)maxHeight / originalImage.Height));
                        newHeight = maxHeight;
                    }
                }

                // Создаем новое изображение с новыми размерами
                using (var resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight)))
                {
                    // Настраиваем параметры сжатия
                    var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                    using (var memoryStream = new MemoryStream())
                    {
                        // Сохраняем изображение в MemoryStream с заданным уровнем качества
                        resizedImage.Save(memoryStream, jpegEncoder, encoderParameters);
                        return memoryStream.ToArray();
                    }
                }
            }
        }

      
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}