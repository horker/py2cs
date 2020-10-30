using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Horker.MXNet.Interop;
using Newtonsoft.Json;
using AtomicSymbolCreator = System.IntPtr;
using mx_uint = System.Int32;

// This code is borrowed from:
// https://github.com/tech-quantum/MxNet.Sharp/blob/v1.1.0/src/MxNetLib.OpGenerator/OpWrapperGenerator.cs

namespace Horker.MXNet
{
    public class Argument
    {
        public string Name { get; set; }
        public string TypeInfo { get; set; }
        public string Description { get; set; }
    }

    public class AtomicSymbolInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumArgs { get; set; }
        public List<Argument> Arguments { get; set; } = new List<Argument>();
        public string KeyVarNumArgs { get; set; }
        public string ReturnType { get; set; }
    }

    public class SymbolInfoLoader
    {
        public static List<AtomicSymbolInfo> LoadSymbolInfo()
        {
            int r = _LIB.MXSymbolListAtomicSymbolCreators(out var numSymbolCreators, out IntPtr symbolCreatorsPtr);
            Debug.Assert(r == 0);
            IntPtr[] symbolCreators = new IntPtr[numSymbolCreators];
            Marshal.Copy(symbolCreatorsPtr, symbolCreators, 0, (int)numSymbolCreators);

            var infos = new List<AtomicSymbolInfo>();
            for (int i = 0; i < numSymbolCreators; i++)
            {
                r = _LIB.MXSymbolGetAtomicSymbolInfo(symbolCreators[i],
                out var namePtr,
                out var descriptionPtr,
                out int numArgs,
                out var argNamesPtr,
                out var argTypeInfosPtr,
                out var argDescriptionsPtr,
                out var keyVarNumArgsPtr,
                out var returnType);
                string name = Marshal.PtrToStringUTF8(namePtr);
                if (name == null)
                {
                    Console.WriteLine($"error namePtr {i}");
                    continue;
                }

                string description = Marshal.PtrToStringUTF8(descriptionPtr);

                var keyVarNumArgs = Marshal.PtrToStringUTF8(keyVarNumArgsPtr);

                IntPtr[] argNamesArray = new IntPtr[numArgs];
                IntPtr[] argTypeInfosArray = new IntPtr[numArgs];
                IntPtr[] argDescriptionsArray = new IntPtr[numArgs];
                if (numArgs > 0)
                {
                    Marshal.Copy(argNamesPtr, argNamesArray, 0, (int)numArgs);
                    Marshal.Copy(argTypeInfosPtr, argTypeInfosArray, 0, (int)numArgs);
                    Marshal.Copy(argDescriptionsPtr, argDescriptionsArray, 0, (int)numArgs);

                }

                var info = new AtomicSymbolInfo()
                {
                    Name = name,
                    Description = description,
                    NumArgs = numArgs,
                    KeyVarNumArgs = keyVarNumArgs,
                    ReturnType = returnType
                };

                var args = new List<Argument>();
                for (int j = 0; j < numArgs; j++)
                {
                    string descriptions = Marshal.PtrToStringUTF8(argDescriptionsArray[j]);

                    var arg = new Argument()
                    {
                        Name = Marshal.PtrToStringAnsi(argNamesArray[j]),
                        TypeInfo = Marshal.PtrToStringAnsi(argTypeInfosArray[j]),
                        Description = Marshal.PtrToStringUTF8(argDescriptionsArray[j])
                    };

                    args.Add(arg);
                }
                info.Arguments = args;

                infos.Add(info);
            }

            return infos;
        }

        public static void Main(string[] args)
        {
            var infos = LoadSymbolInfo();

            var json = JsonConvert.SerializeObject(infos, Formatting.Indented);
            File.WriteAllText(args[0], json);
        }
    }
}
