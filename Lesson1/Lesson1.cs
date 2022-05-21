using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class L1Task1 : ITask
    {

        public string Name => "Алгоритм по блок-схеме.";

        public string Description => "Требуется реализовать на C# функцию согласно блок-схеме." +
                "Блок-схема описывает алгоритм проверки, простое число или нет.";

        public void RunTask() => Task1();
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
        internal class L1Task2 : ITask
        {
            public string Name => "Определить сложность функции.";

            public string Description => "Определить сложность алгоритма";

            public void RunTask()
            {
                Console.WriteLine("Ответ: Сложность алгоритма O(N^3)");
            }
        }
        /// <summary>
        /// Метод решения 3 задания
        /// </summary>

        internal class L1Task3 : ITask
        {
            public string Name => "Фибоначчи.";

            public string Description => "Вывести ряд фибоначи до n используя метод" +
                " с рекурсией и без";

            public void RunTask() => Task3();
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
        }
    }
}



