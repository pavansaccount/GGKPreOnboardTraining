using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consecutive_prime_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 2, j, k = 0,sum = 2, output = 0, count = 0;
            int input = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[input];
            for (; i <= input; i++)
            {
                count = 0;
                for(j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        count++;
                }
                if(count == 0)
                {
                    arr[k] = i;
                    k += 1;
                }
            }

            for (k = 1; arr[k] != '\0' && sum < input; k++)
            {
                sum = sum + arr[k];
                count = 0;
                for (j = 2; j < sum; j++)
                {
                    if (sum % j == 0)
                        count++;
                }
                if (count == 0)
                {
                    output++;
                }
            }
            Console.WriteLine(output);
            Console.ReadKey(); 
        }
    }
}
