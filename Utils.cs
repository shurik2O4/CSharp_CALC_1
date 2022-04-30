using Microsoft.UI.Xaml.Controls;
using System;

namespace HW_2
{
    internal static class Utils
    {
        public static double CalculateC(double x) => (x + (2 * x * x * x)) * Math.Pow(Math.E, x * x) - x;

        public static double GetItem(double x, int k, double v) => v * (((2 * k) + 1) * x * x / (((2 * k) - 1) * k));

        public static double Method1(double x, double E) {
            double sum = 3 * x * x * x, v = sum;
            int k = 2;
            if (Math.Abs(GetItem(x, k, v)) >= E) {
                v = GetItem(x, k, v);
                sum += Method1(x, E, v, ++k);
            }
            return sum;
        }

        private static double Method1(double x, double E, double v, int k) {
            double sum = v;
            if (Math.Abs(GetItem(x, k, v)) >= E) {
                v = GetItem(x, k, v);
                sum += Method1(x, E, v, ++k);
            }
            return sum;
        }

        public static double Method2(double x, int n) {
            double sum = 3 * x * x * x, v = sum;
            int k = 2, i = 0;
            if (i < n) {
                v = GetItem(x, k, v);
                sum += Method2(x, n, v, ++k, ++i);
            }
            return sum;
        }

        public static double Method2(double x, int n, double v, int k, int i) {
            double sum = v;
            if (i < n) {
                v = GetItem(x, k, v);
                sum += Method2(x, n, v, ++k, ++i);
            }

            return sum;
        }
    }
}