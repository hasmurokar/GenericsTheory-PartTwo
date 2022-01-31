using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsTheory2
{  
    class Program
    {
        public static double Sum<T>(T array)
        where T : IList
        {
            double sum = 0;
            foreach (var item in array)
            {
                sum += Convert.ToDouble(item);
            }
            return sum;
        }

        public static void Input<T>(ref T array)
        where T : IList
        {
            for (int i = 0; i < array.Count; i++)
            {
                var number = Console.ReadLine();
                if (int.TryParse(number, out int numInt))
                {
                    array[i] = Convert.ToInt32(numInt);
                    continue;
                }
                if (double.TryParse(number, out double numDouble))
                {
                    array[i] = Convert.ToDouble(numDouble);
                    continue;
                }
            }
        }

        public static void Print<T>(T array)
        where T : IList
        {
            Console.WriteLine("Вывод массива:");
            foreach (var item in array)
            {
                Console.WriteLine(item + "\t");
            }
        }

        public static TT Max<T, TT>(T array)
        where T : IEnumerable<TT>
        {
            return array.Max();
        }
        static void Main(string[] args)
        {
            int[] arrayInt = new int[3];
            double[] arrayDouble = new double[3];

            Console.WriteLine("Введите массив типа 'Int':");
            Input(ref arrayInt);
            Print(arrayInt);
            Console.WriteLine("Сумма = " + Sum(arrayInt));
            Console.WriteLine("Максимальный элемент = " + Max<int[], int>(arrayInt));
            Console.WriteLine("Введите массив типа 'Double':");
            Input(ref arrayDouble);
            Print(arrayDouble);
            Console.WriteLine("Сумма = " + Sum(arrayDouble));
            Console.WriteLine("Максимальный элемент = " + Max<double[], double>(arrayDouble));
            string[] arrayString = new string[3] { "Apple", "Pear", "Peach" };
            Console.WriteLine("Максимальный элемент массива типа 'String' = " + Max<string[], string>(arrayString));
            Console.ReadLine();
        }

    }
}
