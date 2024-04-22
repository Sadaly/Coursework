using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\tВведите длину массива n: \n\t"); // если n > 0, то вывод массива не осуществляется
            uint n = Convert.ToUInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr1 = new int[arr.Length];
            int[] arr2 = new int[arr.Length];



            ArrayInit(arr, -10000, 10001);
            arr.CopyTo(arr1, 0);
            arr.CopyTo(arr2, 0);
            Console.WriteLine("\n\tСортировка пузырьком " + arr.Length +" элементов.");
            if (n < 21)
            {
                Console.WriteLine("\tИзначальный массив: ");
                ArrayPrint(arr);
                Console.WriteLine("\n\tОтсортированный массив: ");
            }
            Stopwatch stopwatch = new Stopwatch();
            ulong count = 0;
            stopwatch.Start();
            BubbleSort(arr, ref count);
            stopwatch.Stop();
            if (n < 21)
                ArrayPrint(arr);
            Console.WriteLine("\n\tВремя: " + stopwatch.ElapsedTicks + "\n\tПерестановки: " + count);
            Console.WriteLine();



            Console.WriteLine("\n\tБыстрая сортировка " + arr1.Length + " элементов.");
            if (n < 21)
            {
                Console.WriteLine("\tИзначальный массив: ");
                ArrayPrint(arr1);
                Console.WriteLine("\n\tОтсортированный массив: ");
            }
            stopwatch = new Stopwatch();
            count = 0;
            stopwatch.Start();
            QuickSort(arr1, 0, arr1.Length-1, ref count);
            stopwatch.Stop();
            if (n < 21)
                ArrayPrint(arr1);
            Console.WriteLine("\n\tВремя: " + stopwatch.ElapsedTicks + "\n\tПерестановки: " + count);
            Console.WriteLine();


            Console.WriteLine("\n\tСортировка Шела " + arr2.Length + " элементов.");
            if (n < 21)
            {
                Console.WriteLine("\tИзначальный массив: ");
                ArrayPrint(arr2);
                Console.WriteLine("\n\tОтсортированный массив: ");
            }
            stopwatch = new Stopwatch();
            count = 0;
            stopwatch.Start();
            ShellSort(arr2, ref count);
            stopwatch.Stop();
            if (n < 21)
                ArrayPrint(arr2);
            Console.WriteLine("\n\tВремя: " + stopwatch.ElapsedTicks + "\n\tПерестановки: " + count);
            Console.ReadKey();
            Console.WriteLine();
        }
        static int[] BubbleSort(int[] array, ref ulong count)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                        count++;
                    }
            return array;
        }
        static int[] QuickSort(int[] array, int leftIndex, int rightIndex, ref ulong count)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                    count++;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j, ref count);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex, ref count);
            return array;
        }
        static void ArrayInit(int[] arr, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(a, b);
        }
        static void ArrayPrint(int[] arr)
        {
            foreach (int i in arr)
                Console.Write("\t" + i);
        }
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        static int[] ShellSort(int[] array, ref ulong count)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                        count++;
                    }
                }

                d = d / 2;
            }

            return array;
        }
    }

}
