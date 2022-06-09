using Algorithms.Lesson2;
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
using System.Reflection;



namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Assembly asm = Assembly.LoadFrom("../../DLL/HomeWorkLib.dll");
            Type HWRunner = asm.GetType("HomeWorkLib.HomeWorkRunner", true, true);
            object obj = Activator.CreateInstance(HWRunner);
            MethodInfo method = HWRunner.GetMethod("RunLessons");
            method.Invoke(obj, new object[] { });
            //    int lessonNumber;
            //    string userAnswer;

            //    List<ILesson> lessons = BuildLessons();
            //    while (true)
            //    {
            //        Console.Clear();
            //        foreach (ILesson lesson in lessons)
            //            Console.WriteLine(lesson.Name);
            //        Console.WriteLine("\nВведите номер урока или 0 для выхода:");
            //        userAnswer = Console.ReadLine();
            //        if (userAnswer == "0")
            //            break;
            //        if (!int.TryParse(userAnswer, out lessonNumber))
            //            continue;
            //        foreach (ILesson lesson in lessons)
            //        {
            //            if (lesson.Id == lessonNumber)
            //            {
            //                Console.Clear();
            //                lesson.RunLesson();
            //                Console.Clear();
            //            }
            //        }
            //    }
            //}
            //static List<ILesson> BuildLessons()
            //{
            //    List<ILesson> lessons = new List<ILesson>();
            //    lessons.Add(BuildLesson1());
            //    lessons.Add(BuildLesson2());
            //    lessons.Add(BuildLesson3());
            //    lessons.Add(BuildLesson4());
            //    lessons.Add(BuildLesson5());
            //    return (lessons);
            //}
            //static ILesson BuildLesson1()
            //{
            //    Lesson lesson1 = new Lesson("Урок 1. Блок-схемы," +
            //        " асимптоматическая сложность, рекурсия", 1);
            //    L1Task1 task1 = new L1Task1();
            //    L1Task2 task2 = new L1Task2();
            //    L1Task3 task3 = new L1Task3();
            //    lesson1.TaskList.Add(task1);
            //    lesson1.TaskList.Add(task2);
            //    lesson1.TaskList.Add(task3);
            //    return (lesson1);
            //}
            //static ILesson BuildLesson2()
            //{
            //    Lesson lesson2 = new Lesson("Урок 2. Массив, список, поиск", 2);
            //    L2Task1 task1 = new L2Task1();
            //    L2Task2 task2 = new L2Task2();
            //    lesson2.TaskList.Add(task1);
            //    lesson2.TaskList.Add(task2);
            //    return (lesson2);
            //}

            //static ILesson BuildLesson3()
            //{
            //    Lesson lesson3 = new Lesson("Урок 3. Класс, структура и дистанция", 3);
            //    L3Task1 task1 = new L3Task1();
            //    lesson3.TaskList.Add(task1);
            //    return (lesson3);
            //}

            //static ILesson BuildLesson4()
            //{
            //    Lesson lesson4 = new Lesson("Урок 4. Деревья, хэш-таблицы", 4);
            //    L4Task1 task1 = new L4Task1();
            //    L4Task2 task2 = new L4Task2();
            //    lesson4.TaskList.Add(task1);
            //    lesson4.TaskList.Add(task2);
            //    return (lesson4);
            //}

            //static ILesson BuildLesson5()
            //{
            //    Lesson lesson5 = new Lesson("Урок 5. Стек, очередь, словарь и коллекции в C#", 5);
            //    L5Task1 task1 = new L5Task1();
            //    lesson5.TaskList.Add(task1);
            //    return (lesson5);
            //}
        }

    }
}

