using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierCircles
{
    public class Pipe<T> : IEnumerable<T>
    {
        List<T> _pipeList;
        private readonly int _capacity;
        public Pipe(int capacity)
        {
            _capacity = capacity > 1 ? capacity : 1;
            _pipeList = new List<T>(_capacity);
        }
        public void Add(T item)
        {
            if (_pipeList.Count >= _capacity) _pipeList.RemoveAt(_pipeList.Count - 1);
            _pipeList.Insert(0, item);
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items) Add(item);
        }
        public IEnumerable<KeyValuePair<int,T>> GetPositions()
        {
            int i = 0;
            return _pipeList.Select(x => new KeyValuePair<int,T>(i++,x)); 
        }
        public IEnumerator<T> GetEnumerator() => _pipeList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
