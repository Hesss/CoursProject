using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursProject
{
    public class Product
    {
        private String PName;
        private String Price;

        public Product(string n, string a)
        {
            PName = n;
            Price = a;
        }
        public string getPName()
        {
            return PName;
        }
        public string getPrice()
        {
            return Price;
        }
        public void setPName(string n)
        {
            PName = n;
        }
        public void setPrice(string a)
        {
            Price = a;
        }
        public override string ToString()
        {
            return "Название: " + PName + " -- Цена: " + Price;
        }
        public string Save()
        {
            return PName + "," + Price;
        }
    }
}
