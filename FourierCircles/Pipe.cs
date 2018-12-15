using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierCircles
{
    public class Pipe<T> : IEnumerable<T>
    {
        List<T> pipeList;
        private readonly int capacity;
        public Pipe(int capacity)
        {
            this.capacity = capacity >= 0 ? capacity : 0;
            pipeList = new List<T>(capacity);
        }
        public void Add(T item)
        {

        }
        public void AddRange(IEnumerable<T> items)
        {

        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
