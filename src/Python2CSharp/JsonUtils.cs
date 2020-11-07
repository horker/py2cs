using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Python2CSharp
{
    public static class JsonUtils
    {
        public static string ObjectNameOf(JToken node)
        {
            return node.Type == JTokenType.Object ? node["_Name"].Value<string>() : null;
        }

        public static string GetNameProperty(JToken node, string propertyName)
        {
            return node[propertyName].Value<string>().Trim('\'');
        }

        public static string GetNameId(JToken node)
        {
            return ObjectNameOf(node) == "Name" ? GetNameProperty(node, "id") : string.Empty;
        }

        private static readonly HashSet<string> _keywords = new HashSet<string>()
        {
            "params", "out", "this", "base"
        };

        public static string EscapeCsKeyword(string s)
        {
            return _keywords.Contains(s) ? "@" + s : s;
        }

        public static string StripQuotes(string s)
        {
            return s.Substring(1, s.Length - 2);
        }

        public static string ConvertToCamelCase(string s, bool upper)
        {
            if (string.IsNullOrWhiteSpace(s) || s == "_")
                return s;

            // Upper snake cases
            if (Regex.IsMatch(s, "^[A-Z0-9_]+$"))
                return s;

            // Special method names
            bool special = false;
            var m = Regex.Match(s, "^__(.+)__$");
            if (m.Success)
            {
                special = true;
                s = m.Groups[1].Value;
            }

            var words = s.Split(new[] { '_' }).Where(x => x.Length >= 1).ToArray();

            string result = null;
            if (upper && s.Length >= 2 && s[0] == '_' && char.IsLower(s[1]))
            {
                // member variables and private methods
                var capitalized = words.Skip(1).Select(x => char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = "_" + words[0] + string.Join("", capitalized);
            }
            else if (upper)
            {
                var capitalized = words.Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = string.Join("", capitalized);
            }
            else
            {
                var capitalized = words.Skip(1).Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = words[0] + string.Join("", capitalized);
            }

            if (special)
                return "__" + result + "__";
            return result;
        }

        public static string ConvertToSnakeCase(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s == "_")
                return s;

            // Upper snake cases
            if (Regex.IsMatch(s, "^[A-Z0-9_]+$"))
                return s;

            // Special method names
            bool special = false;
            var m = Regex.Match(s, "^__(.+)__$");
            if (m.Success)
            {
                special = true;
                s = m.Groups[1].Value;
            }

            var result = string.Join("_", Regex.Split(s, @"([A-Z][^A-Z]+)")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Length == 1 ? char.ToLower(x[0]).ToString() : char.ToLower(x[0]) + x.Substring(1)));

            if (special)
                return "__" + result + "__";
            return result;
        }

        public static string ConvertAsLocal(string s)
        {
            return EscapeCsKeyword(ConvertToCamelCase(s, false));
        }
    }
}
