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
        String message;
        int i = 0, pulse;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timer2.Start();
                int interval = int.Parse(txt_interval.Text);
                pulse = int.Parse(txt_count.Text);
                timer1.Interval = interval * 100;
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("Enter all settings");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "Force Stop";
            timer1.Stop();
            i = 0;
            timer1.Enabled = false;
        }
        int s = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                
                int startin = int.Parse(txt_startin.Text);
                label6.Text = "Start typing in " + ( startin - s ).ToString();
                if (s >= startin)
                {
                    timer1.Enabled = true;
                    
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
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = i.ToString() + " of " + pulse.ToString();
            try
            {
                i++;
                message = txt_textToType.Text;

                SendKeys.SendWait(message + "{Enter}");
                
                if (i >= pulse)
                {
                    label6.Text = "Finished";
                    timer1.Stop();
                    i = 0;
                    timer1.Enabled = false;
                }
            }
            catch
            {

            }
        }
    }
}
