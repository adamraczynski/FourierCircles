using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FourierCircles.Algorithms
{
    public class FFT
    {
        public static Complex[] Run(Complex[] input)
        {
            var N = input.Length;
            if (N == 1) return input;
            if (N % 2 != 0) throw new Exception();
            var M = N / 2;
            var evenInput = new Complex[M];
            var oddInput = new Complex[M];
            for (int i = 0; i < M; i++)
            {
                evenInput[i] = input[2 * i];
                oddInput[i] = input[2 * i + 1];
            }
            var FFTEven = Run(evenInput);
            var FFTOdd = Run(oddInput);
            var harmonics = new Complex[N];
            for (int i = 0; i < N / 2; i++)
            {
                var OddK = Complex.FromPolarCoordinates(1, -2 * Math.PI * i / N) * FFTOdd[i];
                harmonics[i] = FFTEven[i] + OddK;
                harmonics[N / 2 + i] = FFTEven[i] - OddK;
            }
            return harmonics;
        }
    }
}
