using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PG3_PInvoke
{
    class Program
    {
        [DllImport("MyCLibrary.dll")]
        public static extern float ConvertFahrenheitToCelsius(float f);
        [DllImport("MyCLibrary.dll")]
        public static extern float ConvertCelsiusToFahrenheit(float c);

        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            const float DEGREE = 82.50F;
            float f = ConvertCelsiusToFahrenheit(DEGREE); // Fahrenheit
            float c = ConvertFahrenheitToCelsius(f); // Celsius

            Console.WriteLine("Convert Celsius To Fahrenheit    {0}   ->   {1}", c, f);
            Console.WriteLine("Convert Fahrenheit To Celsius    {0}   ->   {1}", f, c);
        }
    }
}
