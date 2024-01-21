using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANET.Classes
{

    public class Graph
    {
        public List<Edge> edges = new List<Edge>();

        public List<Vertex> vertices = new List<Vertex>(); // нужен ли?

        public void BuildEdges()
        {
            foreach (Vertex from in vertices) 
            {
                foreach (Vertex to in vertices)
                {
                    if (from.id != to.id)
                    {
                        edges.Add(new Edge(from, to));
                    }
                }
            }
        }

        public void BuildEdges(double MaxDistance) 
        {
            foreach (Vertex from in vertices)
            {
                foreach (Vertex to in vertices)
                {
                    if (from.id != to.id && Point.DistanceBetweenTwoPoint(from.position, to.position) < MaxDistance)
                    {
                        edges.Add(new Edge(from, to));
                    }
                }
            }

            Console.WriteLine();
        }

        public List<Vertex> GetNeighbors(Vertex from)
        {
            List<Vertex> neighbors = new List<Vertex>();

            foreach (Edge edge in edges)
            {
                if (edge.from == from)
                {
                    neighbors.Add(edge.to);
                }
            }
            return neighbors;
        }

    }

}
