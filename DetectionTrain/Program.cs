using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using FaceDetectionV1;
using Image = FaceDetectionV1.Image;

namespace DetectionTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int name = 0;
            while (File.Exists($"img{name}.bmp"))
            {

                Image img = new Image(new Bitmap($"img{name}.bmp"));
                IntegralImage integral = new IntegralImage(img);

            }
        }
    }
}
