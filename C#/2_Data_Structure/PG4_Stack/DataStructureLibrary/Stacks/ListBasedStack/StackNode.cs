using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureLibrary.Stacks.ListBasedStack
{
    public class StackNode<T>
    {
        public StackNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public StackNode<T> Next { get; set; }
    }
}
