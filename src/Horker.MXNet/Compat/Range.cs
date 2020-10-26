using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public class Range : IEnumerable<int>
    {
        public int Start { get; }
        public int Stop { get; }
        public int Step { get; }

        public Range(int stop)
        {
            Start = 0;
            Stop = stop;
            Step = 1;
        }

        public Range(int start, int stop, int step = 1)
        {
            Start = start;
            Stop = stop;
            Step = step;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = Start; i < Stop; i += Step)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
