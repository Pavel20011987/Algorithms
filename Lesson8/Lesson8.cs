using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Lesson8
{
    public class L8Task1 : ITask
    {
       // private readonly string[] args;

        public string Name => "Алгоритмы сортировки";

        public string Description => "Реализовать алгоритм сортировки подсчетом";
      
        public void RunTask()
        {
            
            Console.Write("Введите размер массива: ");
            String inputSize = Console.ReadLine();
            int arraySize = int.Parse(inputSize);

            Random r = new Random();
            int[] integers = new int[arraySize];
            for (int i = 0; i < integers.Length; i++)
                integers[i] = r.Next(0, 9);
            int[] comparisonArray = comparisonCountingSort(integers);
            int[] distributionArray = distributionCountingSort(integers);
            showArrays(integers, comparisonArray, "Сортировка сравнением");
            showArrays(integers, distributionArray, "Сортировка распределением");
        }
        /// <summary>
        /// Реализовать метод-массив сортировка подсчетом сравнением
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static int[] comparisonCountingSort(int[] inputArray) //Excecution time for 1 million values = +1 hour 
        {
            int range = inputArray.Length;
            int[] count = new int[range];
            int[] outputArray = new int[range];
            for (int i = 0; i < range - 1; i++)
                for (int j = i + 1; j < range; j++)
                {
                    if (inputArray[i] < inputArray[j])
                        count[j] = count[j] + 1;
                    else
                        count[i] = count[i] + 1;
                }
            for (int l = 0; l < range; l++)
                outputArray[count[l]] = inputArray[l];

            return outputArray;
        }
        /// <summary>
        /// Реализовать метод-массив сортировка подсчетом распределением
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static int[] distributionCountingSort(int[] inputArray) //Excecution time for 1 million values = +1 hour
        {
            int maxValue = inputArray.Max();
            int[] countArray = new int[maxValue + 1];
            int[] outputArray = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
                countArray[inputArray[i]]++;

            for (int i = 1; i <= maxValue; i++)
                countArray[i] += countArray[i - 1];

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                int position = countArray[inputArray[i]];
                outputArray[position - 1] = inputArray[i];
                countArray[inputArray[i]]--;
            }
            return outputArray;
        }
        /// <summary>
        /// Метод showArrays
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="sortedArray"></param>
        /// <param name="sortType"></param>
        public static void showArrays(int[] inputArray, int[] sortedArray, String sortType)
        {
            Console.WriteLine("\n\n ------------" + sortType + "\n");
            Console.WriteLine("\n Сгенерированный массив: ");
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write("\t" + inputArray[i]);

            Console.WriteLine("\n Отсортированный массив: " + "\n");

            for (int i = 0; i < sortedArray.Length; i++)
                Console.Write("\t" + sortedArray[i]);
            Console.WriteLine();
        }
    }
    

}


    
