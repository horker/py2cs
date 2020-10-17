using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class TupleExtensions
    {
        public static bool Contains<T>(this ValueTuple<T, T> self, T value)
        {
            return object.Equals(self.Item1, value) || object.Equals(self.Item2, value);
        }

        public static IEnumerable<(K,V)> Where<K, V>(this IEnumerable<(K, V)> self, Func<K, V, bool> cond)
        {
            foreach (var item in self)
                if (cond.Invoke(item.Item1, item.Item2))
                    yield return item;
        }

        public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<(K, V)> self)
        {
            var result = new Dictionary<K, V>();
            foreach (var (key, value) in self)
                result.Add(key, value);

            return result;
        }
    }
}
