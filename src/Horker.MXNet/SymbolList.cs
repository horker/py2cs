using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using SymbolHandle = System.IntPtr;

namespace Horker.MXNet
{
    public class SymbolList : IList<Symbol>
    {
        private List<Symbol> _data;

        public Symbol this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        internal Symbol Item1 => this[0];
        internal Symbol Item2 => this[1];
        internal Symbol Item3 => this[2];
        internal Symbol Item4 => this[3];
        internal Symbol Item5 => this[4];
        internal Symbol Item6 => this[5];

        public IEnumerable<SymbolHandle> Handles => _data.Where(x => x != null).Select(x => x.Handle);

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public SymbolList()
        {
            _data = new List<Symbol>();
        }

        public SymbolList(IEnumerable<Symbol> a)
        {
            _data = new List<Symbol>(a);
        }

        public SymbolList(Symbol a)
            : this()
        {
            _data.Add(a);
        }

        public SymbolList(IEnumerable<SymbolHandle> s)
        {
            _data = s.Select(x => new Symbol(x)).ToList();
        }

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

        public static implicit operator SymbolHandle[](SymbolList syms)
        {
            return syms.Select(x => x.Handle).ToArray();
        }

        public static implicit operator SymbolList(SymbolHandle[] syms)
        {
            return new SymbolList(syms);
        }

        public static implicit operator Symbol(SymbolList list)
        {
            if (list.Count != 1)
                throw new ArgumentException("Attempted to convert a SymbolList into a Symbol when its length is not one");
            return list[0];
        }

        public static implicit operator SymbolList(Symbol ndarray)
        {
            return new SymbolList(ndarray);
        }
    }
}
