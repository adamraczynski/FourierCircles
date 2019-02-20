using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public PointCollection Graph { get; set; }
        public ObservableCollection<Harmonic> Harmonics { get; set; }
        public Harmonic Last { get; set; }
        private Harmonic fourier;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            fourier = new Harmonic(100, 30, 0.01);
            fourier.AddHarmonic(40, -30, 0.04).AddHarmonic(20,0,0.08);
            Harmonics = new ObservableCollection<Harmonic>(fourier.ListHarmonics());
            _pipe = new Pipe<double>(500);
            //Graph = new ObservableCollection<Point>(
            //    Enumerable.Range(0,100)
            //    .Select(x => new Point(x*2,(x % 2)*20)));
            Graph = new PointCollection();
            Last = Harmonics.Last();
        }
        public void Run()
        {
            var dt = new DispatcherTimer();
            dt.Tick += (s, e) =>
            {
                _pipe.Add(Last.End.Y);
                Graph.Add(new Point(Last.End.Y, Last.End.Y));
                //OnPropertyChanged("Graph");
                fourier.Tick();
                OnPropertyChanged("Graph");
            };
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Start();
        }
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
