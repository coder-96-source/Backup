using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_Anagrams
{
    internal class Program
    {
        private static int sherlockAndAnagrams(string s)
        {

        }

        private static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = sherlockAndAnagrams(s);
                Console.WriteLine(result);
                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
