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

    }
}
