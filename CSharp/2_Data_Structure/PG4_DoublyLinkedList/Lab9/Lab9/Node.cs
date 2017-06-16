namespace Lab9
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }

        public T Data { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
    }
}
