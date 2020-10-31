using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    public class NDArrayList : IList<NDArray>
    {
        private List<NDArray> _data;

        public NDArray this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        internal NDArray Item1 => this[0];
        internal NDArray Item2 => this[1];
        internal NDArray Item3 => this[2];
        internal NDArray Item4 => this[3];
        internal NDArray Item5 => this[4];
        internal NDArray Item6 => this[5];

        public IEnumerable<NDArrayHandle> Handles => _data.Where(x => x != null).Select(x => x.Handle);

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public NDArrayList()
        {
            _data = new List<NDArray>();
        }

        public NDArrayList(IEnumerable<NDArray> a)
        {
            _data = new List<NDArray>(a);
        }

        public NDArrayList(NDArray a)
            : this()
        {
            _data.Add(a);
        }

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

        public static implicit operator NDArray(NDArrayList list)
        {
            if (list.Count != 1)
                throw new ArgumentException("Attempted to convert a NDArrayList into a NDArray when its length is not one");
            return list[0];
        }

        public static implicit operator NDArrayList(NDArray ndarray)
        {
            return new NDArrayList(ndarray);
        }
    }
}
