using Horker.MXNet.Compat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    public partial class Context : PythonObject, IEquatable<Context>
    {
        public override bool Equals(object obj)
        {
            return obj is Context context &&
                   DeviceTypeid == context.DeviceTypeid &&
                   DeviceId == context.DeviceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeviceTypeid, DeviceId);
        }

        public static explicit operator Context(string deviceType)
        {
            return new Context(deviceType, 0);
        }
    }
}
