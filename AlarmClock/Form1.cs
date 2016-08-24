using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer_now.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.label1.Text = DateTime.Now.ToString("hh:mm ss");
            lblCurrent.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblSet.Text = mtxtBox.Text;
            mtxtBox.Text = "";
            timer_set.Start();
        }

        private void timer_set_Tick(object sender, EventArgs e)
        {
            if (lblSet.Text == lblCurrent.Text)
            {
                MessageBox.Show("Alarm!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer_set.Stop();
            lblSet.Text = "00:00:00";
        }
    }
}
