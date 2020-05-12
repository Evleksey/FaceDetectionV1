using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetectionV1
{
    public static class HaarsPrimitives
    {
        public static double PrimitiveVertical(IntegralImage img, int x, int y, int width, int height)
        {
            return img.RegionSum(x, x + width / 2, y, y + height) - img.RegionSum(x + width / 2, x + width, y, y + height);
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
}
