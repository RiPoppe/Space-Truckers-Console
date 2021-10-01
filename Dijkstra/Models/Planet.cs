using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Models
{
    internal class Planet
    {
        private string name;
        private List<Planet> connectedPlanets = new List<Planet>();
        private List<int> connectedPlanetWeights = new List<int>();

        private Planet previousPlanetOnShortestRoute = null;
        private int weightShortestPath = int.MaxValue;
        private bool visited = false;

        public string Name { get { return name; } set { this.name = value; } }
        public bool Visited { get { return visited; } set { this.visited = value; } }
        public int WeightShortestPath { get { return weightShortestPath; } set { this.weightShortestPath = value; } }
        public Planet PreviousPlanetOnShortestRoute { get { return PreviousPlanetOnShortestRoute; } set { this.previousPlanetOnShortestRoute = value; } }

        public List<Planet> ConnectedPlanets { get {return connectedPlanets; } }
        public List<int> ConnectedPlanetWeights { get { return connectedPlanetWeights; } }

        public void ResetShortestPath()
        {
            previousPlanetOnShortestRoute = null;
            weightShortestPath = int.MaxValue;
            visited = false;
        }


        public Planet(string name)
        {
            this.name = name;
        }

        public void SetConnection(Planet planet, int weight)
        {
            if (!connectedPlanets.Contains(planet))
            {
                connectedPlanets.Add(planet);
                connectedPlanetWeights.Add(weight);
            }
            else
            {
                Console.WriteLine("This connection already consists: " + Name + " > " + planet.Name);
            }
        }

        // Makes a string of the planet together with its connections and the weights of these connections
        public override string ToString()
        {
            StringBuilder answer = new StringBuilder(Name);
            answer.Append(":\tThe amount of connections = " + connectedPlanets.Count);
            for (int i = 0; i < connectedPlanets.Count; i++)
            {
                answer.Append("\n---" + connectedPlanets[i].Name + "\t" + connectedPlanetWeights[i]);
            }

            return answer.ToString();
        }
    }
}