using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Models
{
    internal class GalaxyMap
    {
        // the list of planets the galaxy consists of
        private List<Planet> _planets = new List<Planet>();

        // Add a planet to the list of planets
        public void AddPlanet(Planet planet)
        {
            // Make sure that every planet has an unique name
            if (FindPlanet(planet.Name) == null)
            {
                _planets.Add(planet);
            }
            else
            {
                Console.WriteLine("This planet already exists in the galaxy");
            }
        }

        // Find the planet with the given name in the list of planets
        private Planet FindPlanet(string name)
        {
            foreach (Planet planet in _planets)
            {
                if (planet.Name.Equals(name))
                {
                    return planet;
                }
            }
            return null;
        }

        //Sets a one way weighted connection from planet A to planet B with weight weightAtoB
        public void SetConnectionOneWay(string planetAname, string planetBname, int weightAtoB)
        {
            Planet planetA = FindPlanet(planetAname);
            Planet planetB = FindPlanet(planetBname);
            planetA.SetConnection(planetB, weightAtoB);
        }

        //Sets a one way weighted connection from planet A to planet B with weight weightAtoB
        //Sets a one way weighted connection from planet B to planet A with weight weightBtoA
        public void SetConnectionBothWays(string planetAname, string planetBname, int weightAtoB, int weightBtoA)
        {
            Planet planetA = FindPlanet(planetAname);
            Planet planetB = FindPlanet(planetBname);
            planetA.SetConnection(planetB, weightAtoB);
            planetB.SetConnection(planetA, weightBtoA);
        }

        // Set connections both ways with equal weights
        public void SetConnectionBothWays(string planetAname, string planetBname, int weight)
        {
            SetConnectionBothWays(planetAname, planetBname, weight, weight);
        }

        // Determine the shortest path: Dijkstra's algorithm
        public void GetShortestPath(string from, string to)
        {
            // Initialize the algorithm
            Planet destination = FindPlanet(to);
            Planet currentPlanet = FindPlanet(from);
            currentPlanet.PathWeight = 0;
            if (destination != null && currentPlanet != null)
            {
                // While the current planet isn't the destination keep checking if the weight of the current planet + the connection is lower than the current weight of the connected planet. If it is lower, then adjust the weight and change the planet from which this new weight originated. After every connection is handled check which planet was not visited yet and has the lowest weight. Hnadle this planet in the next iteration.
                while (currentPlanet != destination)
                {
                    currentPlanet.Visited = true;
                    HandleCurrentPlanet(currentPlanet);
                    currentPlanet = DetermineNextPlanetToCheck(currentPlanet);
                }
                // Print all the planets with their weights and previous planet
                // PrintTheWeightOfEachPlanet(planets);

                // Print the shortest route
                StringBuilder path = currentPlanet.PrintPath(new StringBuilder());
                Console.WriteLine("\nThe shortest path = " + path.ToString().Substring(0, path.Length - 3));
            }
            else
            {
                Console.WriteLine("The input was not valid");
            }
            // Reset the state for the next shortest path request
            ResetShortestPath();
        }

        // Review all connections of the current planet and adjust their weight and previous planet if the path is shorter
        private static void HandleCurrentPlanet(Planet currentPlanet)
        {
            List<Connection> connectedPlanets = currentPlanet.ConnectedPlanets;
            for (int i = 0; i < connectedPlanets.Count; i++)
            {

                if (currentPlanet.PathWeight + connectedPlanets[i].getWeight() < connectedPlanets[i].GetPlanet().PathWeight)
                {
                    connectedPlanets[i].GetPlanet().PathWeight = currentPlanet.PathWeight + connectedPlanets[i].getWeight();
                    connectedPlanets[i].GetPlanet().PreviousPlanet = currentPlanet;
                }
            }
        }

        // Determine the next planet to check out. This is the planet with the lowest weight that has not been visited yet
        private Planet DetermineNextPlanetToCheck(Planet currentPlanet)
        {
            // Initialize the minimum weight to the max value, so that there is always a planet with a lower weight
            int minWeight = int.MaxValue;
            foreach (Planet planet in _planets)
            {
                if (!planet.Visited && planet.PathWeight < minWeight)
                {
                    currentPlanet = planet;
                }
            }
            return currentPlanet;
        }

        // Reset the weight and previous planet of each planet to their default
        private void ResetShortestPath()
        {
            foreach (Planet planet in _planets)
            {
                planet.ResetShortestPath();
            }
        }

        // Prints the name of the galaxy and all the planets it consists of with their connections
        public override string ToString()
        {
            StringBuilder answer = new StringBuilder("GalaxyMap\n");
            foreach (Planet planet in _planets)
            {
                answer.AppendLine(planet.ToString());
            }
            return answer.ToString();
        }
    }
}