using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class Warnings
    {
        public static void Warn(string s, Type cls = null, int stacklevel = 0)
        {
            Console.WriteLine(s);
        }
    }
}
