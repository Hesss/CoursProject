using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursProject
{
    public partial class FindProducts : Form
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public FindProducts()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FindProducts_Load(object sender, EventArgs e)
        {
            list.Items.Clear();
            foreach (Product products in MyPharmacy.getAllproducts())
            {
                string s = products.ToString();
                list.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
                String PName = textBox2.Text;
                list.Items.Clear();
                foreach (Product products in MyPharmacy.getAllproducts())
                {
                    if (products.getPName() == PName)
                    {
                        s = products.ToString();
                        list.Items.Add(s);
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Items.Clear();
            foreach (Product products in MyPharmacy.getAllproducts())
            {
                string s = products.ToString();
                list.Items.Add(s);
            }
        }

        private void FindProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
