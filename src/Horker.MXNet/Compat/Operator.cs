using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class Operator
    {
        public static float Add(float a, float b) => a + b;
        public static float Sub(float a, float b) => a - b;
        public static float Mul(float a, float b) => a * b;
        public static float Truediv(float a, float b) => a / b;
        public static float Mod(float a, float b) => a % b;
        public static float Pow(float a, float b) => MathF.Pow(a, b);
    }
}
