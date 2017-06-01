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
        public List<Warehouse_Register> Input_warehouse { get; }
        public List<Warehouse_Register> Output_warehouse { get; }
        private Process_Parameters station_parameters;
        public bool Enabled { get; set; }
        public bool Started { get; set; }
        // methods
        //public void PerformCommands(List<Coordinator_Command> commands)
        //{
        //    if (Enabled)
        //    {
        //        // performing actions from passed coordinator commands
        //        for (int com_counter = 0; com_counter < commands.Count; com_counter++)
        //            ExecuteCommand(commands[com_counter]);
        //    }
        //}

        public List<Product_Event> SendEvents()
        {
            if (Enabled)
            {
                // checking input warehouse and sending requests if needed
                List<Product_Event> list_tosend = new List<Product_Event>();
                for (int in_register = 0; in_register < Input_warehouse.Count; in_register++)
                {
                    if (Input_warehouse[in_register].Actual_amount <= Input_warehouse[in_register].Lower_warning)
                    {
                        Product product_tosend = Input_warehouse[in_register].Reg_product;
                        Station station_tosend = Input_warehouse[in_register].Reg_station;
                        Product_Event event_tosend = new Product_Event(Product_Event_Type.delivery_called,
                                                                       ref product_tosend,
                                                                       this,
                                                                       ref station_tosend,
                                                                       Input_warehouse[in_register].Call_time,
                                                                       Input_warehouse[in_register].Max_amount - Input_warehouse[in_register].Actual_amount);
                        list_tosend.Add(event_tosend);
                    }
                }
                // checking output warehouse and sending requests if needed
                for (int out_register = 0; out_register < Output_warehouse.Count; out_register++)
                {
                    if (Output_warehouse[out_register].Actual_amount >= Output_warehouse[out_register].Upper_warning)
                    {
                        Product product_tosend = Output_warehouse[out_register].Reg_product;
                        Station station_tosend = Output_warehouse[out_register].Reg_station;
                        Product_Event event_tosend = new Product_Event(Product_Event_Type.collection_called,
                                                                       ref product_tosend,
                                                                       this,
                                                                       ref station_tosend,
                                                                       Output_warehouse[out_register].Call_time,
                                                                       Output_warehouse[out_register].Actual_amount - Output_warehouse[out_register].Min_amount);
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
                                                                   this,
                                                                   ref station_tosend,
                                                                   station_parameters.cycle_time,
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
                Warehouse_Register actual_register = Input_warehouse.Find(register => register.Reg_product == actual_product);
                if (actual_register.Actual_amount < station_parameters.Input_pairs[i].GetStruct().process_value)
                    return false;
            }
            for (int i = 0; i < station_parameters.GetSizeListOut(); i++)
            {
                Product actual_product = station_parameters.Output_pairs[i].GetStruct().product;
                Warehouse_Register actual_register = Output_warehouse.Find(register => register.Reg_product == actual_product);
                int free_space = actual_register.Max_amount - actual_register.Actual_amount;
                if (free_space < station_parameters.Output_pairs[i].GetStruct().process_value)
                    return false;
            }
            return true;
        }

        public void ExecuteCommand(Coordinator_Command command)
        {
            if (command.Type == Command_Type.take)
            {
                Warehouse_Register register_tochange = Input_warehouse.Find(register => register.Reg_product == command.Command_product);
                // Input_warehouse.Find(delegate (Warehouse_Register register) { return register.Reg_product == command.Changed_product; });
                register_tochange.Actual_amount += command.Amount_modification;
                register_tochange.Call_flag = command.Call_flag_modification;
            }
            else if (command.Type == Command_Type.give)
            {
                Warehouse_Register register_tochange = Output_warehouse.Find(register => register.Reg_product == command.Command_product);
                register_tochange.Actual_amount += command.Amount_modification;
                register_tochange.Call_flag = command.Call_flag_modification;
            }
        }

        
    }
}
