using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    enum Warehouse_Type
    {
        none,
        input,
        output
    };

    class Coordinator_Command
    {
        // variables
        public Product Command_product { get; private set; }
        public int Change_actual_amount { get; private set; }   // how many should be added/subtracted in register with Which_product
        public bool Change_call_flag { get; private set; }
        public Warehouse_Type Which_warehouse { get; private set; }
        public int Execution_time { get; }      // time after which command is executed
        // methods
        public Coordinator_Command(Product set_product, int set_amount, bool set_flag, Warehouse_Type set_warehouse)
        {
            Command_product = set_product;
            Change_actual_amount = set_amount;
            Change_call_flag = set_flag;
            Which_warehouse = set_warehouse;
        }

    }
}
