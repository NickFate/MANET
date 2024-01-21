using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANET.Classes
{
    public class Vertex
    {
        public static int _id = 0;
        public int id;

        public Point position = new Point();

        public Vertex()
        {
            id = _id;
            _id++;
        }

        public Vertex(Point pos)
        {
            id = _id;
            _id++;
            position = pos;
        }

        public Vertex(int id)
        {
            this.id = id;
            _id++;
        }

        public Vertex(int id, Point pos)
        {
            this.id = id;
            _id++;
            position = pos;
        }
    }

    public class Edge
    {
        public Vertex from;
        public Vertex to;
        
        public Edge(Vertex from, Vertex to) 
        {
            this.from = from;
            this.to = to;
        }

        public double Lenght
        {
            get { return Point.DistanceBetweenTwoPoint(from.position, to.position); }
        }

    }
}
