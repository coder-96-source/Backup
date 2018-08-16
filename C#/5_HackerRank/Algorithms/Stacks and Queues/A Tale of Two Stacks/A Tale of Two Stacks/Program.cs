using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tale_of_Two_Stacks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string countString = Console.ReadLine();
            int count = int.Parse(countString);

            var queue = new Queue<string>();
            var stack = new Stack<string>();
            for (int i = 0; i < count; i++)
            {
                string s = Console.ReadLine();
                string[] numbers = s.Split(' ');

                switch (numbers[0])
                {
                    case "1":
                        queue.Enqueue(numbers[1]);
                        stack.Push(numbers[1]);
                        break;
                    case "2":
                        queue.Dequeue();
                        stack.Pop();
                        break;
                    case "3":
                        string print = queue.Peek();
                        Console.WriteLine(print);
                        break;
                }
            }
        }

        private static void Run()
        {

        }
    }
}
