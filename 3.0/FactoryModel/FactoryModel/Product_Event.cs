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
        collection_called,  // output warehouse calls input warehouse to call output warehouse:)
        process_started     // after timeout coordinator stops production
    };

    class Product_Event
    {
        // variables
        private Product_Event_Type type;
        private Product product;
        private Station receiver;
        private double timeout;             //after this time coordinator pass event to proper receiver
        private int amount;

        // methods
        public Product_Event(Product_Event_Type set_type, ref Product set_product, ref Station set_receiver, double set_timeout, int set_amount)
        {
            type = set_type;
            product = set_product;
            receiver = set_receiver;
            timeout = set_timeout;
            amount = set_amount;
        }
    }
}
