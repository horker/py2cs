using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class ArrayExtensions
    {
        public static T Item1<T>(this T[] array) => array[0];
        public static T Item2<T>(this T[] array) => array[1];
        public static T Item3<T>(this T[] array) => array[2];
        public static T Item4<T>(this T[] array) => array[3];
        public static T Item5<T>(this T[] array) => array[4];
        public static T Item6<T>(this T[] array) => array[5];
    }
}
