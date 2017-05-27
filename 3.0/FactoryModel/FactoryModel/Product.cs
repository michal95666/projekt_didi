using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Product
    {
        // variables
        private int id;
        private string name;

        // methods
        public Product(int set_id, string set_name)
        {
            id = set_id;
            name = set_name;
        }

        public void GetInfo()       //printing info to console is temporary; more likely to file
        {
            Console.WriteLine("Product ID: {0}", id);
            Console.WriteLine("Product name: {0}", name);
        }

    }
}
