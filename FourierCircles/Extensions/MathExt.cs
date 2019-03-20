using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierCircles.Extensions
{
    public static class MathExt
    {
        public static double RadToAngle(double radians)
            => radians * Math.PI / 180;
    }
}
