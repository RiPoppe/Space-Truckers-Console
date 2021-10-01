using System;
using System.Text;
using System.Collections.Generic;

namespace Dijkstra.Models
{
    class GalaxyMap
    {
        // the list of planets the galaxy consists of
        private List<Planet> planets = new List<Planet>();

        // Add a planet to the list of planets
        public void AddPlanet(Planet planet)
        {
            // Make sure that every planet has an unique name
            if (FindPlanet(planet.Name)== null)
            {
                planets.Add(planet);
            } else
            {
                Console.WriteLine("This planet already exists in the galaxy");
            }
        }

        // Find the planet with the given name in the list of planets
        private Planet FindPlanet(string name)
        {
            foreach (Planet planet in planets)
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
            SetConnectionBothWays(planetAname,planetBname,weight,weight);
        }

        public void GetShortestPath(string from, string to)
        {
            Planet currentPlanet = FindPlanet(from);
            currentPlanet.Visited = true;
            currentPlanet.WeightShortestPath = 0;
            Console.WriteLine("weight = " + currentPlanet.WeightShortestPath);
            Console.WriteLine();
            Planet destination = FindPlanet(to);

            while (currentPlanet != destination)
            {
                Console.WriteLine("The current planet is: " + currentPlanet.Name);

                List<Planet> connectedPlanets = currentPlanet.ConnectedPlanets;
                List<int> connectedPlanetWeights = currentPlanet.ConnectedPlanetWeights;
                for (int i = 0; i < connectedPlanets.Count; i++)
                {
                    if (currentPlanet.WeightShortestPath + connectedPlanetWeights[i]  < connectedPlanets[i].WeightShortestPath)
                    {
                        connectedPlanets[i].WeightShortestPath = currentPlanet.WeightShortestPath + connectedPlanetWeights[i];
                    }
                    Console.WriteLine("" + connectedPlanets[0].Name);
                }

                break;
            }
            PrintTheWeightOfEachPlanet(planets);
            ResetShortestPath();
        }

        private void PrintTheWeightOfEachPlanet(List<Planet> planetList)
        {
            foreach (Planet planet in planetList)
            {
                Console.WriteLine("The weight of " + planet.Name + " = " + planet.WeightShortestPath);
            }
        }

        private void ResetShortestPath()
        {
            foreach (Planet planet in planets)
            {
                planet.ResetShortestPath();
            }
        }

        // Prints the name of the galaxy and all the planets it consists of with their connections
        public override string ToString()
        {
            StringBuilder answer = new StringBuilder("GalaxyMap\n");
            foreach (Planet planet in planets)
            {
                answer.AppendLine(planet.ToString());
            }
            return answer.ToString();
        }

    }
}
