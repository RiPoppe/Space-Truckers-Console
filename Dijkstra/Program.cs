using System;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Models.GalaxyMap galaxyMap = new Models.GalaxyMap();

            // Add planets to the galaxy
            galaxyMap.AddPlanet(new Models.Planet("A"));
            galaxyMap.AddPlanet(new Models.Planet("B"));
            galaxyMap.AddPlanet(new Models.Planet("C"));
            galaxyMap.AddPlanet(new Models.Planet("D"));
            galaxyMap.AddPlanet(new Models.Planet("E"));
            galaxyMap.AddPlanet(new Models.Planet("F"));
            galaxyMap.AddPlanet(new Models.Planet("G"));
            galaxyMap.AddPlanet(new Models.Planet("H"));
            galaxyMap.AddPlanet(new Models.Planet("I"));
            galaxyMap.AddPlanet(new Models.Planet("J"));

            // Make travel possible between planets
            galaxyMap.SetConnectionBothWays("A", "B", 6);
            galaxyMap.SetConnectionBothWays("B", "C", 5);
            galaxyMap.SetConnectionBothWays("A", "D", 11);
            galaxyMap.SetConnectionBothWays("D", "E", 7);
            galaxyMap.SetConnectionBothWays("E", "F", 14);
            galaxyMap.SetConnectionBothWays("D", "F", 26);
            galaxyMap.SetConnectionBothWays("D", "G", 5);
            galaxyMap.SetConnectionBothWays("F", "I", 17);
            galaxyMap.SetConnectionBothWays("F", "H", 3);
            galaxyMap.SetConnectionBothWays("G", "H", 3);
            galaxyMap.SetConnectionBothWays("G", "J", 5);
            galaxyMap.SetConnectionBothWays("H", "I", 5);
            galaxyMap.SetConnectionBothWays("H", "J", 4);

            // Print the galaxy to the console
            // Console.WriteLine(galaxyMap.ToString());

            // Get the shortest path
            galaxyMap.GetShortestPath("C","F");
        }
    }
}
