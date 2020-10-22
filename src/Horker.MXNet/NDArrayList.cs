using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    public class NDArrayList : IList<NDArray>
    {
        public NDArray this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NDArray Item1 => this[0];
        public NDArray Item2 => this[1];
        public NDArray Item3 => this[2];
        public NDArray Item4 => this[3];
        public NDArray Item5 => this[4];
        public NDArray Item6 => this[5];

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(NDArray item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(NDArray item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(NDArray[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<NDArray> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(NDArray item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, NDArray item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(NDArray item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
