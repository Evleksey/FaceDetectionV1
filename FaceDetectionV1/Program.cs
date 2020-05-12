using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetectionV1
{
    public class Image
    {
        public double[,] pixels;
        public Image() { }
        public Image(Bitmap img)
        {
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    this.pixels[x, y] = img.GetPixel(x, y).GetBrightness();
                }
            }
        }
    }
    public class IntegralImage : Image
    {
        public IntegralImage(Image img)
        {
            for (int x = 0; x < img.pixels.GetLength(0); x++)
            {
                for (int y = 0; y < img.pixels.GetLength(1); y++)
                {
                    this.pixels[x, y] = img.pixels[x, y];
                    if (y != 0) this.pixels[x, y] += img.pixels[x, y - 1];
                    if (x != 0) this.pixels[x, y] += img.pixels[x - 1, y];

                }
            }
        }

        public double RegionSum(int x1, int x2, int y1, int y2)
        {
            return (this.pixels[x2, y2] - this.pixels[x1, y2] - this.pixels[x2, y1] + this.pixels[x1, y1]);
        }
    }

    public static class HaarsPrimitives
    {
        public static double PrimitiveVertical(IntegralImage img, int x, int y, int width, int height)
        {
            return img.RegionSum(x, x + width / 2, y, y + height) - img.RegionSum(x+ width / 2, x + width, y, y + height);
        }
        public static double PrimitiveHorizontal(IntegralImage img, int x, int y, int width, int height)
        {
            return img.RegionSum(x, x + width, y, y + height / 2) - img.RegionSum(x, x + width, y + height / 2, y + height);
        }
        public static double PrimitiveDiagonal(IntegralImage img, int x, int y, int width, int height)
        {
            return img.RegionSum(x, x + width / 2, y, y + height / 2) - img.RegionSum(x + width / 2, x + width, y, y + height / 2)
                - img.RegionSum(x, x + width / 2, y + height / 2, y + height) + img.RegionSum(x + width / 2, x + width, y + height / 2, y + height);
        }
        public static double PrimitiveMiddle(IntegralImage img, int x, int y, int width, int height)
        {
            return img.RegionSum(x, x + width / 3, y, y + height) - img.RegionSum(x + width / 2, x + width, y, y + height) + img.RegionSum(x + width / 2, x + width, y, y + height);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Image img = new Image(new Bitmap("img.bmp"));
            IntegralImage integral = new IntegralImage(img);
        }
    }
}
