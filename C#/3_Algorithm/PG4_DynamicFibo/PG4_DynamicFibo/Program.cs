using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG4_DynamicFibo
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = DynamicProgramming.FiboCalculator.GetFibo(0);
            Console.WriteLine(result);
        }
    }
}
