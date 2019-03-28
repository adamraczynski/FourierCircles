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
using FourierCircles.Extensions;

namespace FourierCircles
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private Pipe<double> _pipe;
        public ObservableCollection<Point> Graph { get; set; }
        public ObservableCollection<Harmonic> Harmonics { get; set; }
        public Harmonic Last { get; set; }
        private Series _series;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            //var _amplify = 300 / Math.PI;
            //_series = new Series();
            //_series.NewHarmonic(_amplify, 90, 2)
            //    .NewHarmonic(_amplify / 3, 90, 6)
            //    .NewHarmonic(_amplify / 5, 90, 10)
            //    .NewHarmonic(_amplify / 7, 90, 14)
            //    .NewHarmonic(_amplify / 9, 90, 18)
            //    .NewHarmonic(_amplify / 11, 90, 22)
            //    .NewHarmonic(_amplify / 13, 90, 26)
            //    .NewHarmonic(_amplify / 15, 90, 30)
            //    .NewHarmonic(_amplify / 17, 90, 34)
            //    .NewHarmonic(_amplify / 19, 90, 38);
            _series = new Series();
            _series.Initiate(0, 250, 90, 2);
            _series.Expression((a, n) => a / Math.PI / (2 * n - 1), (t, n) => t * (2 * n - 1));
            _series.Times(50);
            Harmonics = new ObservableCollection<Harmonic>(_series.Harmonics);
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
                _series.Tick();
                OnPropertyChanged("Graph");
            };
            _dt.Interval = TimeSpan.FromMilliseconds(20);
            _dt.Start();
        }
        protected void OnPropertyChanged(string name) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
