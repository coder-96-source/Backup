using System.Collections.Generic;

namespace MyDataStructures
{
    public class GraphNode<T>
    {
        private List<GraphNode<T>> _adjList;
        private List<int> _weightList;

        public GraphNode(T data)
        {
            Data = data;
            VisitFlag = false;
        }

        public T Data { get; set; }
        public bool VisitFlag { get; set; }
        public List<GraphNode<T>> AdjList
        {
            get
            {
                _adjList = _adjList ?? new List<GraphNode<T>>();
                return _adjList;
            }
        }
        public List<int> WeightList
        {
            get
            {
                _weightList = _weightList ?? new List<int>();
                return _weightList;
            }
        }
    }
}
