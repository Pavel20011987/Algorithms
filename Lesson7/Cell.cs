using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Lesson7
{
    /// <summary>
    /// Создаем класс Клетка
    /// </summary>
    internal class Cell
    {
        /// <summary>
        /// Задаем переменные x, y, а именно расположение потенциальных фигур(ферзей) как по горизонтали, так и по вертикали
        /// </summary>
        public int x { get; }
        public int y { get; }
        /// <summary>
        /// Создаем конструктор класса Cell
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
        }
        /// <summary>
        /// Реализация метода, который возвращает строку
        /// </summary>
        /// <returns>x,y</returns>
        public override string ToString()
        {
            return $"x: {x} y: {y}";
        }
    }
}
