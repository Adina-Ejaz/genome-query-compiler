using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeQueryCompiler.Compiler
{
    public class Parser
    {
        private List<Token> tokens;
        private int pos = 0;

        public List<string> errors = new List<string>();
        private SymbolTable symbolTable;

        public Parser(List<Token> tokens, SymbolTable st)
        {
            this.tokens = tokens;
            this.symbolTable = st;
        }

        

        private Token Current()
        {
            if (pos < tokens.Count)
                return tokens[pos];
            return null;
        }

        private void Next() => pos++;

        public void Parse()
        {
            while (Current() != null)
            {
                Statement();
            }
        }

        private void Statement()
        {
            if (Current() == null) return;

            string cmd = Current().Lexeme.ToUpper();

            switch (cmd)
            {
                case "LOAD": Load(); break;
                case "FIND": Find(); break;
                case "COUNT": Count(); break;
                case "TRANSLATE": Translate(); break;
                case "MUTATE": Mutate(); break;
                default:
                    errors.Add("Unknown statement: " + Current().Lexeme);
                    Next();
                    break;
            }
        }

        private void Load()
        {
            Next(); // skip LOAD

            if (Current() == null || Current().Type != "IDENTIFIER")
            {
                errors.Add("Expected identifier after LOAD");
                return;
            }

            string name = Current().Lexeme;
            Next();

            if (Current() == null || Current().Type != "STRING")
            {
                errors.Add("Expected DNA string after identifier");
                return;
            }

            string value = Current().Lexeme.Replace("\"", "");
            Next();


            symbolTable.Add(name, value);
        }

        private void Find()
        {
            Next(); // FIND

            if (Current()?.Lexeme.ToUpper() != "MOTIF")
                errors.Add("Expected MOTIF");
            Next();

            if (Current()?.Type != "STRING")
                errors.Add("Expected STRING");
            Next();

            if (Current()?.Lexeme.ToUpper() != "IN")
                errors.Add("Expected IN");
            Next();

            if (Current()?.Type != "IDENTIFIER")
                errors.Add("Expected IDENTIFIER");
            Next();
        }

        private void Count()
        {
            Next(); // COUNT

            if (Current()?.Lexeme.ToUpper() != "CODONS")
                errors.Add("Expected CODONS");
            Next();

            if (Current()?.Lexeme.ToUpper() != "IN")
                errors.Add("Expected IN");
            Next();

            if (Current()?.Type != "IDENTIFIER")
                errors.Add("Expected IDENTIFIER");
            Next();
        }

        private void Translate()
        {
            Next();

            if (Current()?.Type != "IDENTIFIER")
                errors.Add("Expected IDENTIFIER");
            Next();
        }

        private void Mutate()
        {
            Next();

            if (Current()?.Type != "IDENTIFIER")
                errors.Add("Expected IDENTIFIER");
            Next();

            if (Current()?.Lexeme.ToUpper() != "AT")
                errors.Add("Expected AT");
            Next();

            if (Current()?.Type != "NUMBER")
                errors.Add("Expected NUMBER");
            Next();

            if (Current()?.Lexeme.ToUpper() != "TO")
                errors.Add("Expected TO");
            Next();

            if (Current()?.Type != "STRING")
                errors.Add("Expected STRING");
            Next();
        }
    }
}
