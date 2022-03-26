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

namespace CoursProject // Окно Клиент
{
    public partial class AddClient : Form
    {
        public Pharmacy MyPharmacy = new Pharmacy();
        public AddClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") || textBox4.Text.Equals("")
                || textBox5.Text.Equals("") || textBox7.Text.Equals(""))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            String FIO = textBox1.Text;
            if (!Regex.Match(FIO, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
            {
                MessageBox.Show("ФИО некорректно");
                return;
            }
            int Age = Convert.ToInt32(textBox2.Text);
            if ((Convert.ToInt32(textBox2.Text) < 14) || (Convert.ToInt32(textBox2.Text) > 100))
            {
                MessageBox.Show("Некорректный возраст клиента! " +
                "Клиент должен быть старше 14 лет. И не старше 100");
                return;
            }
            String Email = textBox3.Text;
            if (!Regex.Match(Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}").Success)
            {
                MessageBox.Show("Некорректная почта");
                return;
            }
            String Phone = textBox4.Text;
            if (!Regex.Match(Phone, "^[0-9]").Success)
            {
                MessageBox.Show("Некорректный номер телефона");
                return;
            }
            String Passport = textBox5.Text;
            if (!Regex.Match(Passport, "^(([0-9]){10})$").Success)
            {
                MessageBox.Show("Некорректные паспортные данные");
                return;
            }
            String Price = textBox6.Text;  // 
            if (!Regex.Match(Price, "^[0-9]").Success)
            {
                MessageBox.Show("Цена товара некорректна");
                return;
            }
            String PName = textBox7.Text;
            Product newProduct = new Product(PName, Price);
            if (!MyPharmacy.getAllproducts().Exists(x => x.getPName() == newProduct.getPName()))
            {
                MessageBox.Show("Такого товара нет");
                return;
            }
            Client newClient = new Client(FIO, newProduct, Age, Email, Phone, Passport);
            if (MyPharmacy.getClients() != null)
            {
                if ((MyPharmacy.getClients().Exists(x => x.getPassport() == newClient.getPassport())))
                {
                    MessageBox.Show("Клиент уже существует, паспорт зарегестрирован");
                    return;
                }
                else MyPharmacy.addClient(newClient);
            }
            else MyPharmacy.addClient(newClient);
            textBox8.Text = "Добавление прошло успешно";
        }
        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void AddClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
