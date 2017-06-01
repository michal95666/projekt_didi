using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    // definition of enumerator
    enum Product_Event_Type
    {
        none,
        delivery_called,    // input warehouse calls output warehouse above
        delivery_arrived,   // to input warehouse
        collection_called,  // output warehouse calls input warehouse to call output warehouse :)
        process_started     // after timeout coordinator stops production
    };

    class Product_Event
    {
        // variables
        public Product_Event_Type Event_type { get; }
        public Product Event_product { get; }            // null if type process_started
        public Station Sender_station { get; }           // from which station event was sent AND EVENTUALLY to which response should be sent
        public Station Receiver_station { get; }        // to which station event is guided to
        public int Timeout { get; set; }             //after this time coordinator pass event to proper receiver
        public int Amount { get; }

        // methods
        public Product_Event(Product_Event_Type set_type, ref Product set_product, Station set_sender, ref Station set_receiver, int set_timeout, int set_amount)
        {
            Event_type = set_type;
            Event_product = set_product;
            Sender_station = set_sender;
            Receiver_station = set_receiver;
            Timeout = set_timeout;
            Amount = set_amount;
        }
    }
}
