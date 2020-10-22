using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class StringExtensions
    {
        public static bool Endswith(this string self, string pat)
        {
            return self.EndsWith(pat);
        }

        public static string Join(this string self, params object[] values)
        {
            return string.Join(self, values);
        }

        public static string Lower(this string self)
        {
            return self.ToLowerInvariant();
        }

        public static string Slice(this string self, int? lower, int? upper, int? step)
        {
            var l = lower.GetValueOrDefault(0);
            var u = upper.GetValueOrDefault(0);
            var s = step.GetValueOrDefault(1);

            if (s != 1)
                throw new NotImplementedException("step != 1 is not supported");

            if (l < 0)
                l -= self.Length;
            if (u < 0)
                u -= self.Length;

            return self.Substring(l, u - l + 1);
        }

        public static bool Startswith(this string self, string pat)
        {
            return self.StartsWith(pat);
        }
    }
}
