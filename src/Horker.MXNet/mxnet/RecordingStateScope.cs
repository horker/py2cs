using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    public partial class RecordingStateScope
    {
        public RecordingStateScope(object isRecord, bool trainMode)
            : this(isRecord != null, trainMode)
        { }
    }
}
