using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKeyStroke
{
    
    public partial class Form1 : Form
    {
        String mess;
        int i = 0,
            pulse;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timer2.Start();
                int INterval = int.Parse(textBox1.Text);
                pulse = int.Parse(textBox3.Text);
                timer1.Interval = INterval * 100;
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("Enter all settings");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            i = 0;
        }
        int s = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                int startin = int.Parse(textBox4.Text);
                if (s >= startin)
                {
                    timer1.Start();
                    timer2.Stop();
                }
                s++;
            }
            catch
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = i.ToString();
            try
            {
                i++;
                mess = textBox2.Text;
                SendKeys.SendWait(mess);
                SendKeys.SendWait("{Enter}");
                
                if (i >= pulse)
                {
                    timer1.Stop();
                }
            }
            catch
            {

            }
        }
    }
}
