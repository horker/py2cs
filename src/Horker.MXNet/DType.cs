﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Horker.MXNet
{
    internal class DTypeInternal
    {
        public string Name { get; }
        public Type ClrType { get; }
        public int Index { get; }

        internal DTypeInternal(string name, Type type, int index)
        {
            Name = name;
            ClrType = type;
            Index = index;
        }
    }

    public struct DType : IEquatable<DType>
    {
        private static DTypeInternal[] _internals = new DTypeInternal[]
        {
            new DTypeInternal("float32", typeof(float), 0),
            new DTypeInternal("float64", typeof(double), 1),
            new DTypeInternal("float16", null, 2),
            new DTypeInternal("uint8", typeof(sbyte), 3),
            new DTypeInternal("int32", typeof(int), 4),
            new DTypeInternal("int8", typeof(byte), 5),
            new DTypeInternal("int64", typeof(long), 6)
        };

        private static Dictionary<string, int> _nameToDTypeMap;

        static DType()
        {
            _nameToDTypeMap = new Dictionary<string, int>();
            foreach (var i in _internals)
                _nameToDTypeMap[i.Name] = i.Index;
        }

        private int _index;

        public string Name => _internals[_index].Name;
        public Type BaseType => _internals[_index].ClrType;
        public int Index => _internals[_index].Index;

        public DType Type => this;

        public static DType MxRealT => new DType(0);

        public static DType Float32 => new DType(0);
        public static DType Float64 => new DType(1);
        public static DType Float16 => new DType(2);
        public static DType UInt8 => new DType(3);
        public static DType Int32 => new DType(4);
        public static DType Int8 => new DType(5);
        public static DType Int64 => new DType(6);

        private DType(int index)
        {
            _index = index;
        }

        public static DType Get(string name)
        {
            return new DType(_nameToDTypeMap[name]);
        }

        public override bool Equals(object other)
        {
            if (other.GetType() != typeof(DType))
                return false;

            return _index == ((DType)other)._index;
        }

        public bool Equals(DType other)
        {
            return _index == (other)._index;
        }

        public override int GetHashCode()
        {
            return _index;
        }

        public static bool operator==(DType lhs, DType rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator!=(DType lhs, DType rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static implicit operator DType(string name)
        {
            return Get(name);
        }

        public static implicit operator Type(DType dtype)
        {
            return _internals[dtype.Index].ClrType;
        }

        public static implicit operator string(DType dtype)
        {
            return _internals[dtype.Index].Name;
        }
    }
}
