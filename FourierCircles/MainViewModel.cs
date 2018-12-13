using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FourierCircles
{
    public class MainViewModel
    {
        public ObservableCollection<Harmonic> Harmonics { get; set; }
        public Harmonic Last { get; set; }
        private Harmonic fourier;
        public MainViewModel()
        {
            fourier = new Harmonic(100, 30, 0.01);
            fourier.AddHarmonic(40, -30, 0.04)
                .AddHarmonic(20,0,0.08);
            Harmonics = new ObservableCollection<Harmonic>(fourier.ListHarmonics());
            Last = Harmonics.Last();
        }
        public void Run()
        {
            var dt = new DispatcherTimer();
            dt.Tick += (s, e) => fourier.Tick();
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Start();
        }
    }
}
