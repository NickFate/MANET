using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using MANET.Interfaces;

namespace MANET.Classes
{
    public class Dejsktra : IFindingShortestPathAlgorithm
    {

        public Graph FindShortestPath(Graph MainGraph, Vertex from, Vertex to)
        {
            List<Vertex> unvisited = new List<Vertex>(MainGraph.vertices);
            List<Vertex> path = new List<Vertex>();

            double[] dist = Enumerable.Repeat(double.MaxValue, MainGraph.vertices.Count).ToArray();
            dist[from.id] = 0;
            List<Vertex> prev = new List<Vertex>(MainGraph.vertices);

            while (unvisited.Count > 0)
            {
                Vertex min = null;
                foreach (Vertex node in unvisited)
                {
                    if (min == null)
                    {
                        min = node;
                    }
                    else if (dist[node.id] < dist[min.id])
                    {
                        min = node;
                    }
                }

                List<Vertex> neighbors = MainGraph.GetNeighbors(min);
                foreach (Vertex v in neighbors)
                {
                    double value = Math.Round(dist[min.id] + Point.DistanceBetweenTwoPoint(v.position, min.position), 2);
                    if (value < dist[v.id])
                    {
                        dist[v.id] = value;
                        prev[v.id] = min;
                    }
                }

                unvisited.Remove(min);
            }

            Vertex nod = to;

            while (nod != from)
            {
                path.Add(nod);
                nod = prev[nod.id];
            }
            path.Add(from);
            path.Reverse();
            

            foreach (Vertex v in path)
            {
                Console.Write(v.id);
                Console.Write(" ");
            }

            Console.WriteLine();

            return new Graph();
        }

    }
}
