using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Gluon
{
    // Defined in mxnet/gluon/parameter.py
    public partial class DeferredInitializationError : MXNetError
    {
        public DeferredInitializationError(string message)
            : base(message)
        { }
    }
}
