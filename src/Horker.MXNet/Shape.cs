using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Horker.MXNet
{
    public class Shape : IEnumerable<int>
    {
        public List<int> Dimensions { get; private set; }

        public int this[int index]
        {
            get => Dimensions[index];
            set => Dimensions[index] = value;
        }

        public int Length => Dimensions.Count;

        public Shape(params int[] d)
        {
            Dimensions = new List<int>(d);
        }

        public Shape(IEnumerable<int> d)
        {
            Dimensions = new List<int>(d);
        }

        public static implicit operator int[](Shape s)
        {
            return s.Dimensions.ToArray();
        }

        public static implicit operator Shape(int[] d)
        {
            return new Shape(d);
        }

        public static implicit operator List<int>(Shape s)
        {
            return new List<int>(s.Dimensions);
        }

        public static implicit operator Shape(List<int> d)
        {
            return new Shape(d);
        }

        public static implicit operator int(Shape s)
        {
            if (s.Dimensions.Count > 1)
                throw new ArgumentException("Shape that has more than 1 dimension can't be converted to int");
            return s.Dimensions[0];
        }

        public static implicit operator Shape(int d)
        {
            return new Shape(d);
        }

        public static implicit operator ValueTuple<int>(Shape s)
        {
            if (s.Dimensions.Count != 1)
                throw new ArgumentException("Shape that has other than 1 dimension can't be converted to int");
            return ValueTuple.Create(s.Dimensions[0]);
        }

        public static implicit operator ValueTuple<int, int>(Shape s)
        {
            if (s.Dimensions.Count != 2)
                throw new ArgumentException("Shape that has other than 2 dimension can't be converted to int");
            return ValueTuple.Create(s.Dimensions[0], s.Dimensions[1]);
        }

        public static implicit operator ValueTuple<int, int, int>(Shape s)
        {
            if (s.Dimensions.Count != 3)
                throw new ArgumentException("Shape that has other than 3 dimension can't be converted to int");
            return ValueTuple.Create(s.Dimensions[0], s.Dimensions[1], s.Dimensions[2]);
        }

        public static implicit operator ValueTuple<int, int, int, int>(Shape s)
        {
            if (s.Dimensions.Count != 4)
                throw new ArgumentException("Shape that has other than 4 dimension can't be converted to int");
            return ValueTuple.Create(s.Dimensions[0], s.Dimensions[1], s.Dimensions[2], s.Dimensions[3]);
        }

        public static implicit operator Shape(ValueTuple<int> d)
        {
            return new Shape(d.Item1);
        }

        public static implicit operator Shape(ValueTuple<int, int> d)
        {
            return new Shape(d.Item1, d.Item2);
        }

        public static implicit operator Shape(ValueTuple<int, int, int> d)
        {
            return new Shape(d.Item1, d.Item2, d.Item3);
        }

        public static implicit operator Shape(ValueTuple<int, int, int, int> d)
        {
            return new Shape(d.Item1, d.Item2, d.Item3, d.Item4);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Enumerator : IEnumerator<int>
        {
            private Shape _shape;
            private int _index;

            public int Current => _shape[_index];

            object IEnumerator.Current => Current;

            public Enumerator(Shape shape)
            {
                _shape = shape;
                _index = 0;
            }
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index >= _shape.Length - 1)
                    return false;
                ++_index;
                return true;
            }

            public void Reset()
            {
                _index = 0;
            }
        }
    }
}
