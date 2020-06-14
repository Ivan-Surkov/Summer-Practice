using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, которую Вы хотите зашифровать:");
            SnakeCipher taskCipher = new SnakeCipher(Console.ReadLine());
            Console.WriteLine(@"Зашифрованное сообщение: {0}
Дешифрованное сообщение: {1}", taskCipher, taskCipher.Decrypt());
            Console.WriteLine();
            taskCipher.ShowInfo();
        }
    }
}

class SnakeCipher
{
    private char[,] cipherTable;
    private int _height;
    private int _width;
    /// <summary>
    /// Заполнение массива змейкой по диагонали
    /// </summary>
    /// <param name="cipherTable"></param>

    private void SnakecipherTableCrypt(string cur)
    {
        // Объявляем функциональные параметры: текущая строка, текущий столбец и номер символа
        int row = 0, column = 0, iter = 0;
        // Пока не достигли индексов последнего элемента
        while (row < Height - 1 || column < Width - 1)
        {
            // Спускаемся вниз по диагонали, параллельной побочной
            while (column > 0 && row < Height - 1)
                cipherTable[row++, column--] = cur[iter++];
            // Если достигли левого края или нижнего края матрицы 
            if (column == 0 || row == Height - 1)
            {
                cipherTable[row, column] = cur[iter++];
                // Если достигли нижней границы
                if (row == Height - 1)
                    // Смещаем индекс вправо
                    column++;
                else
                    // Смещаем индекс вниз
                    row++;
            }
            // Идём вверх по диагонали, параллельной побочной
            while (row > 0 && column < Width - 1)
                cipherTable[row--, column++] = cur[iter++];
            // Если достигли верхней или правой границы матрицы
            if (row == 0 || column == Width - 1)
            {
                cipherTable[row, column] = cur[iter++];
                // Если достигли правой границы
                if (column == Width - 1)
                    // Смещаемся вниз
                    row++;
                else
                    // Смещаемся вправо
                    column++;
            }
        }
        // Записываем значение в последний элемент
        cipherTable[row, column] = cur[iter++];
    }
    private string SnakecipherTableDecrypt()
    {
        // Объявляем функциональные параметры: текущая строка, текущий столбец, собираемая строка
        int row = 0, column = 0;
        string cur = "";
        // Пока не достигли индексов последнего элемента
        while (row < Height - 1 || column < Width - 1)
        {
            // Спускаемся вниз по диагонали, параллельной побочной
            while (column > 0 && row < Height - 1)
                cur += cipherTable[row++, column--];
            // Если достигли левого края или нижнего края матрицы 
            if (column == 0 || row == Height - 1)
            {
                cur += cipherTable[row, column];
                // Если достигли нижней границы
                if (row == Height - 1)
                    // Смещаем индекс вправо
                    column++;
                else
                    // Смещаем индекс вниз
                    row++;
            }
            // Идём вверх по диагонали, параллельной побочной
            while (row > 0 && column < Width - 1)
                cur += cipherTable[row--, column++];
            // Если достигли верхней или правой границы матрицы
            if (row == 0 || column == Width - 1)
            {
                cur += cipherTable[row, column];
                // Если достигли правой границы
                if (column == Width - 1)
                    // Смещаемся вниз
                    row++;
                else
                    // Смещаемся вправо
                    column++;
            }
        }
        // Записываем значение в последний элемент
        cur += cipherTable[row, column];
        return cur;
    }
    public int Width { get { return _width; } }
    public int Height { get { return _height; } }
    public SnakeCipher(string message)
    {
        _width = (int)Math.Ceiling(Math.Sqrt(message.Length));
        _height = Width;
        cipherTable = new char[Height, Width];
        message += new string('~', Width * Height - message.Length);
        SnakecipherTableCrypt(message);
    }
    public override string ToString()
    {
        string cur = "";
        foreach (var c in cipherTable)
            cur += c;
        return cur;
    }
    public string Decrypt()
    {
        return SnakecipherTableDecrypt().Replace("~", "");
    }
    public void ShowInfo()
    {
        Console.WriteLine("Таблица шифрования имеет размеры: {0}x{1}", Height, Width);
        Console.WriteLine("+" + new string('-', 2 * Width - 1) + "+");
        for (int i = 0; i < Height; ++i)
        {
            Console.Write("|");
            for (int j = 0; j < Width; ++j)
                Console.Write("{0}|", cipherTable[i, j]);
            Console.WriteLine();
            Console.WriteLine("+" + new string('-', 2 * Width - 1) + "+");
        }
        Console.WriteLine("Полученный шифр: {0}", ToString());
    }
}
