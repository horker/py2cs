﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Horker.MXNet.Compat
{
    public static class Coercing
    {
        public static bool CoerceIntoBool(object obj) => (bool)obj;

        public static Dictionary<K, V> CoerceIntoDictionary<K, V>(object obj)
        {
            if (obj is Dictionary<K, V> d)
                return d;
            if (obj is IDictionary id)
            {
                var result = new Dictionary<K, V>();
                foreach(DictionaryEntry entry in id)
                {
                    var key = (K)entry.Key;
                    var value = (V)entry.Key;
                    result.Add(key, value);
                }
                return result;
            }

            throw new ArgumentException("obj is not a dictionary object");
        }

        public static Hashtable CoerceIntoHashtable(object obj) => (Hashtable)obj;

        public static object CoerceIntoObject(object obj) => obj;

        public static string CoerceIntoString(object obj) => (string)obj;

        public static ThreadLocal<T> CoerceIntoThreadLocal<T>(object obj) => new ThreadLocal<T>();

        public static ValueTuple<T1> CoerceIntoValueTuple<T1>(ValueTuple vt) => ValueTuple.Create(default(T1));
        public static ValueTuple<T1, T2> CoerceIntoValueTuple<T1, T2>(ValueTuple vt) => ValueTuple.Create(default(T1), default(T2));
        public static ValueTuple<T1, T2, T3> CoerceIntoValueTuple<T1, T2, T3>(ValueTuple vt) => ValueTuple.Create(default(T1), default(T2), default(T3));
        public static ValueTuple<T1, T2, T3, T4> CoerceIntoValueTuple<T1, T2, T3, T4>(ValueTuple vt) => ValueTuple.Create(default(T1), default(T2), default(T3), default(T4));
        public static ValueTuple<T1, T2, T3, T4, T5> CoerceIntoValueTuple<T1, T2, T3, T4, T5>(ValueTuple vt) => ValueTuple.Create(default(T1), default(T2), default(T3), default(T4), default(T5));
    }
}
