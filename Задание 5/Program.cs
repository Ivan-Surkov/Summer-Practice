using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zadacha5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n ");
            int k = 0;
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            int max = a[0, 0];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    k++;
                    a[i, j] = k;
                    if (i + j > n - 1)// если не нужна диагональ просто оставь "<"
                    {
                        if (max < a[i, j]) max = a[i, j];
                    }
                    Console.Write("{0,2:d} ", a[i, j]);

                }
            }
            Console.WriteLine("\n max={0}", max);
            Console.ReadLine();
        }
    }
}

