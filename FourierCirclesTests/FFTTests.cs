using FourierCircles.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FourierCirclesTests
{
    public class FFTTests
    {
        [Fact]
        public void Sample4()
        {
            var samples = Enumerable.Range(0, 4)
                .Select(x => new Complex(1, 0))
                .ToArray();
            var roi = FFT.Run(samples);
        }
    }
}
