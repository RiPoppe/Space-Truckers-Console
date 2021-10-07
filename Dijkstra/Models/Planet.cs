using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dijkstra.Models
{
    internal class Planet
    {
        // Variables that represent the planet and its connections
        private string _name;


        private List<Connection> connections = new List<Connection>();

        // Variables used by dijkstra's algorithm
        private Planet _previousPlanet = null;

        private int _pathWeight = int.MaxValue;
        private bool _visited = false;

        // Constructor
        public Planet(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this._name = name;
            }
            else
            {
                this._name = "default";
            }
        }

        // Get and Set methods of the above variables
        public string Name { get { return _name; } }

        public bool Visited { get { return _visited; } set { this._visited = value; } }
        public int PathWeight { get { return _pathWeight; } set { this._pathWeight = value; } }
        public Planet PreviousPlanet { get { return _previousPlanet; } set { this._previousPlanet = value; } }

        public List<Connection> ConnectedPlanets { get { return connections; } }

        // Resets the variables used by Dijkstra's algorithm to their defaults
        public void ResetShortestPath()
        {
            _previousPlanet = null;
            _pathWeight = int.MaxValue;
            _visited = false;
        }

        // Adds the planet to the connectedplanets and weights if it isn't already there
        public void SetConnection(Planet planet, int weight)
        {
            if (!connections.Any(plan => plan.GetPlanet().Equals(planet)))
            {
                connections.Add(new Connection(planet,weight));
            }
            else
            {
                Console.WriteLine("This connection already consists: " + Name + " > " + planet.Name);
            }
        }

        // Add the previous planet in front of the string in path. If the previous planet is null, then do nothing, since it is the starting planet.
        public StringBuilder PrintPath(StringBuilder path)
        {
            path.Insert(0, Name + " > ");
            if (_previousPlanet != null)
            {
                _previousPlanet.PrintPath(path);
            }
            return path;
        }

        // Makes a string of the planet together with its connections and the weights of these connections
        public override string ToString()
        {
            StringBuilder answer = new StringBuilder(Name);
            answer.Append(":\tThe amount of connections = " + connections.Count);
            for (int i = 0; i < connections.Count; i++)
            {
                answer.Append("\n---" + connections[i].GetPlanet().Name + "\t" + connections[i].getWeight());
            }

            return answer.ToString();
        }
    }
}