using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Python2CSharp
{
    public class Program
    {
        private static List<string> CollectFiles(string root, string extension)
        {
            var results = new List<string>();
            CollectFiles(results, root, extension);
            return results;
        }

        private static void CollectFiles(List<string> results, string root, string extension)
        {
            var files = Directory.EnumerateFiles(root).Where(f => f.EndsWith(extension));
            results.AddRange(files);

            foreach (var d in Directory.EnumerateDirectories(root))
                CollectFiles(results, d, extension);
        }

        private static void Generate(string inFile, string configFile, string commonConfigFile, string outFile)
        {
            var ast = JObject.Parse(File.ReadAllText(inFile), new JsonLoadSettings() { LineInfoHandling = LineInfoHandling.Load });

            var config = Config.Load(configFile, commonConfigFile);

            var formatter = new Formatter();
            var generator = new Generator(formatter, config);

            // MXNet specific generators
            generator.AddHook(new MXNet.UFuncHelperHook(generator.Out, generator.Config));
            generator.AddHook(new MXNet.CTypesPointerHook(generator.Out, generator.Config));

            generator.Generate(ast.Root, new Context());

            File.WriteAllText(outFile, formatter.GetOutput());
        }

        public static void Main(string[] args)
        {
            var configRoot = Path.GetFullPath(args[0]);
            var outRoot = args[1];
            var commonConfigFile = args[2];

            var configFiles = CollectFiles(configRoot, ".config.json");

            foreach (var configFile in configFiles)
            {
                var file = configFile.Substring(configRoot.Length);
                var inFile = outRoot +  file.Replace(".config.json", ".json");
                var outFile = outRoot + file.Replace(".py.config.json", "_gen.cs");

                Generate(inFile, configFile, commonConfigFile, outFile);
            }
        }

    }
}
