using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> self, int? start, int? stop, int? step = 1)
        {
            if (start.HasValue)
            {
                self = self.Skip(start.Value);
                if (stop.HasValue)
                    self = self.Take(stop.Value - start.Value);
            }

            var st = step.HasValue ? step.Value : 1;

            var i = 0;
            foreach (var value in self)
            {
                if (i % st == 0)
                    yield return value;
                ++i;
            }
        }
    }
}
