using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public struct Slice : IEnumerable<int>
    {
        public int Start { get; set; }
        public int Stop { get; set; }
        public int Step { get; set; }

        public Slice(int start, int stop, int step = 1)
        {
            Start = start;
            Stop = stop;
            Step = step;
        }

        public static implicit operator ValueTuple<int, int, int>(Slice slice)
        {
            return ValueTuple.Create(slice.Start, slice.Stop, slice.Step);
        }

        public static implicit operator Slice(ValueTuple<int, int, int> tuple)
        {
            return new Slice(tuple.Item1, tuple.Item2, tuple.Item3);
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
