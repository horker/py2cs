using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Python2CSharp
{
    class AstLoader
    {
        public static JsonDocument Load(string jsonFile)
        {
            using (var stream = new FileStream(jsonFile, FileMode.Open))
            {
                return JsonDocument.Parse(stream);
            }
        }
    }
}
