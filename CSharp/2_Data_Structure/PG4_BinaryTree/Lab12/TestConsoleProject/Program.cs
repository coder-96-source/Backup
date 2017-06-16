using System;
using Lab12;

namespace TestConsoleProject
{
    /* BT에 관한것은 아니지만.. BST에서 Generic T에 대해서 comparer 오류가 난다.
     * 이는 private Comparer<T> comparer = Comparer<T>.Default; 로 해결할 수 있으며 또한, T에 대해 IComparable을 구현해서 해결
     * 할 수도 있다. class BST<T> where T: IComarable<T>
     */
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        
        public static void Run()
        {
            BinaryTree<int> myBT = new BinaryTree<int>();

            SetBT(myBT);

            myBT.PreOrderTraversal();
            Console.WriteLine("\t PreOrder");

            myBT.InOrderTraversal();
            Console.WriteLine("\t InOrder");

            myBT.PostOrderTraversal();
            Console.WriteLine("\t PostOrder");

            myBT.LevelOrderTraversal();
            Console.WriteLine("\t LevelOrder");

            Console.WriteLine("Count : {0}", myBT.Count());
        }
        public static void SetBT(BinaryTree<int> myBT)
        {
            myBT.Root = new BinaryTreeNode<int>(1);
            myBT.Root.Left = new BinaryTreeNode<int>(2);
            myBT.Root.Right = new BinaryTreeNode<int>(3);
            myBT.Root.Left.Left = new BinaryTreeNode<int>(4);
            myBT.Root.Left.Right = new BinaryTreeNode<int>(5);
            myBT.Root.Right.Right = new BinaryTreeNode<int>(7);
            myBT.Root.Left.Right.Left = new BinaryTreeNode<int>(6);
            myBT.Root.Right.Right.Left = new BinaryTreeNode<int>(8);
        }
    }
}
