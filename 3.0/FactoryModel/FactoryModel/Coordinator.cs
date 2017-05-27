using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Coordinator
    {
        // structure to link each station with its commands and events
        public struct Actions
        {
            public Station Actions_station { get; }
            public List<Coordinator_Command> Commands_active { get; }  // null if there is no commands
            public List<Coordinator_Command> Commands_pending { get; }
            public List<Product_Event> Events { get; }          // null if there is no related events

        }

        private List<Actions> actions;

        // methods
        public void Simulation(int simulation_steps)
        {
            for (int step = 0; step < simulation_steps; step++)
            {
                // 0) update time in commands
                for (int s = 0; s < actions.Count; s++)
                {
                    // 1) on each station perform all commands from Commands_active
                }

                for (;;)
                {
                    // 2) receive all events from stations
                }
                // 3) transform events to commands
            }
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
