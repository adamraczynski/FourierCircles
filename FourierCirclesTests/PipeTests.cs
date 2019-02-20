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
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void SetCapacity(int capacity)
        {
            var pipe = new Pipe<int>(capacity);
            pipe.AddRange(Enumerable.Range(0, capacity));
            Assert.Equal(capacity, pipe.Count());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void InvalidCapacity(int capacity)
        {
            var pipe = new Pipe<int>(capacity);
            Assert.Empty(pipe);
        }

        [Fact]
        public void KeepCapacityOnAdd()
        {
            var pipe = new Pipe<int>(2);
            pipe.Add(0);
            pipe.Add(1);
            pipe.Add(2);
            Assert.Equal(new int[] {2, 1},pipe.Select(x => x));
        }
        [Fact]
        public void KeepCapacityOnAddRange()
        {
            var pipe = new Pipe<int>(3);
            pipe.AddRange(Enumerable.Range(0, 3));
            pipe.AddRange(Enumerable.Range(3, 2));
            Assert.Equal(new int[] { 4, 3, 2 }, pipe.Select(x => x));
        }
    }
}
