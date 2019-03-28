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
        private double _offset;
        private double _amplify;
        private double _phase;
        private double _freq;
        private Func<double, double,double> amplification;
        private Func<double, double,double> sampling;
        public IEnumerable<Harmonic> Harmonics => _harmonics;

        public Series() => _harmonics = new List<Harmonic>();

        public void Initiate(double offset, double amplify, double phase, double freq)
        {
            _offset = offset;
            _amplify = amplify;
            _phase = phase;
            _freq = freq;
        }
        public void Expression(Func<double,double,double> amplification, Func<double,double,double> sampling)
        {
            this.amplification = amplification;
            this.sampling = sampling;
        }
        public void Times(int count)
        {
            if (_offset != 0)
                _harmonics.Add(new Harmonic(_offset, 0, 0));
            if(count > 0)
            {
                Enumerable.Range(1, count)
                    .Select(x => new Harmonic(amplification(_amplify, x), _phase,sampling(_freq, x)))
                    .ToList()
                    .ForEach(x => AddHarmonic(x.Length,x.Phase,x.Freq));
            }
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
