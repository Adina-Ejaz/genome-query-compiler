using GenomeQueryCompiler.Compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;

namespace GenomeQueryCompiler
{
    public partial class Form1 : Form
    {
        List<string> icg = new List<string>();
        int icgPointer = 0;
        SymbolTable symbolTable = new SymbolTable();
        Executor executor = new Executor();
        Dictionary<string, string> tempStore = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            // 1. LEXER
            Lexer lexer = new Lexer();
            var tokens = lexer.Tokenize(txtSource.Text);

            dgvTokens.Rows.Clear();

            foreach (var t in tokens)
                dgvTokens.Rows.Add(t.Lexeme, t.Type);

            // 2. PARSER
            Parser parser = new Parser(tokens, symbolTable);
            parser.Parse();
            

            txtOutput.Clear();
            txtICG.Clear();

            icg.Clear();

            if (parser.errors.Count == 0)
            {
                txtOutput.Text = "Syntax Correct";

                GenerateICG(tokens);
                UpdateSymbolTableGrid();
            }

            else
                foreach (var err in parser.errors)
                    txtOutput.AppendText(err + "\n");
        }
        private void GenerateICG(List<Token> tokens)
        {
            int tempCount = 1;

            for (int i = 0; i < tokens.Count; i++)
            {
                string lex = tokens[i].Lexeme.ToUpper();

                // LOAD
                if (lex == "LOAD")
                {
                    string id = tokens[i + 1].Lexeme;
                    string value = tokens[i + 2].Lexeme.Replace("\"", "").ToUpper();

                    if (!IsValidDNA(value))
                    {
                        icg.Add($"ERROR: Invalid DNA sequence in {id}");
                        txtOutput.AppendText($"Error: {id} contains invalid DNA bases\n");
                        continue;
                    }

                    string t = "t" + tempCount++;

                    icg.Add($"{t} = {value}");
                    icg.Add($"{id} = {t}");
                }

                // FIND MOTIF
                else if (lex == "FIND")
                {
                    string motif = tokens[i + 2].Lexeme;
                    string seq = tokens[i + 4].Lexeme;

                    string t1 = "t" + tempCount++;
                    string t2 = "t" + tempCount++;

                    icg.Add($"{t1} = {seq}");
                    icg.Add($"{t2} = {motif}");
                    icg.Add($"t{tempCount++} = FIND_MOTIF {t1}, {t2}");
                }

                // COUNT CODONS
                else if (lex == "COUNT")
                {
                    string seq = tokens[i + 3].Lexeme;

                    string t1 = "t" + tempCount++;
                    icg.Add($"{t1} = {seq}");
                    icg.Add($"t{tempCount++} = COUNT_CODONS {t1}");
                }

                // TRANSLATE
                else if (lex == "TRANSLATE")
                {
                    string seq = tokens[i + 1].Lexeme;

                    string t1 = "t" + tempCount++;
                    icg.Add($"{t1} = {seq}");
                    icg.Add($"t{tempCount++} = TRANSLATE {t1}");
                }

                // MUTATE
                else if (lex == "MUTATE")
                {
                    string seq = tokens[i + 1].Lexeme;
                    string pos = tokens[i + 3].Lexeme;
                    string val = tokens[i + 5].Lexeme;

                    string t1 = "t" + tempCount++;
                    string t2 = "t" + tempCount++;

                    icg.Add($"{t1} = {seq}");
                    icg.Add($"{t2} = MUTATE {t1}, {pos}, {val}");
                    icg.Add($"{seq} = {t2}");
                }
            }

            foreach (var line in icg)
                txtICG.AppendText(line + "\n");
            icgPointer = 0;
            txtStep.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 1. CLEAR INPUT
            txtSource.Clear();

            // 2. CLEAR OUTPUT AREAS
            txtOutput.Clear();
            txtICG.Clear();
            txtStep.Clear();

            // 3. CLEAR TABLES
            dgvTokens.Rows.Clear();
            dgvSymbols.Rows.Clear();

            // 4. CLEAR COMPILER DATA
            icg.Clear();
            icgPointer = 0;

            symbolTable = new SymbolTable();
            tempStore.Clear();

            // 5. OPTIONAL: reset executor state (safe reset)
            executor = new Executor();

            // 6. OPTIONAL: UX reset
            txtStep.Text = "Ready for new query";
            txtSource.Focus();
        }

        private void dgvTokens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSymbols_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ===== FORM =====
            this.Text = "Genome Query Compiler";
            this.BackColor = Color.FromArgb(0, 26, 44);
            this.Font = new Font("Century Gothic", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1200, 820);

            // ===== SOURCE EDITOR =====
            txtSource.Location = new Point(20, 40);
            txtSource.Size = new Size(1140, 220);

            txtSource.BackColor = Color.FromArgb(0, 22, 41);
            txtSource.ForeColor = Color.White;
            txtSource.Font = new Font("Consolas", 10);

            // ===== BUTTONS =====

