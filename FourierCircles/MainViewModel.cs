using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace FourierCircles
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private Pipe<double> _pipe;
        public ObservableCollection<Point> Graph { get; set; }
        public ObservableCollection<Harmonic> Harmonics { get; set; }
        public Harmonic Last { get; set; }
        private Harmonic _fourier;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _fourier = new Harmonic(100, 0, 0.02);
            _fourier.AddHarmonic(100.0/3, 135, 0.06)
                .AddHarmonic(100.0/5,0,0.1)
                .AddHarmonic(100.0/7,135,0.14);
            Harmonics = new ObservableCollection<Harmonic>(_fourier.ListHarmonics());
            _pipe = new Pipe<double>(1500);
            Graph = new ObservableCollection<Point>();
            Last = Harmonics.Last();
        }

        public void Run()
        {
            var _dt = new DispatcherTimer();
            _dt.Tick += (s, e) =>
            {
                _pipe.Add(Last.End.Y);
                var _pts = _pipe.GetPositions().Select(x => new Point(x.Key, x.Value));
                Graph = new ObservableCollection<Point>(_pts);
                _fourier.Tick();
                OnPropertyChanged("Graph");
            };
            _dt.Interval = TimeSpan.FromMilliseconds(20);
            _dt.Start();
        }
        protected void OnPropertyChanged(string name) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
