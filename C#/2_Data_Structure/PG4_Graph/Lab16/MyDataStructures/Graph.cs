using System;
using System.Collections.Generic;

namespace MyDataStructures
{
    /* 1. Lazy Initialization
     * a) https://en.wikipedia.org/wiki/Lazy_initialization
     * b) https://msdn.microsoft.com/en-us/library/dd997286(v=vs.110).aspx
     */
    public class Graph<T>
    {
        protected enum SearchType { DFS, BFS }
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

        //Depth First Search
        public void DFS()
        {
            SetAsDefault();

            foreach (GraphNode<T> vertex in VertexList)
            {
                RecursiveDFS(vertex);
            }
        }
        protected void RecursiveDFS(GraphNode<T> vertex)
        {
            if (!vertex.VisitFlag)
            {
                VisitVertex(vertex, SearchType.DFS);
            }
            foreach (GraphNode<T> adjVertex in vertex.AdjList)
            {
                if (!adjVertex.VisitFlag) //visit adjacent vertex
                {
                    RecursiveDFS(adjVertex);
                }
            }
        }

        //Breadth First Search
        public void BFS()
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();

            SetAsDefault();

            foreach (GraphNode<T> vertex in VertexList)
            {
                if (!vertex.VisitFlag)
                {
                    vertex.VisitFlag = true;
                    queue.Enqueue(vertex);
                }

                while (queue.Count != 0)
                {
                    GraphNode<T> tempVertex = queue.Dequeue();

                    VisitVertex(tempVertex, SearchType.BFS);
                    
                    foreach (GraphNode<T> adjVertex in tempVertex.AdjList)
                    {
                        if (!adjVertex.VisitFlag)
                        {
                            adjVertex.VisitFlag = true;
                            queue.Enqueue(adjVertex);
                        }
                    }
                }
            }
        }

        protected virtual void VisitVertex(GraphNode<T> vertex, SearchType type)
        {
            switch (type)
            {
                case SearchType.DFS:
                    vertex.VisitFlag = true;
                    Console.WriteLine(vertex.Data);
                    break;
                case SearchType.BFS:
                    Console.WriteLine(vertex.Data);
                    break;
            }
        }
        protected virtual void SetAsDefault()
        {
            foreach (GraphNode<T> vertex in VertexList) //set as default
            {
                vertex.VisitFlag = false;
            }
        }
    }
}
