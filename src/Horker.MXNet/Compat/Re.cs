using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Horker.MXNet.Compat
{
    public class Re
    {
        private Regex _pattern;

        public Re(string pattern)
        {
            _pattern = new Regex(pattern);
        }

        public static Re Compile(string pattern)
        {
            return new Re(pattern);
        }

        public bool Match(string input)
        {
            return _pattern.Match(input).Success;
        }
    }
}
