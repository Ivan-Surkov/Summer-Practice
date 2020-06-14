using System;

namespace Zadacha3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите x: ");
            float x;
            while (!float.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Вы ввели неверное значение \n" + "Введите x: ");
            }

            Console.Write("Введите y: ");
            float y;
            while (!float.TryParse(Console.ReadLine(), out y))
                Console.Write("Вы ввели неверное значение \n" + "Введите y: ");

            Console.WriteLine(Math.Abs(y) >= 1 - Math.Abs(x) ? "Точка не принадлежит заданной области!" : "Точка принадлежит заданной области!");
        }
    }
}
