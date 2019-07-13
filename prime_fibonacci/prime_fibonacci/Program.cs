using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Prime_Fibonacci
{
    class Program
    {
        ArrayList AL = new ArrayList();
        public static bool Prime(ulong num)
        {
            int Count = 0;
                for (ulong i = 2; i *i< num; i++)
                {
                    if (num % i == 0)
                    {
                        Count++;
                        break;
                    }
                }
            if (Count == 0)
                return true;
            else
                return false;
        }
        public static ArrayList Fibonacci(int n)
        {
            Program pro = new Program();
            ulong a = 0, b = 1, num;
            for (int i = 0; i < n; i++)
            {
                num = a + b;
                a = b;
                b = num;
                if (Prime(num) && num != 0 && num != 1)
                {
                    pro.AL.Add(num);
                }
            }
            return pro.AL;
        }
        public static void Main(string[] args)
        {
            Console.Write("Input-->");
            int Input = Int32.Parse(Console.ReadLine());
            Program pro = new Program();
            pro.AL = Fibonacci(Input);
            Console.WriteLine("Output-->");
            for (int i = 0; i < pro.AL.Count; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(pro.AL[j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
