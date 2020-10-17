using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Gluon
{
    public partial class DeferredInitializationError : MXNetError
    {
        public DeferredInitializationError(string message)
            : base(message)
        { }
    }
}
