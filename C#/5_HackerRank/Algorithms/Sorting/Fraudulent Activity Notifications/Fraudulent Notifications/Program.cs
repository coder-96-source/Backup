using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraudulent_Notifications
{
    public class Program
    {
        private static int activityNotifications(int[] expenditure, int d)
        {
            int notice = 0;

            int length = expenditure.Length - d - 1;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j <= i + d; j++)
                {
                    Array.Sort(expenditure, j, d);
                    int median = expenditure[(d / 2) + j];

                    if (median > expenditure[i + d])
                    {
                        notice++;
                    }

                }
            }

            return notice;
        }

        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
            ;
            int result = activityNotifications(expenditure, d);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
