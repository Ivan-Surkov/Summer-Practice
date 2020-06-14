using System;

namespace zadacha 4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] n = new byte[100];
            n[0] = 1;
            n[1] = 1;
            byte b;
            for (int p = 0; p < 200; p++)
            {
                b = 0;
                for (int i = 1; i <= n[0]; i++)
                {
                    b += Convert.ToByte(n[i] * 2);
                    n[i] = Convert.ToByte(b % 10);
                    b /= 10;
                }
                if (b > 0)
                {
                    n[0]++;
                    n[n[0]] = b;
                }
            }
            for (int i = n[0]; i >= 1; i--)
            {
                Console.Write(n[i]);
            }
        }
    }
}
