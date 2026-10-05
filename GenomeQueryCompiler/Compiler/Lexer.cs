using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GenomeQueryCompiler.Compiler
{
    public class Lexer
    {
        private readonly HashSet<string> keywords =
            new HashSet<string>
            {
                "LOAD",
                "FIND",
                "MOTIF",
                "COUNT",
                "CODONS",
                "TRANSLATE",
                "MUTATE",
                "IN",
                "AT",
                "TO"
            };

        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();

            string pattern =
                "\"[^\"]*\"" +
                "|\\d+" +
                "|[A-Za-z_][A-Za-z0-9_]*";

            MatchCollection matches =
                Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string value = match.Value;

                if (keywords.Contains(value.ToUpper()))
                {
                    tokens.Add(
                        new Token(value, "KEYWORD"));
                }
                else if (Regex.IsMatch(value, "^\\d+$"))
                {
                    tokens.Add(
                        new Token(value, "NUMBER"));
                }
                else if (value.StartsWith("\""))
                {
                    tokens.Add(
                        new Token(value, "STRING"));
                }
                else
                {
                    tokens.Add(
                        new Token(value, "IDENTIFIER"));
                }
            }

            return tokens;
        }
    }
}