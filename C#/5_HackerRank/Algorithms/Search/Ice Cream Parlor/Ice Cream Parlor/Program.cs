using System;
using System.Collections.Generic;

namespace Ice_Cream_Parlor
{
    internal class Program
    {
        private static void whatFlavors(int[] cost, int money)
        {
            var iceCreamMenu = new Dictionary<int, int>(); // Key: cost, Value: index

            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i] >= money)
                    continue;

                if (iceCreamMenu.ContainsKey(cost[i]))
                {
                    if (cost[i] * 2 == money)
                    {
                        // Print previous and current index
                        Console.WriteLine($"{iceCreamMenu[cost[i]] + 1} {i + 1}");
                        return;
                    }
                }
                else
                {
                    int change = money - cost[i];
                    if (iceCreamMenu.ContainsKey(change))
                    {
                        // Print pair of index
                        Console.WriteLine($"{iceCreamMenu[change] + 1} {i + 1}");
                        return;
                    }

                    iceCreamMenu.Add(cost[i], i);
                }
            }
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int money = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());
                int[] cost = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), costTemp => Convert.ToInt32(costTemp));

                whatFlavors(cost, money);
            }
        }
    }
}
