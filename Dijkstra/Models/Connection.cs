using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Models
{
    class Connection
    {
        private int weight;
        private Planet planet;

        public Connection(Planet planet, int weight)
        {
            this.planet = planet;
            this.weight = weight;

        }

        public Planet GetPlanet()
        {
            return planet;
        }
        public int getWeight()
        {
            return weight;
        }
    }
}
