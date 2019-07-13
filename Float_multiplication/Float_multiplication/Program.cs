using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float_multiplication
{
    class Program
    {
        public static string[] ToBinary(double value)
        {
            int intpart = (int)value;
            double decpart = value - intpart;
            string Binary = Convert.ToString(intpart, 2);
            string Decimal = "";
            int i;
            for (i = 0; (decpart) > 0 && i < 24; i++)
            {
                decpart = decpart * 2;
                Decimal = Decimal.ToString() + ((int)decpart).ToString();
                decpart = decpart - (int)decpart;
            }
            string[] a = new string[3];
            a[0] = Binary;
            a[1] = Decimal;
            return a;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter m value-->");
            float m = float.Parse(Console.ReadLine());
            Console.Write("Enter n value-->");
            float n = float.Parse(Console.ReadLine());
            string[] Res1 = ToBinary(m);
            Console.WriteLine("Binary value of M :" + Res1[0] + "." + Res1[1]);
            char[] c = Res1[0].ToCharArray();
            char[] d = Res1[1].ToCharArray();
            int l1 = c.Length + d.Length;
            int[] binary1 = new int[l1];
            for (int i = 0, j = 0; i < l1; i++)
            {
                if (i < c.Length)
                    binary1[i] = (int)(c[i] - '0');
                else
                {
                    binary1[i] = (int)(d[j] - '0');
                    j++;
                }
            }
            string[] Res2 = ToBinary(n);
            Console.WriteLine("Binary value of n :" + Res2[0] + "." + Res2[1]);
            char[] c1 = Res2[0].ToCharArray();
            char[] d1 = Res2[1].ToCharArray();
            int l2 = c1.Length + d1.Length;
            int[] binary = new int[l2];
            for (int i = 0, j = 0; i < l2; i++)
            {
                if (i < c1.Length)
                    binary[i] = (int)(c1[i] - '0');
                else
                {
                    binary[i] = (int)(d1[j] - '0');
                    j++;
                }
            }
            int l = l1 + l2 + 1;
            int[] binary2 = new int[l];
            for (int i = 0; i <= l1; i++)
            {
                binary2[i] = 0;
            }
            for (int i = l1 + 1, j = 0; i < l; i++, j++)
            {
                binary2[i] = (int)(binary[j]);
            }
            for (int i = 0; i < l2; i++)
            {
                if (binary2[l - 1] == 0)
                {
                    for (int j = l - 1; j > 0; j--)
                    {
                        binary2[j] = binary2[j - 1];
                    }
                    binary2[0] = 0;
                }
                else if (binary2[l - 1] == 1)
                {
                    int r = 0;
                    for (int k = l1, y = l1 - 1; k > 0; k--, y--)
                    {
                        int z = binary2[k];
                        binary2[k] = (binary2[k] + binary1[y] + r) % 2;
                        r = (z + binary1[y] + r) / 2;
                    }
                    if (r != 0)
                        binary2[0] = r;
                    for (int j = l - 1; j > 0; j--)
                    {
                        binary2[j] = binary2[j - 1];
                    }
                    binary2[0] = 0;
                }
            }
            Console.Write("Binary value of M and n after multiplication  :");
            int s = d.Length + d1.Length;
            for (int i = 0; i < l; i++)
            {
                if (l - i == s)
                    Console.Write(".");
                Console.Write(binary2[i]);
            }
            double sum = 0;
            double sum1 = 0;
            for (int p = 0, q = l - s - 1; q >= 0; q--, p++)
            {
                int t = Convert.ToInt32(binary2[q]);
                sum = sum + (t * (int)Math.Pow(2, p));
            }
            for (int p = 1, q = l - s; s > 0; q++, p++, s--)
            {
                int t = Convert.ToInt32(binary2[q]);
                sum1 = sum1 + (t / Math.Pow(2, p));
            }
            double total = sum + sum1;
            total = Math.Round(total, 4);
            Console.WriteLine();
            Console.WriteLine("Produt of M and N is :" + total);
            Console.ReadKey();
        }
    }
}



