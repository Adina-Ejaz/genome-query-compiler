using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeQueryCompiler.Compiler
{
    public class Executor
    {
        public string FindMotif(string seq, string motif)
        {
            seq = seq.Trim().ToUpper();
            motif = motif.Trim().ToUpper();

            List<int> pos = new List<int>();

            for (int i = 0; i <= seq.Length - motif.Length; i++)
            {
                if (seq.Substring(i, motif.Length) == motif)
                {
                    pos.Add(i + 1);
                }
            }

            return pos.Count > 0 ? string.Join(",", pos) : "Not Found";
        }

        public int CountCodons(string seq)
        {
            return seq.Length / 3;
        }

        public string Mutate(string seq, int pos, char c)
        {
            char[] arr = seq.ToCharArray();
            arr[pos - 1] = c;
            return new string(arr);
        }

        public string Translate(string seq)
        {
            Dictionary<string, string> codon = new Dictionary<string, string>()
            {
                {"ATG","M"},
                {"TTT","F"},
                {"TTC","F"}
            };

            string protein = "";

            for (int i = 0; i < seq.Length - 2; i += 3)
            {
                string c = seq.Substring(i, 3);
                if (codon.ContainsKey(c))
                    protein += codon[c];
                else
                    protein += "?";
            }

            return protein;
        }
    }
}
