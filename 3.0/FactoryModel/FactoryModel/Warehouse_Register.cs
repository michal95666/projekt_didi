using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Warehouse_Register
    {
        // variables
        public Station Reg_station { get; private set; }
        public Product Reg_product { get; private set; }
        public int Actual_amount { get; set; }
        public int Max_amount { get; private set; }
        public int Min_amount { get; private set; }
        public int Upper_warning { get; private set; }
        public int Lower_warning { get; private set; }
        public double Call_time { get; private set; }
        public double Delivery_time { get; private set; }
        public bool Call_flag { get; set; }

        // methods
        public Warehouse_Register(ref Station set_station, ref Product set_product)
        {
            Reg_station = set_station;
            Reg_product = set_product;
        }

        public void SetParameters(int set_max_amount, int set_min_amount, int set_upper_warning, int set_lower_warning)
        {
            Max_amount = set_max_amount;
            Min_amount = set_min_amount;
            Upper_warning = set_upper_warning;
            Lower_warning = set_lower_warning;
        }

        public void SetParameters(int set_max_amount, int set_min_amount, int set_upper_warning, int set_lower_warning, double set_call_time, double set_delivery_time)
        {
            Max_amount = set_max_amount;
            Min_amount = set_min_amount;
            Upper_warning = set_upper_warning;
            Lower_warning = set_lower_warning;
            Call_time = set_call_time;
            Delivery_time = set_delivery_time;
        }

    }
}
