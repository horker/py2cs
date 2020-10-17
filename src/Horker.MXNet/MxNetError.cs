using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    // defined in python/mxnet/base.py
    public partial class MXNetError : Compat.Exception
    {
        public MXNetError(string message)
            : base(message)
        { }
    }
}
