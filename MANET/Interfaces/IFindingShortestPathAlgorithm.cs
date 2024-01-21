using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANET.Classes;

namespace MANET.Interfaces
{
    public interface IFindingShortestPathAlgorithm
    {

        Graph FindShortestPath(Graph MainGraph, Vertex from, Vertex to);

    }
}
