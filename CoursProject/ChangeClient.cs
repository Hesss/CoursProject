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

namespace CoursProject // Окно ChangeClient
{
    public partial class ChangeClient : Form
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public ChangeClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChangeClient_Load(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (Client client in MyPharmacy.getClients())
            {
                string s = client.ToString();
                listBox.Items.Add(s);
            }
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MyPharmacy.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyPharmacy.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                textBox1.Text = MyPharmacy.getClients()[i].getFIO();
                if (textBox2.Text != "")
                {
                    int Age = Convert.ToInt32(textBox2.Text);
                    if ((Convert.ToInt32(textBox2.Text) < 14) || (Convert.ToInt32(textBox2.Text) > 100))
                    {
                        MessageBox.Show("Некорректный возраст клиента! " +
                        "Клиент должен быть старше 14 лет. И не старше 100");
                    }
                    else MyPharmacy.getClients()[i].setAge(Age);
                }
                if (textBox3.Text != "")
                {
                    String Email = textBox3.Text;
                    if (!Regex.Match(Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}").Success)
                    {
                        MessageBox.Show("Некорректная почта");
                        return;
                    }
                    else MyPharmacy.getClients()[i].setEmail(Email);
                }
                if (textBox4.Text != "")
                {
                    String Phone = textBox4.Text;
                    if (!Regex.Match(Phone, @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)").Success)
                    {
                        MessageBox.Show("Некорректный номер телефона");
                        return;
                    }
                    else MyPharmacy.getClients()[i].setPhone(Phone);
                }

                label12.Text = "Изменения успешны";
                listBox.Items.Clear();
                foreach (Client client in MyPharmacy.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Product product in MyPharmacy.getAllproducts())
                {
                    string s = product.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MyPharmacy.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyPharmacy.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                String Price = textBox6.Text;
                if (!Regex.Match(Price, "^[0-9]").Success)
                {
                    MessageBox.Show("Цена некорректна");
                    return;
                }
                String PName = textBox7.Text;
                Product newProduct = new Product(PName, Price);
                if (!MyPharmacy.getAllproducts().Exists(x => (x.getPrice() == newProduct.getPrice()) && (x.getPName() == newProduct.getPName())))
                {
                    MessageBox.Show("Такого товара нет");
                    return;
                }
                MyPharmacy.getClients()[i].addProduct(newProduct);
                label14.Text = "Товар добавлен успешно";
                listBox.Items.Clear();
                foreach (Client client in MyPharmacy.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Product product in MyPharmacy.getAllproducts())
                {
                    string s = product.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void ChangeClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MyPharmacy.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyPharmacy.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                MyPharmacy.getClients().RemoveAt(i);
                label12.Text = "Удаление успешно";
                listBox.Items.Clear();
                foreach (Client client in MyPharmacy.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Product product in MyPharmacy.getAllproducts())
                {
                    string s = product.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Product product in MyPharmacy.getAllproducts())
            {
                string s = product.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (Client client in MyPharmacy.getClients())
            {
                string s = client.ToString();
                listBox.Items.Add(s);
            }
        }
    }
}
