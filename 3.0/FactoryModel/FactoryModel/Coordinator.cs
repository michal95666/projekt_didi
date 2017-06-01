using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Coordinator
    {
        // variabless
        public List<Station> Stations { get; }
        private List<Product_Event> Events_pending { get; }
        private List<Product_Event> Events_active { get; }

        // methods
        public void Simulation(int simulation_steps)
        {
            for (int step = 0; step < simulation_steps; step++)
            {
                // updating timeout in commands, performing commands with timeouts == 0
                for (int s = 0; s < Events_active.Count; s++)
                {
                    if (Events_active[s].Timeout > 0)
                        Events_active[s].Timeout--;
                    if (Events_active[s].Timeout == 0)
                    { 
                        if (CheckRequirements(Events_active[s]))
                            Events_active[s].Receiver_station.ExecuteCommand(GenerateCommand(Events_active[s]));
                    }
                    // 1) on each station perform all commands from Commands_active
                }

                for (;;)
                {
                    // 2) receive all events from stations
                }
                // 3) transform events to commands
            }
        }

        public Coordinator_Command GenerateCommand(Product_Event product_event)
        {
            // generating commands based on previously sent event
            // be cautious with amounts - give/take as much as it is possible (equal or less than requested amount)
            // there must not be conflicts between commands!!!
            // all conflicts may appear only between registered events, when command is generated there is 100% certainty that command will be executed woth no issues!
        }

        public bool CheckRequirements(Product_Event product_event) // VERY UNCOMPLETE!
        {
            Product searched_product = product_event.Event_product;
            Warehouse_Register actual_outreg = product_event.Receiver_station.Output_warehouse.Find(register => register.Reg_product == searched_product);
            Warehouse_Register actual_inreg = product_event.Receiver_station.Input_warehouse.Find(register => register.Reg_product == searched_product);
            switch (product_event.Event_type)
            {
                case Product_Event_Type.delivery_called:
                    if (actual_outreg.Actual_amount > 0) // more conditions should be added!
                        return true;
                    break;
                case Product_Event_Type.collection_called:
                    if ((actual_inreg.Upper_warning - actual_inreg.Actual_amount) > 0) // more conditions should be added!
                        return true;
                    break;
                case Product_Event_Type.delivery_arrived:
                    if ((actual_inreg.Upper_warning - actual_inreg.Actual_amount) > 0) // more conditions should be added!
                        return true;
                    break;
                case Product_Event_Type.process_started:
                    //if ()
                        return true;
                    break;
                default:

                    break;
            }
            return false;



        }
        // method to transform Product_Events to Coordinator_Command
        // it should iterate over all events when collected and aggregated into one list
        // and create commands in list related to proper station
        // order of actions in simulation:
        // 0) update time in commands: Execution_time-- ;if Execution_time == 0, move this command to Commands_active
        // 1) on each station perform all commands from Commands_active
        // 2) receive all events from stations
        // 3) transform events to commands with their time to be executed and add to Commands_pending list on proper station
        
    }
}
