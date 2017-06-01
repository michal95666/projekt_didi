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

    enum Command_Type
    {
        none,
        give,       // to output warehouse
        take,        // to input warehouse
        call,       // to input warehouse - generate delivery event (extortion from ouput warehouse)
        stop       // to station - end process
    };

    class Coordinator_Command
    {
        // variables
        public Command_Type Type { get; private set; }
        public Station Sender_station { get; }           // from which station event was sent AND EVENTUALLY to which response should be sent
        public Station Receiver_station { get; }        // to which station event is guided to
        public Product Command_product { get; private set; }    // product which command is related to
        public int Amount_modification { get; private set; }   // how many should be added/subtracted in register with Command_product
        public bool Call_flag_modification { get; private set; }
        public int Execution_time { get; set; }                      // time after which command is executed
        // methods
        public Coordinator_Command(Command_Type set_type, Station set_sender, Station set_receiver, Product set_product, int set_amount, bool set_flag, int set_time)
        {
            Type = set_type;
            Sender_station = set_sender;
            Receiver_station = set_receiver;
            Command_product = set_product;
            Amount_modification = set_amount;
            Call_flag_modification = set_flag;
            Execution_time = set_time;
        }

    }

}
