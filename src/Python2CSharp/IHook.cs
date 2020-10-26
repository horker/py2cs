using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Python2CSharp
{
    public interface IHook
    {
        public ValueConstraint TryGenerate(JToken node, Context ctx);
    }
}
