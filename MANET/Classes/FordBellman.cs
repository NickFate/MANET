using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MANET.Interfaces;

namespace MANET.Classes
{
    /// Метод Форда-Беллмана
    public class FordBellman : IFindingShortestPathAlgorithm
    {

        public Graph FindShortestPath(Graph MainGraph, Vertex from, Vertex to)
        {
            Graph path = new Graph();

            double[] dist = Enumerable.Repeat(double.MaxValue, MainGraph.vertices.Count).ToArray();
            dist[from.id] = 0;

            path.vertices = new List<Vertex>();
            path.vertices.Add(from);

            path.edges = new List<Edge>();

            for (int i = 0; i < MainGraph.vertices.Count - 1; i++)
            {
                foreach (Edge edge in MainGraph.edges)
                {
                    if (dist[edge.from.id] != double.MaxValue && dist[edge.from.id] + edge.Lenght < dist[edge.to.id])
                    {
                        dist[edge.to.id] = Math.Round(dist[edge.from.id] + edge.Lenght, 2);
                    }
                }
            }

            double curDist = dist[to.id];
            int curId = to.id;
            List<int> Ids = new List<int>();

            Ids.Add(curId);
            while (Math.Round(curDist) != 0)
            {
                foreach (Edge edge in MainGraph.edges)
                {
                    if (edge.to.id == curId && dist.Contains(Math.Round(curDist - edge.Lenght, 2)))
                    {
                        curId = edge.from.id;
                        Ids.Add(curId);
                        curDist -= edge.Lenght;
                        break;
                    }
                }
            }

            Ids.Reverse();

            foreach (double i in Ids)
            {
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine();

            return path;
        }
    }
}
