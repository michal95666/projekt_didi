using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Process_Parameters
    {
        // definition of structure to store data
        struct Product_Amounts
        {
            private Product product;
            private int process_value;

            public void SetValue(Product set_product, int set_value)
            {
                product = set_product;
                process_value = set_value;
            }
        }

        // variables
        private List<Product_Amounts> input_pairs;  // amounts of products required to start process
        private List<Product_Amounts> output_pairs; // amounts of products which are results of process
        private double process_time;

        // methods
        public void AddInputPair(ref Product set_product, int set_value)
        {
            Product_Amounts p_a = new Product_Amounts();
            p_a.SetValue(set_product, set_value);
            input_pairs.Add(p_a);
        }

        public void AddOutputPair(ref Product set_product, int set_value)
        {
            Product_Amounts p_a = new Product_Amounts();
            p_a.SetValue(set_product, set_value);
            output_pairs.Add(p_a);
        }


    }
}
