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
        public bool Started { get; set; }
        public double process_time { get; private set; }
        // methods
        public void PerformCommands(List<Coordinator_Command> commands)
        {
            if (Enabled)
            {
                // performing actions from passed coordinator commands
                for (int com_counter = 0; com_counter < commands.Count; com_counter++)
                    ExecuteCommand(commands[com_counter]);
            }
        }

        public List<Product_Event> SendEvents()
        {
            if (Enabled)
            {
                // checking input warehouse and sending requests if needed
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
                // checking output warehouse and sending requests if needed
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
                // starting process on station
                if (CheckProductionPossibility())
                {
                    Product product_tosend = null;
                    Station station_tosend = this;
                    Product_Event event_tosend = new Product_Event(Product_Event_Type.process_started,
                                                                   ref product_tosend,
                                                                   ref station_tosend,
                                                                   process_time,
                                                                   0);
                    list_tosend.Add(event_tosend);
                }

                return list_tosend;
            }
            else
                return null;
        }

        private bool CheckProductionPossibility()
        {
            for (int i = 0; i < station_parameters.GetSizeListIn(); i++)
            {
                Product actual_product = station_parameters.Input_pairs[i].GetStruct().product;
                Warehouse_Register actual_register = input_warehouse.Find(register => register.Reg_product == actual_product);
                if (actual_register.Actual_amount < station_parameters.Input_pairs[i].GetStruct().process_value)
                    return false;
            }
            for (int i = 0; i < station_parameters.GetSizeListOut(); i++)
            {
                Product actual_product = station_parameters.Output_pairs[i].GetStruct().product;
                Warehouse_Register actual_register = output_warehouse.Find(register => register.Reg_product == actual_product);
                int free_space = actual_register.Max_amount - actual_register.Actual_amount;
                if (free_space < station_parameters.Output_pairs[i].GetStruct().process_value)
                    return false;
            }
            return true;
        }

        private void ExecuteCommand(Coordinator_Command command)
        {
            if (command.Which_warehouse == Warehouse_Type.input)
            {
                Warehouse_Register register_tochange = input_warehouse.Find(register => register.Reg_product == command.Command_product);
                // input_warehouse.Find(delegate (Warehouse_Register register) { return register.Reg_product == command.Changed_product; });
                register_tochange.Actual_amount += command.Change_actual_amount;
                register_tochange.Call_flag = command.Change_call_flag;
            }
            else if (command.Which_warehouse == Warehouse_Type.output)
            {
                Warehouse_Register register_tochange = output_warehouse.Find(register => register.Reg_product == command.Command_product);
                register_tochange.Actual_amount += command.Change_actual_amount;
                register_tochange.Call_flag = command.Change_call_flag;
            }
        }

        
    }
}
