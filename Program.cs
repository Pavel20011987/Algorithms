﻿using Algorithms.Lesson2;
using Algorithms.Lesson3;
using Algorithms.Lesson4;
using Algorithms.Lesson5;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.L1Task1;
using Algorithms.Lesson7;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userAnswer;




            List<ILesson> lessons = BuildLessons();
            while (true)
            {
                Console.Clear();
                foreach (ILesson lesson in lessons)
                    Console.WriteLine(lesson.Name);
                Console.WriteLine("\nВведите номер урока или 0 для выхода:");
                userAnswer = Console.ReadLine();
                if (userAnswer == "0")
                    break;
                if (!int.TryParse(userAnswer, out int lessonNumber))
                    continue;
                foreach (ILesson lesson in lessons)
                {
                    if (lesson.Id == lessonNumber)
                    {
                        Console.Clear();
                        lesson.RunLesson();
                        Console.Clear();
                    }
                }

            }
        }

        static List<ILesson> BuildLessons()
        {
            List<ILesson> lessons = new List<ILesson>();
            lessons.Add(new Lesson("Урок 1. Блок-схемы, асимптотическая сложность, рекурсия", 1,
                new L1Task1(), new L1Task2(), new L1Task3()));
            lessons.Add(new Lesson("Урок 2. Массив, список, поиск", 2, new L2Task1()));
            lessons.Add(new Lesson("Урок 3. Класс, структура и дистанция", 3, new L3Task1()));
            lessons.Add(new Lesson("Урок 4. Деревья, хэш-таблицы", 4, new L4Task1()));
            lessons.Add(new Lesson("Урок 5. Стек, очередь, словарь и коллекции в C#", 5, new L5Task1()));
            lessons.Add(new Lesson("Урок 7. Динамическое программирование", 7, new L7Task1()));
            return (lessons);
        }

    }
}

