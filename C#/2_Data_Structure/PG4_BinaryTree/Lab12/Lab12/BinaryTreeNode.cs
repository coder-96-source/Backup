namespace Lab12
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Data { get; set; }
    }
}
