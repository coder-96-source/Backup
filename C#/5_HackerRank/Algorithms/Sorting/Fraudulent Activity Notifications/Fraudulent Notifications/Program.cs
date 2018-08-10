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
            bool isDayEven = (d & 1) == 0 ? true : false;
            int notice = 0;

            // Set counting array
            int range = 200;
            int[] countingArray = new int[range + 1];
            for (int i = 0; i < d - 1; i++)
            {
                countingArray[expenditure[i]]++;
            }

            int length = expenditure.Length - d;
            for (int i = 0; i < length; i++)
            {
                int index = 0;
                int count = 0;
                Predicate<bool> medianCondition = s => s
                    ? count >= d / 2
                    : count >= (d / 2) + 1;

                countingArray[expenditure[i + d - 1]]++; // Queue
                for (int j = 0; j < countingArray.Length; j++)
                {
                    if (medianCondition(isDayEven))
                    {
                        index = j;
                        break;
                    }
                    count += countingArray[j];
                }
                countingArray[expenditure[i]]--; // Dequeue

                double median = 0;
                if (isDayEven && count == d / 2)
                {
                    for (int j = index - 1; j >= 0; j--)
                    {
                        if (countingArray[j] > 0)
                        {
                            median = (double)(j + index) / 2;
                            break;
                        }
                    }
                }
                else
                {
                    median = index - 1;
                }

                if (median * 2 <= expenditure[i + d])
                {
                    notice++;
                }
            }

            return notice;
        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
            ;
            int result = activityNotifications(expenditure, d);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
