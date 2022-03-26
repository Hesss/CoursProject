using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursProject
{
    public class Client
    {
        private String FIO;
        private List<Product> Myproducts;
        private int Age;
        private String Email;
        private String Phone;
        private String Passport;

        public Client(String fio, Product product, int age, String email, String phone, String passport)
        {
            this.FIO = fio;
            Myproducts = new List<Product>();
            this.Myproducts.Add(product);
            this.Age = age;
            this.Email = email;
            this.Phone = phone;
            this.Passport = passport;
        }

        public String getFIO()
        {
            return FIO;
        }

        public List<Product> getProducts(int i)
        {
            return Myproducts;
        }
        public String getProductstr()
        {
            String s = "";
            for (int i = 0; i < Myproducts.Count(); i++)
            {
                s += Myproducts[i].ToString() + "; ";
            }
            return s;
        }
        public int getAge()
        {
            return Age;
        }

        public String getEmail()
        {
            return Email;
        }

        public String getPhone()
        {
            return Phone;
        }

        public String getPassport()
        {
            return Passport;
        }

        public void addProduct(Product b)
        {
            Myproducts.Add(b);
        }
        public void setFIO(String fio)
        {
            this.FIO = fio;
        }

        public void setMyproducts(List<Product> l)
        {
            this.Myproducts = l;
        }

        public void setAge(int h)
        {
            this.Age = h;
        }

        public void setEmail(String f)
        {
            this.Email = f;
        }

        public void setPhone(String r)
        {
            this.Phone = r;
        }

        public void setPassport(String t)
        {
            this.Passport = t;
        }
        public string write()
        {
            string s = " Взятые товары: ";
            for (int i = 0; i < Myproducts.Count(); i++)
            {
                s += Myproducts[i].getPName() + " - " + Myproducts[i].getPrice();
                s += ",";
            }
            return s;
        }
        public string writeS()
        {
            string s = "";
            for (int i = 0; i < Myproducts.Count(); i++)
            {
                s += Myproducts[i].Save();
                s += ",";
            }
            return s;
        }

        public override bool Equals(object c)
        {
            Client obj = (Client)c;
            return this.FIO.Equals(obj.getFIO());
        }

        public override string ToString()
        {
            return FIO + "," + this.write() + "Возраст: " + Age.ToString() + ", Почта " + Email.ToString() + ", Телефон " +
                   Phone.ToString() + ", Паспорт: " + Passport.ToString();
        }
        public string Save()
        {
            return FIO + "," + this.writeS() + Age.ToString() + "," + Email.ToString() + "," +
                  Phone.ToString() + "," + Passport.ToString();
        }
    }
}

