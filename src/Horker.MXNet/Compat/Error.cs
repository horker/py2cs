using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    public class Exception : System.Exception
    {
        public Exception()
            : base()
        { }

        public Exception(string message)
        : base(message)
        { }
    }

    public class RuntimeError : Exception
    {
        public RuntimeError()
            : base()
        { }

        public RuntimeError(string message)
            : base(message)
        { }
    }

    public class LookupError : Exception
    {
        public LookupError()
            : base()
        { }

        public LookupError(string message)
            : base(message)
        { }
    }

    public class KeyError : LookupError
    {
        public KeyError()
            : base()
        { }

        public KeyError(string message)
            : base(message)
        { }
    }

    public class NotImplementedError : RuntimeError
    {
        public NotImplementedError()
            : base()
        { }

        public NotImplementedError(string message)
            : base(message)
        { }
    }

    public class TypeError : Exception
    {
        public TypeError()
            : base()
        { }

        public TypeError(string message)
            : base(message)
        { }
    }

    public class ValueError : Exception
    {
        public ValueError()
            : base()
        { }

        public ValueError(string message)
            : base(message)
        { }
    }
}
