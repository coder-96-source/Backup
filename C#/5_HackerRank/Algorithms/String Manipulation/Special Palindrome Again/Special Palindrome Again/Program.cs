using System;
using System.Collections.Generic;
using System.IO;

namespace Special_Palindrome_Again
{
    internal class Program
    {
        private struct Character
        {
            public Character(char value, long count)
            {
                this.Value = value;
                this.Count = count;
            }

            public char Value { get; set; }
            public long Count { get; set; }
        }

        private static long substrCount(int n, string s)
        {
            long equalCounter = 1;
            long palindromeCount = 0;
            var characters = new List<Character>();

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == s[i]) // Eqaul to previous character
                {
                    equalCounter++;
                }
                else // End of repeated characters
                {
                    characters.Add(new Character(s[i - 1], equalCounter));
                    equalCounter = 1;
                }
            }
            characters.Add(new Character(s[s.Length - 1], equalCounter));

            // Count all of the Characters same case, Sigma n = (n(n + 1)) / 2
            characters.ForEach(p => palindromeCount += (p.Count + 1) * p.Count / 2);

            // Count all Characters except the middle one case
            for (int i = 1; i < characters.Count - 1; i++)
            {
                if (characters[i].Count == 1 // Middle one
                        && characters[i - 1].Value == characters[i + 1].Value) // Left equal to right
                {
                    palindromeCount += Math.Min(characters[i - 1].Count, characters[i + 1].Count); // Count min value between left and right
                }
            }

            return palindromeCount;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            long result = substrCount(n, s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
