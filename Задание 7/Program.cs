using System;
using System.Collections.Generic;
using System.Linq;

namespace zadacha7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> frequencies = new List<float>();

            Console.WriteLine("Вводите частоту, пока сумма не достигнет 1");

            while (true)
            {
                float FuncSum(float a, float b) => a + b;
                float frequency = InputFloat(0, 1, FuncSum, frequencies);

                frequencies.Add(frequency);

                float sum = SumFloat(frequencies);

                if (sum == 1)
                {
                    Console.WriteLine("Сумма частот равна 1, ввод закончен");
                    break;
                }
            }

            Console.WriteLine("\nВведенные частоты:");
            frequencies.Sort();
            frequencies.Reverse();
            Console.WriteLine(String.Join(" ", frequencies));

            List<BinaryTree> tree = new List<BinaryTree>();
            foreach (var frequency in frequencies)
            {
                tree.Add(new BinaryTree(frequency));
            }

            if (tree.Count == 1)
            {
                BinaryTree first = tree[0];
                tree[0] = new BinaryTree(first.data);
                tree[0].right = first;
            }

            while (tree.Count > 1)
            {
                tree.Sort();
                BinaryTree first = tree[0];
                BinaryTree second = tree[1];

                tree[1] = new BinaryTree(first.data + second.data);
                tree[1].right = first;
                tree[1].left = second;
                tree.RemoveAt(0);
            }

            List<string> codesList = Words.GetWords(tree[0]);

            Console.WriteLine("\nРезультат: ");
            Console.WriteLine(String.Join(" ", codesList));

            Console.WriteLine("\nСредняя длина кодового слова(Код Хаффмана): " +
                              GetHuffmanLength(frequencies, codesList));

            Console.WriteLine("Длина минимальной равномерной схемы: " + GetUniformLength(codesList.Count));

            Console.ReadLine();
        }

        public class BinaryTree : IComparable
        {
            public BinaryTree left;
            public BinaryTree right;
            public float data;
            public string word;

            public BinaryTree(float d)
            {
                data = d;
            }

            public int CompareTo(object obj)
            {
                BinaryTree tree = (BinaryTree)obj;

                return data < tree.data ? -1 : data > tree.data ? 1 : 0;
            }

            public override string ToString()
            {
                return "tree: " + data;
            }
        }

        public class Words
        {
            private static List<string> words;

            public static List<string> GetWords(BinaryTree mainTree)
            {
                words = new List<string>();
                GetWordsRec(mainTree);
                return words;
            }

            private static void GetWordsRec(BinaryTree tree, string word = "")
            {

                if (tree.right == null && tree.left == null)
                {
                    tree.word = word;
                    words.Add(word);
                }

                if (tree.right != null)
                {
                    GetWordsRec(tree.right, word + "0");
                }

                if (tree.left != null)
                {
                    GetWordsRec(tree.left, word + "1");
                }
            }
        }

        public static float SumFloat(List<float> list)
        {
            return (float)Math.Round(list.Aggregate((b, a) => b + a), 3);
        }


        public static float GetHuffmanLength(List<float> frequences, List<string> codes)
        {
            float result = 0;

            codes.Sort((x, y) => x.Length < y.Length ? -1 :
                x.Length > y.Length ? 1 : 0);

            for (int i = 0; i < codes.Count; i++)
            {
                result += (frequences[i] * codes[i].Length);
            }

            return result;
        }


        public static int GetUniformLength(int codesCount)
        {
            return (int)Math.Ceiling(Math.Log(codesCount, 2));
        }

        public static float InputFloat(float min, float max, Func<float, float, float> funcSum = null,
            List<float> frequencies = null)
        {
            float num;

            while (!float.TryParse(Console.ReadLine(), out num) || num < min || num > max || funcSum != null &&
                frequencies?.Count != 0 && num + frequencies?.Aggregate(funcSum) > 1)
            {
                if (num < min || num > max)
                {
                    Console.WriteLine($"Введите число от {min} до {max}");
                    continue;
                }

                if (frequencies?.Count != 0 && funcSum != null && num + frequencies?.Aggregate(funcSum) > 1)
                {
                    Console.WriteLine(frequencies?.Aggregate(funcSum));
                    Console.WriteLine(
                        $"Введите число, чтобы сумма частот была не больше 1. Максимальное число для ввода: {Math.Round(1 - frequencies.Aggregate(funcSum), 3)}");
                    continue;
                }

                Console.WriteLine("Введите число. Если это дробное число, отделите дробную часть запятой");
            }

            return num;
        }
    }
}
