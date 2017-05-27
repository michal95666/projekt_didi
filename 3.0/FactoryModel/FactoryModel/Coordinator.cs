using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModel
{
    class Coordinator
    {
        private List<Station> stations;
        private List<Product_Event> actual_events;

        public void Simulation(int simulation_steps)
        {
            for (int step = 0; step < simulation_steps; step++)
            {
                for (int st_count = 0; st_count < stations.Count; st_count++)
                {

                }
            }
        }
    }
}
