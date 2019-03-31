using System;
using System.IO;
using System.Linq;

namespace Luck_Balance
{
    internal class Program
    {
        private static int luckBalance(int k, int[][] contests)
        {
            int sum = 0;
            var sortedContests = contests.OrderByDescending(c => c[0]);

            foreach (var contest in sortedContests)
            {
                if (contest[1] == 1) // Important case
                {
                    if (k > 0)
                    {
                        sum += contest[0];
                        k--;
                    }
                    else
                    {
                        sum -= contest[0];
                    }
                }
                else
                {
                    sum += contest[0];
                }                
            }

            return sum;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] contests = new int[n][];

            for (int i = 0; i < n; i++)
            {
                contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
            }

            int result = luckBalance(k, contests);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
