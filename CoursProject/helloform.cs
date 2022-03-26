using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace CoursProject
{
    public partial class helloform : Form
    {
        private static System.Timers.Timer aTimer;
        public helloform()
        {
            TopMost = true;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        bool check = true;
        private void helloform_Load(object sender, EventArgs e)
        {
            if (check == true)
            {
                aTimer = new System.Timers.Timer(5000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
                check = false;
            }
        }

        private void helloform_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                aTimer.Stop();
                this.Hide();
                Form1 mainform = new Form1();
                mainform.Show();
            }));
            aTimer.Stop();
            aTimer.Enabled = false;
        }

        private void helloform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
