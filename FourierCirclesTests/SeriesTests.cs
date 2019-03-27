using FourierCircles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FourierCirclesTests
{
    public class SeriesTests
    {
        [Fact]
        public void Ctor()
        {
            var roi = new Series();
            var harmonic = roi.AddHarmonic(1, 0, 1);
            Assert.Contains(harmonic,roi.Harmonics);
        }
    }
}
