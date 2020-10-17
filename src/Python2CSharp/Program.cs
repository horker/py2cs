using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Python2CSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inFile = args[0];
            var configFile = args[1];
            var outFile = args[2];

            var ast = JObject.Parse(File.ReadAllText(inFile), new JsonLoadSettings() { LineInfoHandling = LineInfoHandling.Load });

            var deserializer = new DeserializerBuilder().Build();
            var config = deserializer.Deserialize<Config>(File.ReadAllText(configFile));

            var formatter = new Formatter();
            var generator = new Generator(formatter, config);
            generator.Generate(ast.Root, new Context());

            File.WriteAllText(outFile, formatter.GetOutput());
        }
    }
}
