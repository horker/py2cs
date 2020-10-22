﻿using System;
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

    public class LocalConfig
    {
        public string Type { get; set; }
        public string Definition { get; set; } = null;
        public bool IsCType { get; set; } = false;
    }

    public class MethodConfig
    {
        public static readonly MethodConfig Empty = new MethodConfig();

        public bool Drop { get; set; } = false;
        public string Signature { get; set; } = string.Empty;
        public string SignatureSetter { get; set; } = string.Empty;
        public List<string> KeywordArguments { get; set; } = new List<string>(); // ??
        public List<string> Prologue { get; set; } = new List<string>();
        public Dictionary<string, LocalConfig> Locals { get; set; } = new Dictionary<string, LocalConfig>();
        public Dictionary<string, string> LocalAliases { get; set; } = new Dictionary<string, string>();

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
        public string Signature { get; set; }
        public bool Inherited { get; set; } = false;

        private string _name;
        private string _type;
        private bool _isStatic;

        public string Name
        {
            get
            {
                AnalyzeField();
                return _name;
            }
        }

        public string Type
        {
            get
            {
                AnalyzeField();
                return _type;
            }
        }

        public bool IsStatic
        {
            get
            {
                AnalyzeField();
                return _isStatic;
            }
        }

        private void AnalyzeField()
        {
            var re = new Regex(@"^\s*(?:(?:public|protected|internal|private|static)\s*)*\s+([\w\.]+(?:<\w+(?:,\s*\w+)*>)?\s*(?:\[\])?)\s*(\w+)\s*(?:{\s*get;(?:\s*set;)?\s*}\s*)?;?\s*$");
            var matches = re.Match(Signature);
            if (!matches.Success)
                throw new ArgumentException($"Signature analysis failed: {Signature}");
            var type = matches.Groups[1].Value.Trim();
            var name = matches.Groups[2].Value.Trim();

            _type = type;
            _name = name; ;
            _isStatic = false;
        }
    }

    public class ClassConfig
    {
        public static readonly ClassConfig Empty = new ClassConfig();
        public static readonly List<MethodConfig> MethodEmpty = new List<MethodConfig>(new[] { MethodConfig.Empty });

        public bool Drop { get; set; } = false;
        public string Name { get; set; } = "";
        public List<string> BaseClasses { get; set; } = new List<string>() { "object" };
        public Dictionary<string, FieldConfig> Fields { get; set; } = new Dictionary<string, FieldConfig>();
        public Dictionary<string, List<MethodConfig>> Methods { get; set; } = new Dictionary<string, List<MethodConfig>>();
        public List<string> SpecialMethods { get; set; } = new List<string>();
        public Dictionary<string, string> StaticVariableTypes { get; set; } = new Dictionary<string, string>();

        public List<MethodConfig> this[string funcName] => Methods.TryGetValue(funcName, out var f) ? f : MethodEmpty;

        private Dictionary<string, FieldConfig> _fieldConfig = new Dictionary<string, FieldConfig>();

        public string GetFieldTypeOf(string name)
        {
            if (StaticVariableTypes.TryGetValue(name, out var t))
                return t;

            if (Fields.TryGetValue(name, out var fc))
                return fc.Type;

            return null;
        }

    }

    public class Config
    {
        public List<string> UsingNamespaces { get; set; } = new List<string>();
        public string Namespace { get; set; }
        public Dictionary<string, List<string>> TypeNames { get; set; } = new Dictionary<string, List<string>>();

        public Dictionary<string, string> Replacements { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, ClassConfig> Classes { get; set; } = new Dictionary<string, ClassConfig>();

        public ClassConfig this[string className] => Classes.TryGetValue(className, out var c) ? c : ClassConfig.Empty;
    }
}
