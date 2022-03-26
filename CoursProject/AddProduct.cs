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

namespace CoursProject // Окно AddProduct
{
    public partial class AddProduct : Form
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public AddProduct()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String Price = textBox1.Text;
            if (!Regex.Match(Price, "^[0-9]").Success)
            {
                MessageBox.Show("Цена товара некорректна");
                return;
            }
            String Bname = textBox2.Text;
            Product newProduct = new Product(Bname, Price);
            if (MyPharmacy.getAllproducts().Exists(x => (x.getPrice() == newProduct.getPrice()) && (x.getPName() == newProduct.getPName())))
            {
                MessageBox.Show("Такой товар уже существует");
                return;
            }
            else MyPharmacy.addProduct(newProduct);
            textBox3.Text = "Добавление прошло успешно";
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Price = textBox1.Text;
            if (!Regex.Match(Price, "^[0-9]").Success)
            {
                MessageBox.Show("Цена товара некорректна");
                return;
            }
            String PName = textBox2.Text;
            Product newProduct = new Product(PName, Price);
            if (MyPharmacy.getAllproducts().Exists(x => (x.getPrice() == newProduct.getPrice()) && (x.getPName() == newProduct.getPName())))
            {
                int i = MyPharmacy.getAllproducts().FindIndex(x => (x.getPrice() == newProduct.getPrice()) && (x.getPName() == newProduct.getPName()));
                MyPharmacy.getAllproducts().RemoveAt(i);
            }
            else
            {
                MessageBox.Show("Такого товара не существует");
                return;
            }
            textBox3.Text = "Удаление прошло успешно";
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }
    }
}
