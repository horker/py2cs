using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class DictionaryExtensions
    {
        public static bool Contains<K, V>(this Dictionary<K, V> d, K key)
        {
            return d.ContainsKey(key);
        }

        public static IEnumerable<K> Keys<K, V>(this Dictionary<K, V> d)
        {
            foreach (var entry in d)
                yield return entry.Key;
        }

        public static IEnumerable<V> Values<K, V>(this Dictionary<K, V> d)
        {
            foreach (var entry in d)
                yield return entry.Value;
        }

        public static IEnumerable<(K, V)> Items<K, V>(this Dictionary<K, V> d)
        {
            foreach (var entry in d)
                yield return (entry.Key, entry.Value);
        }
    }
}
