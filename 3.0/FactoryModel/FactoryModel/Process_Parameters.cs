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
        public struct Product_Amounts
        {
            // struct variables
            public Product product { get; private set; }
            public int process_value { get; private set; }

            // struct methods
            public void SetValue(Product set_product, int set_value)
            {
                product = set_product;
                process_value = set_value;
            }

            public Product_Amounts GetStruct()
            {
                return this;
            }

        }

        // variables
        public List<Product_Amounts> Input_pairs { get; }  // amounts of products required to start process
        public List<Product_Amounts> Output_pairs { get; } // amounts of products which are results of process
        public int cycle_time { get; }

        // methods
        public void AddInputPair(ref Product set_product, int set_value)
        {
            Product_Amounts p_a = new Product_Amounts();
            p_a.SetValue(set_product, set_value);
            Input_pairs.Add(p_a);
        }

        public void AddOutputPair(ref Product set_product, int set_value)
        {
            Product_Amounts p_a = new Product_Amounts();
            p_a.SetValue(set_product, set_value);
            Output_pairs.Add(p_a);
        }

        public int GetSizeListIn()
        {
            return Input_pairs.Count;
        }

        public int GetSizeListOut()
        {
            return Output_pairs.Count;
        }

        public Product_Amounts GetInProductAmount(int index)
        {
            return Input_pairs[index].GetStruct();
        }

        public Product_Amounts GetOutProductAmount(int index)
        {
            return Output_pairs[index].GetStruct();
        }

        
    }
}
