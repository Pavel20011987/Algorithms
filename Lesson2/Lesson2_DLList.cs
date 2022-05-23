using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Lesson2
{
    public class Lesson2_DLList : ILinkedList
    {
        Node FirstNode { get; set; } = null;

        Node LastNode { get; set; } = null;

        public Lesson2_DLList()
        {
            this.FirstNode = null;
            this.LastNode = null;
        }

        private Node CreateNode(int value)
        {
            Node node = new Node();
            node.Value = value;
            node.NextNode = null;
            node.PrevNode = null;
            return node;
        }
        // Метод добавления нового элемента в список
        public void AddNode(int value)
        {
            Node newNode = CreateNode(value);
            if (FirstNode == null)
            {
                FirstNode = newNode;
                LastNode = newNode;
                return;
            }
            LastNode.NextNode = newNode;
            newNode.PrevNode = LastNode;
            LastNode = newNode;
        }
        //Метод добавления нового элемента списка после определенного элемента
        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = CreateNode(value);
            node.NextNode.PrevNode = newNode;
            if (node.NextNode != null)
                newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PrevNode = node;
        }
        //Метод поиска элемента по его значению
        public Node FindNode(int searchValue)
        {
            Node currentNode = FirstNode;
            if (currentNode == null)
                return null;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }
        //Метод возврата количества элементов в списке
        public int GetCount()
        {
            int count = 0;
            Node currentNode = FirstNode;
            while (currentNode != null)
            {
                currentNode = currentNode.NextNode;
                count++;
            }
            return count;
        }
        //Метод удаления элемента по порядковому номеру
        public void RemoveNode(int index)
        {
            int n = 0;
            Node node = FirstNode;

            if (node == null)
                return;
            while (n++ < index && node != null)
                node = node.NextNode;
            RemoveNode(node);
        }
        //Метод удаления указанного элемента
        public void RemoveNode(Node node)
        {
            if (node == null)
                return;
            if (node.PrevNode != null)
                node.PrevNode.NextNode = node.NextNode;
            if (node.NextNode != null)
                node.NextNode.PrevNode = node.PrevNode;
        }
        //Метод вывода списка в консоль
        public void PrintList()
        {
            int i = 0;
            int v;
            Node node = FirstNode;
            Console.WriteLine("- - - - - - - ");
            while (node != null)
            {
                if (node.PrevNode != null)
                    v = node.PrevNode.Value;
                else
                    v = 0;
                Console.WriteLine($"{i++}:\t{node.Value}\t prev: {v}");
                node = node.NextNode;
            }
            Console.WriteLine($"---\nВ списке {GetCount()} элементов");
            Console.WriteLine("- - - - - - - ");
        }
    }
    //Создание класса для решения 1 задания 2 урока
    public class L2Task1 : ITask
    {
        public string Name => "Реализация двусвязного списка.";

        public string Description => "Требуется реализовать класс двусвязного" +
            " списка и операции вставки, удаления и поиска элемента" +
            " в нём в соответствии с интерфейсом.";
        //Метод запуска 1 задания 2 урока
        public void RunTask()
        {
            Lesson2_DLList list = new Lesson2_DLList();
            Console.WriteLine("Создадим список и добавим в него 5 элементов...");
            list.AddNode(10);
            list.AddNode(20);
            list.AddNode(30);
            list.AddNode(40);
            list.AddNode(50);
            list.PrintList();

            Console.WriteLine("Найдем элемент со значением 30 и добавим после него " +
                "элемент со значением 35");
            list.AddNodeAfter(list.FindNode(30), 35);
            list.PrintList();

            Console.WriteLine("Удалим элемент с индексом № 4");
            list.RemoveNode(4);
            list.PrintList();

            Console.WriteLine("Найдем элемент со значенем 50 и удалим его");
            list.RemoveNode(list.FindNode(50));
            list.PrintList();

            Console.WriteLine("Попробуем удалить элемент с индексом 9");
            list.RemoveNode(9);
            list.PrintList();
        }
    }
    //Реализация класса для решения 2 задания 2 урока
    public class L2Task2 : ITask
    {
        public string Name => "Реализация функции бинарного поиска.";

        public string Description => "Требуется написать функцию бинарного поиска," +
            " посчитать его асимптоматическую сложность" +
            " и проверить работоспособность функции.";
        //Метод запуска решения 2 задания 2 урока
        public void RunTask()
        {
            int[] d = new int[5]; //задание массива из 5 элемемнтов, которые введены с клавиатуры
            for (int j = 0; j < d.Length; ++j)
            {
                Console.Write("({0}) ", j + 1); //вывод на экран массива
                d[j] = int.Parse(Console.ReadLine());
            }
            Array.Sort(d); //встроенная функция сортировки
            Console.WriteLine("Отсортированный массив: "); //вывод на экран отсортированного массива
            int index = 0;
            Array.ForEach(d, x =>
            {
                Console.WriteLine("[{0}]: {1}", index++, x);
            });

            Console.Write("\nНайти: ");
            int key = int.Parse(Console.ReadLine());
            int i = BinarySearch(d, key, 0, d.Length - 1); //обращение к классу BinarySearch для поиска индекса элемента
            if (i < d.Length)
                Console.WriteLine("Индекс искомого элемента: {0}", i);
            else
                Console.WriteLine("Элемент не найден");
            Console.ReadKey(true);
        }
        static int BinarySearch(int[] d, int key, int left, int right) //бинарный поиск
        {
            int mid = left + (right - left) / 2; //находим середину вычитая из последнего элемента первый и деля на 2
            if (left >= right)//проверка условия, если левая сторона больше правой, то возвращается значение
                return -(1 + left);

            if (d[mid] == key) //если оказалось. что середина равна искомому значнию, то возвращается это значение, и поиск завершается
                return mid;

            else if (d[mid] > key)//в противном случае если середина больше искомого значения, то возвращаемся к левой части и продолжаем там алгоритм
                return BinarySearch(d, key, left, mid);
            else
                return BinarySearch(d, key, mid + 1, right);// иначе, если середина меньше искомого значения, то продолжаем поиск в правой части, так же деля массив на две части
        }
    }
}
