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
        private Harmonic _lastHarmonic;
        public IEnumerable<Harmonic> Harmonics => _harmonics;
        public Series()
        {
            _harmonics = new List<Harmonic>();
        }

        public Harmonic AddHarmonic(double amplify, double phase, double freq)
        {
            _lastHarmonic = _lastHarmonic == null 
                ? new Harmonic(amplify, phase, freq)
                : _lastHarmonic.AddHarmonic(amplify, phase, freq);
            _harmonics.Add(_lastHarmonic);
            return _lastHarmonic;
        }

        public void Tick() => _harmonics.FirstOrDefault()?.Tick();
    }
}
