using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursProject
{
    public partial class ReturnAll : Form
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public ReturnAll()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ReturnAll_Load(object sender, EventArgs e)
        {
            foreach (Client client in MyPharmacy.getClients())
            {
                dataGridView1.Rows.Add(client.getFIO(), client.getProductstr(), client.getAge(), client.getEmail(), client.getPhone(), client.getPassport());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void ReturnAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Client client in MyPharmacy.getClients())
            {
                if (client.getAge() >= 18)
                {
                    dataGridView1.Rows.Add(client.getFIO(), client.getProductstr(), client.getAge(), client.getEmail(), client.getPhone(), client.getPassport());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Client client in MyPharmacy.getClients())
            {
                if (client.getAge() < 18)
                {
                    dataGridView1.Rows.Add(client.getFIO(), client.getProductstr(), client.getAge(), client.getEmail(), client.getPhone(), client.getPassport());
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Client client in MyPharmacy.getClients())
            {
                dataGridView1.Rows.Add(client.getFIO(), client.getProductstr(), client.getAge(), client.getEmail(), client.getPhone(), client.getPassport());
            }
        }

    }
}
