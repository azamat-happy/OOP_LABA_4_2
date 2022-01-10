using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LABA
{
    public partial class Form1 : Form
    {
        Model calculate;
        public Form1()
        {
            calculate = new Model();
            trackBar1.Maximum = 100;
            trackBar2.Maximum = 100;
            trackBar3.Maximum = 100;
            calculate.calculated += UpdateLabels;


            textBox1.KeyDown += new KeyEventHandler(delegate (Object o, KeyEventArgs a)
            {
                if (a.KeyCode == Keys.Enter)
                {
                    calculate.A = int.Parse(textBox1.Text);
                }
            });
            numericUpDown1.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.A = (int)numericUpDown1.Value;
            });
            trackBar1.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.A = trackBar1.Value;
            });

            textBox2.KeyDown += new KeyEventHandler(delegate (Object o, KeyEventArgs a)
            {
                if (a.KeyCode == Keys.Enter)
                {
                    calculate.B = int.Parse(textBox2.Text);
                }
            });
            numericUpDown2.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.B = (int)numericUpDown2.Value;
            });
            trackBar2.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.B = trackBar2.Value;
            });

            textBox3.KeyDown += new KeyEventHandler(delegate (Object o, KeyEventArgs a)
            {
                if (a.KeyCode == Keys.Enter)
                {
                    calculate.C = int.Parse(textBox3.Text);
                }
            });
            numericUpDown3.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.C = (int)numericUpDown3.Value;
            });
            trackBar3.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                calculate.C = trackBar3.Value;
            });
        }
        private void UpdateLabels(Object sender, EventArgs e)
        {
            textBox1.Text = calculate.A.ToString();
            numericUpDown1.Value = calculate.A;
            trackBar1.Value = calculate.A;

            textBox2.Text = calculate.B.ToString();
            numericUpDown2.Value = calculate.B;
            trackBar2.Value = calculate.B;

            textBox3.Text = calculate.C.ToString();
            numericUpDown3.Value = calculate.C;
            trackBar3.Value = calculate.C;
        }
    }
}