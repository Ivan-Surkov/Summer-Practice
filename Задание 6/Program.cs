using System;
using Library_Functions;
namespace Library_Functions
{
    public class Functions
    {
        public static Random Rnd = new Random();

        public static void ReadInt(out int numberInteger)
        {
            bool rightInteger;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите целое число");
                rightInteger = int.TryParse(Console.ReadLine(), out numberInteger);
                if (!rightInteger)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось целое число");
                    Console.WriteLine("\n\tЭто любое число без дробной части");
                }
            }
            while (!rightInteger);
        }

        public static void ReadNatural(out int numberNatural)
        {
            bool rightNatural;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите натуральное число");
                rightNatural = int.TryParse(Console.ReadLine(), out numberNatural) && numberNatural > 0;
                if (!rightNatural)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось натуральное число");
                    Console.WriteLine("\n\tЭто целое число, которое больше 0");
                }
            }
            while (!rightNatural);
        }

        public static void ReadNonNegative(out int numberNonNegative)
        {
            bool rightNonNegative;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите неотрицательное число");
                rightNonNegative = int.TryParse(Console.ReadLine(), out numberNonNegative);
                if (numberNonNegative < 0)
                {
                    rightNonNegative = false;
                }

                if (!rightNonNegative)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось неотрицательное число");
                    Console.WriteLine("\n\tЭто целое число, которое больше или равняется 0");
                }
            }
            while (!rightNonNegative);
        }

        public static void ReadDouble(out double numberDouble)
        {
            bool rightDouble;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите действительное число");
                rightDouble = double.TryParse(Console.ReadLine(), out numberDouble);
                if (!rightDouble)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось действительное число");
                    Console.WriteLine(
                        "\n\tЭто любое число без посторонних символов, кроме символа ',' для ввода дробных чисел\n"
                        + "\n\tи '-' для ввода отрицательных чисел");
                }
            }
            while (!rightDouble);
        }

        public static int ReadAnswer(int firstPositionOfAnswer, int lastPositionOfAnswer)
        {
            bool rightAnswer;
            int numberOfAnswer;
            if (firstPositionOfAnswer > lastPositionOfAnswer)
            {
                int shelf = firstPositionOfAnswer;
                firstPositionOfAnswer = lastPositionOfAnswer;
                lastPositionOfAnswer = shelf;
            }

            do
            {
                Console.WriteLine(
                    "\n\tПожалуйста, введите номер ответа. Это целое число от {0} до {1} включительно",
                    firstPositionOfAnswer,
                    lastPositionOfAnswer);
                rightAnswer = int.TryParse(Console.ReadLine(), out numberOfAnswer)
                              && numberOfAnswer <= lastPositionOfAnswer && numberOfAnswer >= firstPositionOfAnswer;
                if (!rightAnswer)
                {
                    Console.WriteLine(
                        "\n\t\aНеверный ввод. Ожидалось целое число от {0} до {1} включительно",
                        firstPositionOfAnswer,
                        lastPositionOfAnswer);
                }
            }
            while (!rightAnswer);

            return numberOfAnswer;
        }
    }
}
namespace Задача_6
{
    class Задача13
    {
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу: ввести а1, а2, а3, М, N.\n"
                + "\n\tПостроить последовательность чисел ак = 2 * | ак–1 – ак-2 | + ак–3.\n"
                + "\n\tПостроить N элементов последовательности, либо найти первые M ее элементов,\n"
                + "\n\tкратных трем (в зависимости от того, что выполнится раньше).\n"
                + "\n\tНапечатать последовательность и причину остановки.\n"
                + "\n\tЗелёным цветом выделены члены последовательности кратные 3");

            Console.WriteLine("\n\tВвод N");
            Functions.ReadNatural(out int lengthSequence);
            int[] members = new int[lengthSequence + 3];
            int currentCountMultipleMembers = 0;
            for (int index = 0; index < 3; index++)
            {
                Console.WriteLine("\n\tВвод a{0}", index + 1);
                Functions.ReadInt(out members[index]);
                if (members[index] % 3 == 0)
                {
                    currentCountMultipleMembers++;
                }
            }

            Console.WriteLine("\n\tВвод M");
            Functions.ReadNonNegative(out int countMultipleMembers);
            int currentPosition;
            for (currentPosition = 3;
                 currentPosition < lengthSequence && countMultipleMembers > currentCountMultipleMembers;
                 currentPosition++)
            {
                members[currentPosition] = 2 * Math.Abs(members[currentPosition - 1] - members[currentPosition - 2])
                                           + members[currentPosition - 3];
                if (members[currentPosition] % 3 == 0)
                {
                    currentCountMultipleMembers++;
                }
            }

            if (currentPosition >= lengthSequence && currentCountMultipleMembers == countMultipleMembers)
            {
                Console.WriteLine(
                    "\n\tПостроение элементов последовательности закончено, т.к. программа дошла до последнего члена\n"
                    + "последовательности, а также построила нужное количество чисел кратных 3");

            }
            else
            {
                if (currentCountMultipleMembers == countMultipleMembers)
                {
                    Console.WriteLine(
                        "\n\tПостроение элементов последовательности закончено, т.к. программа построила нужное количество чисел кратных 3");
                }
                else
                {
                    Console.WriteLine(
                        "\n\tПостроение элементов последовательности закончено, т.к. программа дошла до последнего члена последовательности");
                }
            }

            for (int index = 0; index < currentPosition; index++)
            {
                if (members[index] % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine("\n\t[a{0}] - {1}", index + 1, members[index]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("\n\tКоличество построенных элементов: {0}", currentPosition);
            Console.WriteLine("\n\tКоличество элементов кратных 3: {0}", currentCountMultipleMembers);
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