            btnCompile.Text = "Compile";
            btnCompile.Location = new Point(20, 280);
            btnCompile.Size = new Size(120, 40);

            btnCompile.BackColor = Color.FromArgb(43, 111, 134);
            btnCompile.ForeColor = Color.White;
            btnCompile.FlatStyle = FlatStyle.Flat;
            btnCompile.FlatAppearance.BorderSize = 0;

            btnClear.Text = "Clear";
            btnClear.Location = new Point(150, 280);
            btnClear.Size = new Size(120, 40);

            btnClear.BackColor = Color.FromArgb(122, 149, 163);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;

            btnNextStep.Text = "Execute Step";
            btnNextStep.Location = new Point(280, 280);
            btnNextStep.Size = new Size(140, 40);

            btnNextStep.BackColor = Color.FromArgb(43, 111, 134);
            btnNextStep.ForeColor = Color.White;
            btnNextStep.FlatStyle = FlatStyle.Flat;
            btnNextStep.FlatAppearance.BorderSize = 0;

            // ===== STEP COUNTER =====

            txtStep.Location = new Point(520, 290);
            txtStep.Size = new Size(120, 25);

            txtStep.BackColor = Color.White;
            txtStep.ForeColor = Color.Black;

            // ===== ICG BOX =====

            txtICG.Location = new Point(20, 350);
            txtICG.Size = new Size(350, 220);

            txtICG.BackColor = Color.FromArgb(122, 149, 163);
            txtICG.ForeColor = Color.Black;
            txtICG.Font = new Font("Consolas", 9);

            // ===== OUTPUT BOX =====

            txtOutput.Location = new Point(390, 350);
            txtOutput.Size = new Size(350, 220);

            txtOutput.BackColor = Color.FromArgb(122, 149, 163);
            txtOutput.ForeColor = Color.Black;
            txtOutput.Font = new Font("Consolas", 9);

            // ===== TOKENS TABLE =====

            dgvTokens.Location = new Point(760, 350);
            dgvTokens.Size = new Size(400, 220);

            dgvTokens.BackgroundColor = Color.FromArgb(122, 149, 163);
            dgvTokens.BorderStyle = BorderStyle.None;

            dgvTokens.EnableHeadersVisualStyles = false;

