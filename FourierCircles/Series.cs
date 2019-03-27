using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierCircles
{
    public class Series
    {
        private readonly List<Harmonic> _harmonics;
        public IEnumerable<Harmonic> Harmonics => _harmonics;
        public Series()
        {
            _harmonics = new List<Harmonic>();
        }

        public Harmonic AddHarmonic(double amplify, double phase, double freq)
        {
            var harmonic = new Harmonic(amplify, phase, freq);
            _harmonics.Add(harmonic);
            return harmonic;
        }
    }
}
