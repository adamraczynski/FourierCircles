using FourierCircles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FourierCirclesTests
{
    public class PipeTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(-1)]
        public void SetCapacity(int capacity)
        {
            var pipe = new Pipe<int>(capacity);
            pipe.AddRange(Enumerable.Range(0,capacity + 1));
            Assert.Equal(capacity, pipe.Count());

        }
    }
}