            dgvTokens.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 26, 44);

            dgvTokens.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvTokens.DefaultCellStyle.BackColor =
                Color.FromArgb(122, 149, 163);

            dgvTokens.DefaultCellStyle.ForeColor =
                Color.Black;

            dgvTokens.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTokens.RowHeadersVisible = false;

            // ===== SYMBOL TABLE =====

            dgvSymbols.Location = new Point(20, 600);
            dgvSymbols.Size = new Size(1140, 180);

            dgvSymbols.BackgroundColor = Color.FromArgb(122, 149, 163);
            dgvSymbols.BorderStyle = BorderStyle.None;

            dgvSymbols.EnableHeadersVisualStyles = false;

            dgvSymbols.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 26, 44);

            dgvSymbols.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvSymbols.DefaultCellStyle.BackColor =
                Color.FromArgb(122, 149, 163);

            dgvSymbols.DefaultCellStyle.ForeColor =
                Color.Black;

            dgvSymbols.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSymbols.RowHeadersVisible = false;

            // ===== LABELS =====

            Color labelColor = Color.White;

            Label lblSource = new Label();
            lblSource.Text = "Genome Query Input";
            lblSource.Location = new Point(20, 15);
            lblSource.ForeColor = labelColor;
            lblSource.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            lblSource.AutoSize = true;

            Label lblICG = new Label();
            lblICG.Text = "Intermediate Code";
            lblICG.Location = new Point(20, 325);
            lblICG.ForeColor = labelColor;
            lblICG.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lblICG.AutoSize = true;

            Label lblOutput = new Label();
            lblOutput.Text = "Compiler Output";
            lblOutput.Location = new Point(390, 325);
            lblOutput.ForeColor = labelColor;
            lblOutput.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lblOutput.AutoSize = true;

            Label lblTokens = new Label();
            lblTokens.Text = "Tokens";
            lblTokens.Location = new Point(760, 325);
            lblTokens.ForeColor = labelColor;
            lblTokens.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lblTokens.AutoSize = true;

            Label lblSymbols = new Label();
            lblSymbols.Text = "Symbol Table";
            lblSymbols.Location = new Point(20, 575);
            lblSymbols.ForeColor = labelColor;
            lblSymbols.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lblSymbols.AutoSize = true;

            Label lblStep = new Label();
            lblStep.Text = "Current Step:";
            lblStep.Location = new Point(420, 292);
            lblStep.ForeColor = Color.White;
            lblStep.AutoSize = true;

            this.Controls.Add(lblSource);
            this.Controls.Add(lblICG);
            this.Controls.Add(lblOutput);
            this.Controls.Add(lblTokens);
            this.Controls.Add(lblSymbols);
            this.Controls.Add(lblStep);
        }
        private void UpdateSymbolTableGrid()
        {
            dgvSymbols.Rows.Clear();

            foreach (var s in symbolTable.Symbols)
            {
                dgvSymbols.Rows.Add(s.Key, s.Value.Type, s.Value.Value);
            }
        }
        
        private void ExecuteICGLine(string line)
        {
            // ---------------------------
            // 1. ASSIGNMENT (t1 = value)
            // ---------------------------
            if (line.Contains("=") && !line.Contains("FIND_MOTIF") && !line.Contains("COUNT_CODONS") && !line.Contains("TRANSLATE") && !line.Contains("MUTATE"))
            {
                string[] parts = line.Split('=');

                string left = parts[0].Trim();
                string right = parts[1].Trim().Replace("\"", "");
                if (!tempStore.ContainsKey(right) && !symbolTable.Symbols.ContainsKey(right))
                {
                    // if it's raw DNA, validate it
                    if (!IsValidDNA(right))
                    {
                        txtOutput.AppendText($"Error: Invalid DNA sequence {right}\n");
                        return;
                    }
                }

                // Resolve references
                if (tempStore.ContainsKey(right))
                {
                    right = tempStore[right];
                }
                else if (symbolTable.Symbols.ContainsKey(right))
                {
                    right = symbolTable.Symbols[right].Value;
                }

                tempStore[left] = right;

                // Update symbol table
                if (!symbolTable.Symbols.ContainsKey(left))
                {
                    symbolTable.Add(left, right);
                }
                else
                {
                    symbolTable.Symbols[left].Value = right;
                }

                txtOutput.AppendText($"{left} = {right}\n");
                UpdateSymbolTableGrid();
                return;
            }

            // ---------------------------
            // 2. FIND MOTIF (FIXED)
            // ---------------------------
            else if (line.Contains("FIND_MOTIF"))
            {
                try
                {
                    string[] tokens = line.Split(',');

                    // t3 = FIND_MOTIF t1, t2
                    string seqPart = tokens[0];
                    string motifPart = tokens[1];

                    string seqKey = seqPart.Split('=')[1].Trim().Split(' ')[1].Trim();
                    string motifKey = motifPart.Replace("\"", "").Trim();

                    // resolve sequence
                    string seqValue =
                        tempStore.ContainsKey(seqKey)
                        ? tempStore[seqKey]
                        : symbolTable.Symbols[seqKey].Value;

                    // resolve motif
                    string motifValue =
                        tempStore.ContainsKey(motifKey)
                        ? tempStore[motifKey]
                        : motifKey;

                    string result = executor.FindMotif(seqValue, motifValue);

                    txtOutput.AppendText($"Motif found at: {result}\n");
                }
                catch (Exception ex)
                {
                    txtOutput.AppendText("Runtime Error: " + ex.Message + "\n");
                }
                return;
            }

            // ---------------------------
            // 3. COUNT CODONS (FIXED)
            // ---------------------------
            else if (line.Contains("COUNT_CODONS"))
            {
                string seq = line.Split(' ')[3];

                string value =
                    tempStore.ContainsKey(seq)
                    ? tempStore[seq]
                    : symbolTable.Symbols[seq].Value;

                int count = executor.CountCodons(value);

                txtOutput.AppendText($"Codons: {count}\n");
                return;
            }

            // ---------------------------
            // 4. TRANSLATE (FIXED)
            // ---------------------------
            else if (line.Contains("TRANSLATE"))
            {
                string seq = line.Split(' ')[3];

                string value =
                    tempStore.ContainsKey(seq)
                    ? tempStore[seq]
                    : symbolTable.Symbols[seq].Value;

                string protein = executor.Translate(value);

                txtOutput.AppendText($"Protein: {protein}\n");
                return;
            }

            // ---------------------------
            // 5. MUTATE (FIXED)
            // ---------------------------
            else if (line.Contains("MUTATE"))
            {
                string[] tokens = line.Split(',');

                string tempVar = tokens[0].Split('=')[0].Trim(); // t3
                string seq = tokens[0].Split(' ')[3];            // t2
                int pos = int.Parse(tokens[1]);
                string val = tokens[2].Replace("\"", "").Trim();

                string value =
                    tempStore.ContainsKey(seq)
                    ? tempStore[seq]
                    : symbolTable.Symbols[seq].Value;

                string result = executor.Mutate(value, pos, val[0]);

                // store result in temp variable
                tempStore[tempVar] = result;

                // IMPORTANT: DO NOT guess updates
                txtOutput.AppendText($"Mutated sequence: {result}\n");
                UpdateSymbolTableGrid();
                return;
            }
        }
        private bool IsValidDNA(string seq)
        {
            foreach (char c in seq.ToUpper())
            {
                if (c != 'A' && c != 'T' && c != 'C' && c != 'G')
                    return false;
            }
            return true;
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (icgPointer >= icg.Count)
            {
                txtStep.Text = "Execution Completed";
                return;
            }

            string line = icg[icgPointer];
            txtStep.Text = line;

            ExecuteICGLine(line);

            icgPointer++;
        }
    }
}
