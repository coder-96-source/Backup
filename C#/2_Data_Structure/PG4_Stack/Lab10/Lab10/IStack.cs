namespace Lab10
{
    public interface IStack<T>
    {
        void Push(T newNode);
        T Pop();
        T Peek();
        int Count();
        bool IsEmpty();
    }
}
