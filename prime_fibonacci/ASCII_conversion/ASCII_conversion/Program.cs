using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter string");
            int i = 0, avg = 0, j;
            String input = Console.ReadLine();
            int[] x = new int[input.Length];
            int[] y= new int[input.Length - 1];
            String output = "";
            foreach (char c in input)
            {
                x[i] = c;
                i++;
            }
            Console.WriteLine("final result before cheacking prime");
            for (i = 0; i < input.Length - 1; i++)
            {
          
                avg = (x[i] + x[i + 1]) / 2;
                y[i] = avg;
                Console.WriteLine(y[i]);
            }
            //cheaking prime
            for (i = 0; i < input.Length - 1; i++)
            {
                int count = 0;
                 for (j = 2; j < y[i]; j++)
                 {
                     if (y[i] % j == 0)
                         count++;
                 }
                 if (count == 0)
                 {
                     y[i] += 1;
                     output = output + (char)y[i];
                 }
                 else
                     output = output + (char)y[i];
            }
            Console.WriteLine("final result after cheacking prime");
            for (i = 0; i < input.Length - 1; i++)
            {
                Console.WriteLine(y[i]);
            }
                Console.WriteLine(output);
                Console.ReadKey();
        }
    }
}
