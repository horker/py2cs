using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SymbolHandle = System.IntPtr;

namespace Horker.MXNet
{
    public partial class Symbol : SymbolBase, IList<Symbol>
    {
        public Symbol(SymbolHandle handle)
            : base(handle)
        { }

        public Symbol this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Symbol item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Symbol item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Symbol[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Symbol> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(Symbol item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Symbol item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Symbol item)
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
