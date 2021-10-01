using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Models
{
    internal class Planet
    {
        // Variables that represent the planet and its connections
        private string name;
        private List<Planet> connectedPlanets = new List<Planet>();
        private List<int> connectedPlanetWeights = new List<int>();

        // Variables used by dijkstra's algorithm
        private Planet previousPlanetOnShortestRoute = null;
        private int weightShortestPath = int.MaxValue;
        private bool visited = false;

        // Constructor
        public Planet(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.name = name;
            } else
            {
                this.name = "default";
            }
        }

        // Get and Set methods of the above variables
        public string Name { get { return name; } }
        public bool Visited { get { return visited; } set { this.visited = value; } }
        public int WeightShortestPath { get { return weightShortestPath; } set { this.weightShortestPath = value; } }
        public Planet PreviousPlanetOnShortestRoute { get { return previousPlanetOnShortestRoute; } set { this.previousPlanetOnShortestRoute = value; } }

        public List<Planet> ConnectedPlanets { get {return connectedPlanets; } }
        public List<int> ConnectedPlanetWeights { get { return connectedPlanetWeights; } }

        // Resets the variables used by Dijkstra's algorithm to their defaults
        public void ResetShortestPath()
        {
            previousPlanetOnShortestRoute = null;
            weightShortestPath = int.MaxValue;
            visited = false;
        }

        // Adds the planet to the connectedplanets and weights if it isn't already there
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

        // Add the previous planet in front of the string in path. If the previous planet is null, then do nothing, since it is the starting planet.
        public StringBuilder PrintPath(StringBuilder path) 
        {
            path.Insert(0,Name+ " > ");
            if (previousPlanetOnShortestRoute!=null)
            {
                previousPlanetOnShortestRoute.PrintPath(path);
            }
            return path;
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