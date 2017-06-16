using System;

namespace Lab11
{
    public class MyQueue<T>
    {
        private T[] _array;

        private const int DefaultCapacity = 16;

        public MyQueue() 
            : this(DefaultCapacity) {
        }
        public MyQueue(int capacity)
        {
            Capacity = capacity;
            _array = new T[Capacity];
            Front = 0;
            Rear = 0;
            Count = 0;
        }

        private int Front { get; set; }
        private int Rear { get; set; }
        private int Capacity { get; set; }
        public int Count { get; private set; } //Queue에 있는 요소수를 리턴합니다
        public bool IsEmpty { get { return Count == 0; } } //Queue가 비어있는지 bool 리턴
        public bool IsFull { get { return Count == _array.Length; } }

        public void Enqueue(T data) //Queue 뒤에 새 값을 추가합니다
        {
            if (IsFull)
            {
                SetCapacity(newCapacity : Capacity * 2);
            }

            _array[Rear] = data;
            Rear = (Rear + 1) % _array.Length;
            Count++;
        }
        public T Dequeue() //Queue에서 Front 값을 리턴하고(FIFO) 삭제합니다.
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T removed = _array[Front];
                Front = (Front + 1) % _array.Length;
                Count--;
                return removed;
            }
        }
        public T Peek() //Queue에서 Front 값을 리턴하지만 삭제는 하지 않습니다.
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _array[Front];
            }
        }
        private void SetCapacity(int newCapacity)
        {
            T[] newarray = new T[newCapacity];

            if (Count > 0)
            {
                if (Front < Rear) //Dequeue 없이 꽉찬 경우
                {
                    Array.Copy(_array, Front, newarray, 0, Count);
                }
                else //Dequeue로 인해 Rear가 Front 앞에 위치한 경우
                {
                    Array.Copy(_array, Front, newarray, 0, _array.Length - Front);
                    Array.Copy(_array, 0, newarray, _array.Length - Front, Rear);
                }
            }

            Capacity = newCapacity;
            _array = new T[Capacity];

            _array = newarray;
            Front = 0;
            Rear = Count;
        }
    }
}
