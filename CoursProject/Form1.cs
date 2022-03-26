using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursProject
{
    public partial class Form1 : Form // Окно Аптека
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public Form1()
        {
            TopMost = true;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddClient addform = new AddClient();
            addform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct addproductform = new AddProduct();
            addproductform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeClient changeclientform = new ChangeClient();
            changeclientform.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindProducts findproductsform = new FindProducts();
            findproductsform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnAll returnallform = new ReturnAll();
            returnallform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String str1 = "";
            for (int i = 0; i < MyPharmacy.getClients().Count; i++)
            {
                str1 = str1 + MyPharmacy.getClients()[i].Save() + "\n";
            }
            System.IO.File.WriteAllText("clients.txt", str1);

            String str2 = "";
            for (int i = 0; i < MyPharmacy.getAllproducts().Count; i++)
            {
                str2 = str2 + MyPharmacy.getAllproducts()[i].Save() + "\n";
            }
            System.IO.File.WriteAllText("products.txt", str2);
            MessageBox.Show("Сохранено");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyPharmacy.getAllproducts().Clear();
            string s;
            StreamReader f = new StreamReader("products.txt");
            while ((s = f.ReadLine()) != null)
            {
                string[] words = s.Split(new char[] { ',' });
                Product newProduct = new Product(words[0], words[1]);
                MyPharmacy.getAllproducts().Add(newProduct);
            }
            f.Close();
            MyPharmacy.getClients().Clear();
            string s1;
            StreamReader f1 = new StreamReader("clients.txt");
            while ((s1 = f1.ReadLine()) != null)
            {
                string[] words = s1.Split(new char[] { ',' });
                Product newProduct = new Product(words[1], words[2]);
                Client newClient = new Client(words[0], newProduct, Int32.Parse(words[3]), words[4], words[5], words[6]);
                MyPharmacy.getClients().Add(newClient);
            }
            f1.Close();
            MessageBox.Show("Загружено");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyPharmacy.getClients().Clear();
            System.IO.File.Delete(@"products.txt");
            System.IO.File.Delete(@"clients.txt");
            MyPharmacy.getAllproducts().Clear();
            MessageBox.Show("Удалено");
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}

