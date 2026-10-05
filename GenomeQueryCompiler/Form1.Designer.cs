namespace GenomeQueryCompiler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.RichTextBox();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.colLexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSymbols = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtICG = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.txtStep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbols)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(2, 1);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(795, 183);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = "";
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(359, 1);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(75, 23);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.Text = "button1";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(440, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "button2";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvTokens
            // 
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLexeme,
            this.colType});
            this.dgvTokens.Location = new System.Drawing.Point(548, 183);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.Size = new System.Drawing.Size(240, 124);
            this.dgvTokens.TabIndex = 3;
            this.dgvTokens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTokens_CellContentClick);
            // 
            // colLexeme
            // 
            this.colLexeme.HeaderText = "Lexeme";
            this.colLexeme.Name = "colLexeme";
            // 
            // colType
            // 
            this.colType.HeaderText = "Token Type";
            this.colType.Name = "colType";
            // 
            // dgvSymbols
            // 
            this.dgvSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.dataGridViewTextBoxColumn1,
            this.colValue});
            this.dgvSymbols.Location = new System.Drawing.Point(482, 303);
            this.dgvSymbols.Name = "dgvSymbols";
            this.dgvSymbols.Size = new System.Drawing.Size(306, 150);
            this.dgvSymbols.TabIndex = 4;
            this.dgvSymbols.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSymbols_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            // 
            // txtICG
            // 
            this.txtICG.Location = new System.Drawing.Point(145, 183);
            this.txtICG.Name = "txtICG";
            this.txtICG.Size = new System.Drawing.Size(187, 124);
            this.txtICG.TabIndex = 5;
            this.txtICG.Text = "";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(338, 183);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(213, 124);
            this.txtOutput.TabIndex = 6;
            this.txtOutput.Text = "";
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(164, 327);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(75, 23);
            this.btnNextStep.TabIndex = 7;
            this.btnNextStep.Text = "Next Step";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(260, 329);
            this.txtStep.Name = "txtStep";
            this.txtStep.ReadOnly = true;
            this.txtStep.Size = new System.Drawing.Size(100, 20);
            this.txtStep.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtStep);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtICG);
            this.Controls.Add(this.dgvSymbols);
            this.Controls.Add(this.dgvTokens);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.txtSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSource;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridView dgvSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.RichTextBox txtICG;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.TextBox txtStep;
    }
}

