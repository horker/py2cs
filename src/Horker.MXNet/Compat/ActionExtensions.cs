using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class ActionExtensions
    {
        public static void Call<T>(this Action<T> action, T p1)
        {
            action.Invoke(p1);
        }
    }
}
