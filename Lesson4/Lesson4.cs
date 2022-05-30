using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Diagnosers;
using Algorithms.Lesson4;

namespace Algorithms.Lesson4
{
    internal class Lesson4
    {
    }

    public class L4Task1 : ITask
    {
        private readonly string[] args;

        public string Name => "HashSet в массиве";

        public string Description => "Заполните массив и HashSet случайными строками, не менее 10 000 строк.Строки можно \n" +
            "сгенерировать.Потом выполните замер производительности проверки наличия строки в массиве и \n" +
            "HashSet.Выложите код и результат замеров";

        public void RunTask()
        {
            BenchmarkDotNet.Running.BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

        //{


        //   BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        //    [MemoryDiagnoser] //Оставил для будущих экспериментов.
        //    [Config(typeof(MyConfig))]


    }
}

public class L4Task2 : Algorithms.ITask
{
    public string Name => "Бинарное дерево";

    public string Description => "Реализуйте класс двоичного дерева поиска с \n" +
        "операциями вставки, удаления, поиска. Также напишите метод вывода в \n" +
        "консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.";

    public void RunTask()
    {
        BTree tree = new BTree(null);
        string userAnswer;
        int userAnswerInt;
        while (true)
        {

            Console.Clear();
            Console.WriteLine(this.Description + "\n");
            Console.WriteLine("1. Добавить элементы в дерево;");
            Console.WriteLine("2. Удалить элемент из дерева;");
            Console.WriteLine("3. Поискать элемент в дереве;\n");
            Console.WriteLine("Введите номер пункта или 0 для выхода.");
            userAnswer = Console.ReadLine();
            if (!int.TryParse(userAnswer, out userAnswerInt))
                continue;
            if (userAnswerInt == 0)
                break;
            if (userAnswerInt == 1)
                AddToTree(tree);
            if (userAnswerInt == 2)
                DelFromTree(tree);
            if (userAnswerInt == 3)
                TreeSearch(tree);
        }
    }

    private void AddToTree(BTree tree)
    {
        string userAnswer;

        while (true)
        {
            tree.PrintTree();
            Console.WriteLine($"Кол-во элементов в дереве: " +
                $"{tree.GetCount(tree.Root)}");
            Console.WriteLine("Введите уникальное целое число для " +
                "добавления в дерево или e для выхода:");
            userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "e" || userAnswer.ToLower() == "е")
                break;
            if (!int.TryParse(userAnswer, out int userAnswerInt))
                continue;
            tree.AddNode(userAnswerInt);
        }
    }

    private void DelFromTree(BTree tree)
    {
        string userAnswer;

        while (true)
        {
            Console.Clear();
            if (tree.GetCount(tree.Root) == 0)
            {
                Console.WriteLine("Милорд, наше дерево опустело! " +
                    "Нам нужны новые числа!");
                Console.ReadKey();
                break;
            }

            tree.PrintTree();
            Console.WriteLine($"Кол-во элементов в дереве: " +
                $"{tree.GetCount(tree.Root)}");
            Console.WriteLine("Введите число для удаления элемента из дерева " +
                "или e для выхода:");
            userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "e" || userAnswer.ToLower() == "е")
                break;
            if (!int.TryParse(userAnswer, out int userAnswerInt))
                continue;
            tree.DeleteNode(userAnswerInt);
        }
    }

    private void TreeSearch(BTree tree)
    {
        string userAnswer;

        while (true)
        {
            Console.Clear();
            if (tree.GetCount(tree.Root) == 0)
            {
                Console.WriteLine("Милорд, наше дерево опустело! " +
                    "Нам нужны новые числа!");
                Console.ReadKey();
                break;
            }

            tree.PrintTree();
            Console.WriteLine($"Кол-во элементов в дереве: " +
                $"{tree.GetCount(tree.Root)}");
            Console.WriteLine("Введите число для поиска или e для выхода:");
            userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "e" || userAnswer.ToLower() == "е")
                break;
            if (!int.TryParse(userAnswer, out int userAnswerInt))
                continue;
            if (tree.Search(userAnswerInt, tree.Root) == null)
                Console.WriteLine("Такого элемента нет...");
            else
                Console.WriteLine("Такой элемент есть!");
            Console.WriteLine("\nНажмите любую кливишу...");
            Console.ReadKey();

        }
    }
}
