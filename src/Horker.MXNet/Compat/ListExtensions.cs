using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class ListExtensions
    {
        public static void Extend<T>(this List<T> self, IEnumerable<T> values)
        {
            self.AddRange(values);
        }
    }
}
