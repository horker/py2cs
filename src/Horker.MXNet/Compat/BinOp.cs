using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class BinOp
    {
        public static int Add(int a, int b) => a + b;
        public static float Add(float a, float b) => a + b;
        public static double Add(double a, double b) => a + b;
        public static string Add(string a, string b) => a + b;

        public static List<T> Add<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            var result = new List<T>(a);
            result.AddRange(b);
            return result;
        }

        public static List<T> Add<T>(IEnumerable<T> a, ValueTuple<T> b)
        {
            var result = new List<T>(a);
            result.Add(b.Item1);
            return result;
        }

        public static int Mult(int a, int b) => a * b;
        public static float Mult(float a, float b) => a * b;
        public static double Mult(double a, double b) => a * b;
        public static string Mult(char a, int b) => new string(a, b);

        public static string Mult(string a, int b)
        {
            var s = new StringBuilder();
            for (var i = 0; i < b; ++i)
                s.Append(a);

            return s.ToString();
        }

    }
}
