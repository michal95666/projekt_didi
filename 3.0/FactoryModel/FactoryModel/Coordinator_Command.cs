using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Coordinator_Command
    {
        // variables
        public int Change_actual_amount { get; private set; }
        public bool Change_call_flag { get; private set; }

        // methods
        public Coordinator_Command(int set_amount, bool set_flag)
        {
            Change_actual_amount = set_amount;
            Change_call_flag = set_flag;
        }

    }
}
