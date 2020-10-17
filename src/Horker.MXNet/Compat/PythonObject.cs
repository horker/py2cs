using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Horker.MXNet.Compat
{
    public class PythonObject
    {
        public Type Class
        {
            get => this.GetType();
        }

        public void Setattr(string name, object value)
        {
            var m = this.GetType().GetField(name);
            if (m != null)
                m.SetValue(this, value);

            var p = this.GetType().GetProperty(name);
            if (p != null)
                p.SetValue(this, value);
        }
    }
}
