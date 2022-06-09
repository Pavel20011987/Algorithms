using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Lesson7
{
    internal class EightQueens
    {
        /// <summary>
        /// Создаем переменную DeskSize
        /// </summary>
        public int DeskSize { get; }
        /// <summary>
        /// Создаем двумерный массив Desk
        /// </summary>
        private int[,] Desk;
        private int QueensOnTheDesk;
        /// <summary>
        /// Создаем список Queens
        /// </summary>
        public List<Cell> Queens = new List<Cell>();
        public List<Cell> AllCells;
        /// <summary>
        /// Создаем конструктор, принимающий в качестве входного параметра deskSize
        /// </summary>
        /// <param name="deskSize"></param>
        public EightQueens(int deskSize)
        {
            DeskSize = deskSize;
            Desk = new int[deskSize, deskSize];
            AllCells = GetFullRows();
        }
        /// <summary>
        /// Создаем метод PutQueen на шахматной доске с определенными параметрами(x, y, desk)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="desk"></param>
        /// <returns></returns>
        public bool PutQueen(int x, int y, int[,] desk)
        {
            if (desk[x, y] != 0)
                return false;
            desk[x, y] = 1;
            QueensOnTheDesk++;
            return true;
        }
        /// <summary>
        /// Создаем метод IsPointInDiagonal, возвращающий расположение ферзей на шахматной доске
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="queenX"></param>
        /// <param name="queenY"></param>
        /// <returns></returns>
        private bool IsPointInDiagonal(int x, int y, int queenX, int queenY)
        {
            return (x - queenX == y - queenY || x - queenX == (y - queenY) * -1);
        }
        /// <summary>
        /// Список, возвращающий все ячейки на шахматной доске
        /// </summary>
        /// <returns></returns>
        List<Cell> GetFullRows()
        {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < DeskSize; i++)
            {
                for (int j = 0; j < DeskSize; j++)
                    result.Add(new Cell(i, j));
            }
            return result;
        }
        /// <summary>
        /// Список, возвращающий все свободные ячейки на шахматной доске
        /// </summary>
        /// <param name="queenX"></param>
        /// <param name="queenY"></param>
        /// <param name="freeCells"></param>
        /// <returns></returns>
        List<Cell> GetFreeRows(int queenX, int queenY, List<Cell> freeCells = null)
        {
            List<Cell> result = new List<Cell>();
            foreach (Cell cell in freeCells)
            {
                if (cell.x == queenX || cell.y == queenY ||
                    IsPointInDiagonal(cell.x, cell.y, queenX, queenY))
                    continue;
                result.Add(cell);
            }
            return result;
        }
        /// <summary>
        /// Метод, расставляющий ферзей на шахматной доске
        /// </summary>
        /// <param name="count"></param>
        /// <param name="freeRows"></param>
        /// <returns></returns>
        public bool PutSomeQueens(int count, List<Cell> freeRows)
        {
            int skipCells = 0;
            if (freeRows.Count == DeskSize * DeskSize)
            {
                var rand = new Random();
                skipCells = rand.Next(freeRows.Count - 1);
            }
            if (count == 0)
                return true;
            foreach (Cell cell in freeRows)
            {
                if (skipCells-- > 0)
                    continue;
                if (PutSomeQueens(count - 1, GetFreeRows(cell.x, cell.y, freeRows)))
                {
                    Queens.Add(cell);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Метод, рисующий клетки на шахматной доске
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PrintCell(int x, int y)
        {
            if (Desk[x, y] == 0)
            {
                if ((x + y) % 2 == 0)
                    Console.Write("░░");
                else
                    Console.Write("  ");
            }
            else
                Console.Write("▓▓");
        }
        /// <summary>
        /// Метод, рисующий шахматную доску
        /// </summary>
        public void PrintDesk()
        {
            int leftBorder = DeskSize.ToString().Length + 3;
            for (int i = 0; i < DeskSize; i++)
            {
                for (int j = 0; j < DeskSize; j++)
                {
                    Console.SetCursorPosition(i * 2 + leftBorder, j + 1);
                    PrintCell(j, i);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, DeskSize + 4);
        }

        public bool TryArrangeQueens(int count)
        {
            Console.Clear();
            if (PutSomeQueens(count, AllCells))
            {
                foreach (Cell cell in Queens)
                    PutQueen(cell.x, cell.y, Desk);
                PrintBorder();
                PrintDesk();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Метод, рисующий границы шахматной доски
        /// </summary>
        private void PrintBorder()
        {
            int leftBorder = DeskSize.ToString().Length + 2;
            char letter = 'A';
            for (int i = 0; i < DeskSize; i++)
            {
                Console.SetCursorPosition(1 + leftBorder + i * 2, 0);
                Console.Write("══");
                Console.SetCursorPosition(1 + leftBorder + i * 2, DeskSize + 1);
                Console.Write("══");
                Console.SetCursorPosition(leftBorder, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(1, i + 1);
                Console.Write(DeskSize - i);
                Console.SetCursorPosition(1 + leftBorder + i * 2, DeskSize + 2);
                Console.Write(letter++);
            }
            Console.SetCursorPosition(leftBorder, 0);
            Console.Write('╔');
            Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, 0);
            Console.Write('╗');
            Console.SetCursorPosition(leftBorder, DeskSize + 1);
            Console.Write('╚');
            Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, DeskSize + 1);
            Console.Write('╝');
        }
    }
}
