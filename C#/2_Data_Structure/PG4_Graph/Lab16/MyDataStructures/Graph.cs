using System;
using System.Collections.Generic;

namespace MyDataStructures
{
    public class Graph<T>
    {
        private List<GraphNode<T>> _vertexList;

        public Graph()
        {

        }

        public List<GraphNode<T>> VertexList
        {
            get
            {
                _vertexList = _vertexList ?? new List<GraphNode<T>>();
                return _vertexList;
            }
        }

        public void AddVertex(GraphNode<T> newVertex)
        {
            VertexList.Add(newVertex);
        }
        public void AddEdge(GraphNode<T> fromV, GraphNode<T> toV, int weight, bool directed)
        {
            //connecting from fromV to toV
            fromV.AdjList.Add(toV);
            fromV.WeightList.Add(weight);

            if (directed) // fromV <-> toV
            {
                //connecting from toV to fromV
                toV.AdjList.Add(fromV);
                toV.WeightList.Add(weight);
            }
        }
    }
}
