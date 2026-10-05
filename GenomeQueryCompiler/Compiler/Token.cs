using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeQueryCompiler.Compiler
{
    public class Token
    {
        public string Lexeme { get; set; }
        public string Type { get; set; }

        public Token(string lexeme, string type)
        {
            Lexeme = lexeme;
            Type = type;
        }
    }
}
