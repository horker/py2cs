using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace Horker.MXNet.Compat
{
    public static class Compat
    {
        public static bool All(IEnumerable<bool> e)
        {
            return e.All(x => x);
        }

        public static bool Any(IEnumerable<bool> e)
        {
            return e.Any(x => x);
        }

        public static void Assert(bool condition, string expression)
        {
            if (!condition)
                throw new ApplicationException($"Assertion failed: {expression}");
        }

        public static bool Bool(bool value) => value;
        public static bool Bool(int value) => value != 0;

        public static IEnumerable<(int, T)> Enumerate<T>(IEnumerable<T> e)
        {
            var i = 0;
            foreach (var value in e)
                yield return (i, value);
        }

        public static float Float(float value) => value;
        public static float Float(object value) => (float)value;

        public static bool Hasattr<T>(T obj, string name)
        {
            var members = obj.GetType().GetMember(name);
            return members.Length >= 1;
        }

        public static int Id(object value) => value.GetHashCode();

        public static int Int(int value) => value;
        public static int Int(object value) => (int)value;

        public static object Getattr<T>(T obj, string name)
        {
            return Getattr(obj, name, null);
        }

        public static object Getattr<T>(T obj, string name, object fallback)
        {
            try
            {
                return obj.GetType().GetProperty(name).GetValue(obj);
            }
            catch (System.Exception)
            { }
            return fallback;
        }

        public static bool Isinstance(object obj, Type type) => obj.GetType() == type || obj.GetType().IsSubclassOf(type);
        public static bool Isinstance(object obj, ValueTuple<Type, Type> types) => Isinstance(obj, types.Item1) || Isinstance(obj, types.Item2);
        public static bool Isinstance(object obj, ValueTuple<Type, Type, Type> types) => Isinstance(obj, types.Item1) || Isinstance(obj, types.Item2) || Isinstance(obj, types.Item3);
        public static bool Isinstance(object obj, ValueTuple<Type, Type, Type, Type> types) => Isinstance(obj, types.Item1) || Isinstance(obj, types.Item2) || Isinstance(obj, types.Item3) || Isinstance(obj, types.Item4);
        public static bool Isinstance(object obj, ValueTuple<Type, Type, Type, Type, Type> types) => Isinstance(obj, types.Item1) || Isinstance(obj, types.Item2) || Isinstance(obj, types.Item3) || Isinstance(obj, types.Item4) || Isinstance(obj, types.Item5);

        public static bool IsNone(bool value) => !value;
        public static bool IsNone(int value) => value == 0;
        public static bool IsNone(object value) => value == null;

        public static bool IsTrue(bool value)
        {
            return value;
        }

        public static bool IsTrue(object value)
        {
            return value != null;
        }

        public static int Len(string s)
        {
            return s.Length;
        }

        public static int Len(System.Array items)
        {
            return items.Length;
        }

        public static int Len(ICollection items)
        {
            return items.Count;
        }

        public static int Len<T>(IEnumerable<T> items)
        {
            return items.Count();
        }

        public static int Len<T>(List<T> items)
        {
            return items.Count;
        }

        public static List<T> List<T>(IEnumerable<T> items)
        {
            return new List<T>(items);
        }

        public static T Max<T>(T value1, T value2)
            where T: IComparable<T>
        {
            return value1.CompareTo(value2) > 0 ? value1 : value2;
        }

        public static T Min<T>(T value1, T value2)
            where T: IComparable<T>
        {
            return value1.CompareTo(value2) < 0 ? value1 : value2;
        }

        private static string ConvertFormatString(string f)
        {
            var count = 0;
            return string.Join("", Regex.Split(f, "(%.)").Select(x =>
            {
                if (x.Length >= 2 && x[0] == '%')
                {
                    if (x[1] == '%')
                        return "%";
                    return "{" + count++ + "}";
                }
                return x;
            }));
        }

        public static string PyFormat<T1>(this string f, T1 value)
        {
            return string.Format(ConvertFormatString(f), value);
        }

        public static string PyFormat<T1>(this string f, ValueTuple<T1> value)
        {
            return string.Format(ConvertFormatString(f), value.Item1);
        }

        public static string PyFormat<T1, T2>(this string f, ValueTuple<T1, T2> values)
        {
            return string.Format(ConvertFormatString(f), values.Item1, values.Item2);
        }

        public static string PyFormat<T1, T2, T3>(this string f, ValueTuple<T1, T2, T3> values)
        {
            return string.Format(ConvertFormatString(f), values.Item1, values.Item2, values.Item3);
        }

        public static string PyFormat<T1, T2, T3, T4>(this string f, ValueTuple<T1, T2, T3, T4> values)
        {
            return string.Format(ConvertFormatString(f), values.Item1, values.Item2, values.Item3, values.Item4);
        }

        public static IEnumerable<int> Range(int n)
        {
            for (var i = 0; i < n; ++i)
                yield return i;
        }

        public static HashSet<T> Set<T>(IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        }

        public static string Str<T>(T v)
        {
            return v.ToString();
        }

        public static List<T> Tuple<T>(IEnumerable<T> items)
        {
            return new List<T>(items);
        }

        public static Type Type(object obj)
        {
            return obj.GetType();
        }

        public static IEnumerable<(T1, T2)> Zip<T1, T2>(IEnumerable<T1> e1, IEnumerable<T2> e2)
        {
            var i1 = e1.GetEnumerator();
            var i2 = e2.GetEnumerator();

            while (i1.MoveNext() && i2.MoveNext())
                yield return ValueTuple.Create(i1.Current, i2.Current);
        }
    }
}
