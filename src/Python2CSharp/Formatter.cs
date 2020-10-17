using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Python2CSharp
{
    public class Formatter
    {
        private StringBuilder _out;
        private int _indent;
        private string _indentString;

        public int TabWidth { get; set; } = 4;

        public Formatter()
        {
            _out = new StringBuilder();
            _indent = 0;
            _indentString = "";
        }

        public string GetOutput()
        {
            return _out.ToString();
        }

        public void AddIndent(int indentChange)
        {
            if (indentChange == 0)
                return;

            _indent += indentChange;
            _indentString = new string(' ', _indent * TabWidth);
        }

        public void WriteIndent()
        {
            _out.Append(_indentString);
        }

        public void WriteNewLine()
        {
            _out.AppendLine();
            WriteIndent();
        }

        public void WriteLine(string s)
        {
            _out.Append(s);
            WriteNewLine();
        }

        public void Write(string s)
        {
            _out.Append(s);
        }

        public void WriteOpening(string s)
        {
            AddIndent(1);
            WriteLine(s);
        }

        public void WriteClosing(string s)
        {
            _out.Remove(_out.Length - TabWidth, TabWidth);
            AddIndent(-1);
            WriteLine(s);
        }
    }
}
