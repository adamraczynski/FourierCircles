using FourierCircles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

namespace FourierCirclesTests
{
    public class HarmonicTests
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(1,0,1)]
        [InlineData(10,0,10)]
        public void Ctor(double amplify,double phase,double freq)
        {
            var roi = new Harmonic(amplify,phase,freq);
            Assert.Equal(amplify, roi.Length);
            Assert.Equal(freq, roi.Freq);
            Assert.Equal(phase, roi.Phase);
            Assert.Equal(amplify, roi.End.Y,0);
            Assert.Equal(0, roi.End.X,0);
            Assert.Null(roi.ParentHarmonic);
            Assert.Null(roi.SubHarmonic);
            Assert.Equal(new Point(0,0), roi.Origin);
            Assert.Single(roi.ListHarmonics());
        }
        [Fact]
        public void ChainHarmonics()
        {
            var roi = new Harmonic(1, 0, 1);
            roi.AddHarmonic(1, 0, 1).AddHarmonic(1, 0, 1);
            Assert.NotSame(roi.SubHarmonic.ParentHarmonic, roi.SubHarmonic.SubHarmonic);
            Assert.Null(roi.ParentHarmonic);
            Assert.Equal(roi.SubHarmonic.Origin, roi.End);
            Assert.Equal(roi.SubHarmonic.SubHarmonic.Origin, roi.SubHarmonic.End);
            Assert.Equal(new Point(0, 3), roi.SubHarmonic.SubHarmonic.End);
        }

        [Fact]
        public void TickTock()
        {
            var roi = new Harmonic(1, 0, 90);
            roi.Tick();
            Assert.Equal(1, roi.End.X,1);
            Assert.Equal(0, roi.End.Y, 1);

        }
    }
}
