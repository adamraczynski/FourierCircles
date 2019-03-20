using FourierCircles.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FourierCircles
{
    public class Harmonic : INotifyPropertyChanged
    {
        public double Length { get; set; }
        public double Phase { get; set; }
        public Point Origin { get; set; }
        public Point End => new Point(Origin.X + Math.Sin(MathExt.RadToAngle(Phase)) * Length
                , Origin.Y + Math.Cos(MathExt.RadToAngle(Phase)) * Length);
        public double Freq { get; set; }
        public Harmonic SubHarmonic { get; private set; }
        public Harmonic ParentHarmonic { get; private set; }
        public Harmonic(double length, double phase, double freq)
        {
            Length = length;
            Phase = phase;
            Freq = freq;
            Origin = new Point(0, 0);
        }
        public Harmonic AddHarmonic(double length, double phase, double freq)
        {
            SubHarmonic = new Harmonic(length, phase, freq);
            SubHarmonic.ParentHarmonic = this;
            SubHarmonic.Origin = End;
            return SubHarmonic;
        }
        public IEnumerable<Harmonic> ListHarmonics()
        {
            var list = new List<Harmonic>();
            list.Add(this);
            if (SubHarmonic != null) list.AddRange(SubHarmonic.ListHarmonics());
            return list;
        }
        public void Tick()
        {
            Phase += Freq;
            Origin = ParentHarmonic?.End ?? Origin;
            OnPropertyChanged("Origin");
            OnPropertyChanged("End");
            SubHarmonic?.Tick();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
