using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Station
    {
        // variables - all Station data
        private List<Warehouse_Register> input_warehouse;
        private List<Warehouse_Register> output_warehouse;
        private Process_Parameters station_parameters;
        public bool Enabled { get; set; }

        // methods
        public List<Product_Event> Action(List<Coordinator_Command> commands)
        {
            if (Enabled)
            {
                // perform actions from passed coordinator commands here!

                List<Product_Event> list_tosend = new List<Product_Event>();
                for (int in_register = 0; in_register < input_warehouse.Count; in_register++)
                {
                    if (input_warehouse[in_register].Actual_amount <= input_warehouse[in_register].Lower_warning)
                    {
                        Product product_tosend = input_warehouse[in_register].Reg_product;
                        Station station_tosend = input_warehouse[in_register].Reg_station;
                        Product_Event event_tosend = new Product_Event(Product_Event_Type.delivery_called,
                                                                       ref product_tosend,
                                                                       ref station_tosend,
                                                                       input_warehouse[in_register].Call_time,
                                                                       input_warehouse[in_register].Max_amount - input_warehouse[in_register].Actual_amount);
                        list_tosend.Add(event_tosend);
                    }
                }
                for (int out_register = 0; out_register < output_warehouse.Count; out_register++)
                {
                    if (output_warehouse[out_register].Actual_amount >= output_warehouse[out_register].Upper_warning)
                    {
                        Product product_tosend = output_warehouse[out_register].Reg_product;
                        Station station_tosend = output_warehouse[out_register].Reg_station;
                        Product_Event event_tosend = new Product_Event(Product_Event_Type.collection_called,
                                                                       ref product_tosend,
                                                                       ref station_tosend,
                                                                       output_warehouse[out_register].Call_time,
                                                                       output_warehouse[out_register].Actual_amount - output_warehouse[out_register].Min_amount);
                        list_tosend.Add(event_tosend);
                    }
                }
                

                return list_tosend;
            }
            else
                return null;
        }

        private bool CheckProductionPossibility()
        {
            for (int i = 0; i < station_parameters.)
        }
    }
}
