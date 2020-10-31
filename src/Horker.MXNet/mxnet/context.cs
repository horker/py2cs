using Horker.MXNet.Compat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    // Defined in mxnet/context.py
    public partial class Context : IEquatable<Context>
    {
        public bool Equals(Context obj)
        {
            return DeviceTypeid == obj.DeviceTypeid &&
                   DeviceId == obj.DeviceId;
        }

        public override bool Equals(object obj)
        {
            return obj is Context ctx &&
                   DeviceTypeid == ctx.DeviceTypeid &&
                   DeviceId == ctx.DeviceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeviceTypeid, DeviceId);
        }

        public override string ToString()
        {
            return __Str__();
        }

        public static implicit operator Context(string deviceType)
        {
            return new Context(deviceType, 0);
        }

        public static implicit operator string(Context context)
        {
            return context.ToString();
        }
    }
}
