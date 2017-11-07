using System;
using System.Diagnostics;

namespace Lab10
{
    public static class StackFactory<T>
    {
        public static IStack<T> GetStack(string stackType)
        {
            IStack<T> myStack = null;

            try
            {
                switch (stackType)
                {
                    case "array":
                        myStack = new ArrayBaseStack<T>();
                        break;
                    case "list":
                        myStack = new ListBaseStack<T>();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return myStack;
        }
    }
}
