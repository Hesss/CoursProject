using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursProject
{
    public class Pharmacy
    {
        private static List<Client> Clients = new List<Client>();
        private static List<Product> Allproducts = new List<Product>();
        public Pharmacy()
        {

        }
        public Pharmacy(List<Client> clients, List<Product> allproducts)
        {
            Clients = clients;
            Allproducts = allproducts;
        }
        public List<Client> getClients()
        {
            return Clients;
        }
        public List<Product> getAllproducts()
        {
            return Allproducts;
        }

        public void setClients(List<Client> c)
        {
            Clients = c;
        }
        public void setAllproducts(List<Product> a)
        {
            Allproducts = a;
        }
        public void addProduct(Product b)
        {
            Allproducts.Add(b);
        }
        public void addClient(Client c)
        {
            Clients.Add(c);
        }
    }
}
