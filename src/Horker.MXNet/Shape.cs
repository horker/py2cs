using Horker.MXNet.Compat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Horker.MXNet
{
    public class Shape : IEnumerable<int>, IEquatable<Shape>
    {
        public List<int> Dimensions { get; private set; }

        public int this[int index]
        {
            get => Dimensions[index];
            set => Dimensions[index] = value;
        }

        // Tuple-like accessors
        internal int Item1 => Dimensions[0];
        internal int Item2 => Dimensions[1];
        internal int Item3 => Dimensions[2];
        internal int Item4 => Dimensions[4];

        public int Length => Dimensions.Count;

        public int Size => Dimensions.Aggregate(1, (x, sum) => x * sum);

        public Shape(params int[] d)
        {
            Dimensions = new List<int>(d);
        }

        public Shape(IEnumerable<int> d)
        {
            Dimensions = new List<int>(d);
        }

        // Enumerators

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var i in Dimensions)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Equality

        public bool Equals(Shape other)
        {
            if (Dimensions.Count != other.Dimensions.Count)
                return false;

            for (var i = 0; i < Dimensions.Count; ++i)
                if (Dimensions[i] != other.Dimensions[i])
                    return false;

            return true;
        }

        public override bool Equals(object other)
        {
            if (other is Shape s)
                return Equals(s);

            if (other is ValueTuple<int> t)
                return Dimensions.Count == 1 && Dimensions[0] == t.Item1;

            return false;
        }

        public static bool operator ==(Shape self, object other)
        {
            return self.Equals(other);
        }

        public static bool operator !=(Shape self, object other)
        {
            return !self.Equals(other);
        }

        public override int GetHashCode()
        {
            return Dimensions.GetHashCode();
        }

        // Shape specific methods

        public void Extend(IEnumerable<int> values)
        {
            Dimensions.AddRange(values);
        }

        // Converters

        public static implicit operator int[](Shape s)
        {
            return s.Dimensions.ToArray();
        }

        public static implicit operator Shape(int[] d)
        {
            return new Shape(d);
        }

        public static implicit operator float[](Shape s)
        {
            return s.Dimensions.Cast<float>().ToArray();
        }

        public static implicit operator Shape(float[] d)
        {
            return new Shape(d.Cast<int>());
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
    }
}
