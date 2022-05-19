using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Lesson1
    {
        /// <summary>
        /// Метод решения 1 задания
        /// </summary>
        public static void Task1()
        {
            //Объявление переменных
            int number, d, i;
            string userAnswer;

            Console.WriteLine("Требуется реализовать на C# функцию согласно блок-схеме." +
                "Блок-схема описывает алгоритм проверки, простое число или нет.\n");
            while (true)
            {
                Console.WriteLine("Введите целое число или exit для выхода:");
                userAnswer = Console.ReadLine();
                if (int.TryParse(userAnswer, out number))
                    break;
                if (userAnswer.Trim(' ') == "exit")
                    return;
            }
            d = 0;
            i = 2;
            while (i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                Console.WriteLine($"Число {number} является простым");
            else
                Console.WriteLine($"Число {number} не является простым");

        }
        /// <summary>
        /// Метод решения 2 задания
        /// </summary>
        public static void Task2()
        {
            Console.WriteLine("Посчитайте сложность функции");
            Console.WriteLine("Ответ: Сложность алгоритма O(N^3)");
        }
        /// <summary>
        /// Метод решения 3 задания
        /// </summary>
        public static void Task3()
        {
            Console.WriteLine("Введите число число для Фибоначчи: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int numberFibo = FibonacciRecursion(number);

            Console.WriteLine(numberFibo);


        }

        //Метод поиска числа Фибоначчи с помощью рекурсии
        static int FibonacciRecursion(int number)
        {
            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                return FibonacciRecursion(number - 2) + FibonacciRecursion(number - 1);
            }
        }

        //Метод поиска числа Фибоначчи с помощью цикла
        static int FibonacciCycle(int number)
        {
            int fiboStart = 0;
            int fiboFinish = 1;
            int sum;

            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    sum = fiboStart + fiboFinish;
                    fiboStart = fiboFinish;
                    fiboFinish = sum;
                }
                return fiboFinish;
            }

        }
        /// <summary>
        /// Реализация метода, объединяющего все решения заданий
        /// </summary>
        public static void RunLesson1()
        {
            while (true)
            {
                Console.WriteLine("Введите номер задачи (1-3) или 0 для выхода:");
                if (!int.TryParse(Console.ReadLine(), out int taskNum) || taskNum < 0 || taskNum > 3)
                    continue;
                if (taskNum == 0)
                    break;
                if (taskNum == 1)
                    Task1();
                else if (taskNum == 2)
                    Task2();
                else if (taskNum == 3)
                    Task3();

                Console.WriteLine();
            }
        }
    }

}

