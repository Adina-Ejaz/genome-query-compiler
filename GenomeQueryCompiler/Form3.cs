using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenomeQueryCompiler
{
    public partial class Form3 : Form
    {
        Timer timer = new Timer();
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer.Interval = 3000;
            timer.Tick += timer_Tick;// 3 seconds
            timer.Start();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Form1 main = new Form1();
            main.Show();
            this.Hide();

            

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
