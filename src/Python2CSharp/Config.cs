using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Python2CSharp
{
    public class SignatureAnalysis
    {
        private string _returnType;
        private string _methodName;
        private Dictionary<string, string> _paramTypes;
        private bool _isProperty;

        public string Signature { get; set; }

        public SignatureAnalysis(string signature)
        {
            Signature = signature;
            AnalyzeSignature();
        }

        public string ReturnType
        {
            get
            {
                AnalyzeSignature();
                return _returnType;
            }
        }

        public string MethodName
        {
            get
            {
                AnalyzeSignature();
                return _methodName;
            }
        }

        public Dictionary<string, string> ParamTypes
        {
            get
            {
                AnalyzeSignature();
                return _paramTypes;
            }
        }

        public bool IsProperty
        {
            get
            {
                AnalyzeSignature();
                return _isProperty;
            }
        }

        private void AnalyzeSignature()
        {
            if (_paramTypes != null)
                return;

            _paramTypes = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(Signature))
                return;

            var signatureRe = new Regex(@"^(?:(?:public|protected|internal|private|static|override|virtual)\s*)*\s+(?:(\w+(?:<[^>]+>+)?(?:\[\])?)\s+)?(\w+)(\(.*\))?$");
            var matches = signatureRe.Match(Signature);
            if (!matches.Success)
                throw new ArgumentException($"Signature analysis failed: {Signature}");

            _returnType = matches.Groups[1].Value;
            _methodName = matches.Groups[2].Value;
            var parameters = matches.Groups[3].Value;

            if (string.IsNullOrWhiteSpace(parameters))
            {
                _isProperty = true;
                return;
            }

            if (parameters.Length == 2)
                return;

            var paramRe = new Regex(@"(?:params\s+)?(\w+(?:<\w+(?:,\s*\w+)*>)?\s*(?:\[\])?)\s*@?(\w+)(?:,\s*(?:params\s+)?(\w+(?:<\w+(?:,\s*\w+)*>)?\s*(?:\[\])?)\s*@?(\w+))*");
            matches = paramRe.Match(parameters.Substring(1, parameters.Length - 2));
            if (!matches.Success)
                throw new ArgumentException($"Signature analysis failed: {parameters}");

            for (var i = 1; i < matches.Groups.Count; i += 2)
            {
                var type = matches.Groups[i].Value.Trim();
                var name = matches.Groups[i + 1].Value.Trim();
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                _paramTypes.Add(name, type);
            }
        }
    }

    public class MethodConfig
    {
        public static readonly MethodConfig Empty = new MethodConfig();

        public bool Drop { get; set; } = false;
        public string Signature { get; set; } = string.Empty;
        public string SignatureSetter { get; set; } = string.Empty;
        public List<string> KeywordArguments { get; set; } = new List<string>();
        public List<string> Prologue { get; set; } = new List<string>();

        private SignatureAnalysis _signatureAnalysis;
        private SignatureAnalysis _signatureSetterAnalysis;

        public SignatureAnalysis SignatureAnalysis
        {
            get
            {
                if (_signatureAnalysis == null)
                    _signatureAnalysis = new SignatureAnalysis(Signature);
                return _signatureAnalysis;
            }
        }

        public SignatureAnalysis SignatureSetterAnalysis
        {
            get
            {
                if (_signatureSetterAnalysis == null)
                    _signatureSetterAnalysis = new SignatureAnalysis(SignatureSetter);
                return _signatureSetterAnalysis;
            }
        }
    }

    public class FieldConfig
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsStatic { get; set; }
    }

    public class ClassConfig
    {
        public static readonly ClassConfig Empty = new ClassConfig();

        public bool Drop { get; set; } = false;
        public string Name { get; set; } = "";
        public string Base { get; set; } = "object";
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, MethodConfig> Methods { get; set; } = new Dictionary<string, MethodConfig>();
        public List<string> SpecialMethods { get; set; } = new List<string>();
        public Dictionary<string, string> StaticVariableTypes { get; set; } = new Dictionary<string, string>();

        public MethodConfig this[string funcName] => Methods.TryGetValue(funcName, out var f) ? f : MethodConfig.Empty;

        private Dictionary<string, FieldConfig> _fieldConfig = new Dictionary<string, FieldConfig>();

        public FieldConfig GetFieldConfig(string name)
        {
            if (_fieldConfig.TryGetValue(name, out var config))
                return config;

            if (StaticVariableTypes.TryGetValue(name, out var t))
            {
                config = new FieldConfig()
                {
                    Type = t,
                    Name = name,
                    IsStatic = true
                };
            }
            else
            {
                if (Fields.TryGetValue(name, out var def))
                    config = AnalyzeField(def);
                else
                    return null;
            }

            _fieldConfig[name] = config;
            return config;
        }

        public string GetFieldTypeOf(string name)
        {
            return GetFieldConfig(name)?.Type;
        }

        private FieldConfig AnalyzeField(string definition)
        {
            var re = new Regex(@"^\s*(?:(?:public|protected|internal|private|static)\s*)*\s+([\w\.]+(?:<\w+(?:,\s*\w+)*>)?\s*(?:\[\])?)\s*(\w+)\s*;\s*$");
            var matches = re.Match(definition);
            if (!matches.Success)
                throw new ArgumentException($"Definition analysis failed: {definition}");
            var type = matches.Groups[1].Value.Trim();
            var name = matches.Groups[2].Value.Trim();

            return new FieldConfig()
            {
                Type = type,
                Name = name,
                IsStatic = false
            };
        }
    }

    public class Config
    {
        public List<string> UsingNamespaces { get; set; } = new List<string>();
        public string Namespace { get; set; }

        public Dictionary<string, string> Replacements { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, ClassConfig> Classes { get; set; } = new Dictionary<string, ClassConfig>();

        public ClassConfig this[string className] => Classes.TryGetValue(className, out var c) ? c : ClassConfig.Empty;
    }
}
