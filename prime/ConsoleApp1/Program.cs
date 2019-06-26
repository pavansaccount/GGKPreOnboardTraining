using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0,avg = 0,j;
            String input = Console.ReadLine();
            int[] x = new int[input.Length];
            String output="";
            foreach (char c in input)
            {
                x[i] = c;
                i++;
            }
            for (i = 0; i < input.Length - 1; i++)
            {
                int count = 0;
                avg = (x[i] + x[i + 1]) / 2;
                for (j = 2; j < avg; j++)
                {
                    if (avg % j == 0)
                        count++;
                }
                if (count == 0)
                {
                    avg+=1;
                    output = output+(char)avg;
                }
                else
                    output = output+(char)avg;
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
