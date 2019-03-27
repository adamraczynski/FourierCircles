using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierCircles.Extensions
{
    public static class SeriesExtensions
    {
        public static Series NewHarmonic(this Series series, double amplify, double phase, double freq)
        {
            series.AddHarmonic(amplify,phase,freq);
            return series;
        }
    }
}
