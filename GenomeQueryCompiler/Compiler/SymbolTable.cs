using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeQueryCompiler.Compiler
{
    
    public class SymbolTable
    {
        public Dictionary<string, Symbol>
            Symbols =
            new Dictionary<string, Symbol>();

        public void Add(
            string name,
            string value)
        {
            Symbols[name] =
                new Symbol
                {
                    Name = name,
                    Type = "DNA",
                    Value = value
                };
        }
    }
}
