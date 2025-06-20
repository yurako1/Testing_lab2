using System;

namespace QA_Lab3_Kolupaev
{
    /// <summary>
    /// @brief Класс, представляющий прямоугольник в 2D-пространстве
    /// </summary>
    /// <remarks>
    /// Реализует расчет площади по формуле:
    /// \f[ S = |(x_2 - x_1)| \times |(y_2 - y_1)| \f]
    /// 
    /// @dot
    /// digraph RectangleClass {
    ///   node [shape=box, style=filled, fontname=Helvetica];
    ///   edge [color="#006400", arrowsize=0.8];
    ///
    ///   // Наследование
    ///   Shape [label="Shape\n(abstract)", fillcolor="#F0F8FF"];
    ///   Rectangle [label="Rectangle", fillcolor="#E6E6FA"];
    ///   Shape -> Rectangle [arrowhead=empty];
    ///
    ///   // Взаимодействия
    ///   Program [label="Program", fillcolor="#FFFACD"];
    ///   Program -> Rectangle [label="использует"];
    ///
    ///   // Внутренние методы
    ///   CalculateArea [label="CalculateArea()", shape=ellipse, fillcolor="#98FB98"];
    ///   Display [label="Display()", shape=ellipse, fillcolor="#98FB98"];
    ///   Rectangle -> CalculateArea [style=dotted];
    ///   Rectangle -> Display [style=dotted];
    /// }
    /// @enddot
    /// 
    /// @image html C:\Projects\QA_Lab3_Kolupaev\QA_Lab3_Kolupaev\doc\img\rect_coords.png "Система координат"
    /// </remarks>
    public class Rectangle : Shape
    {
        private int topLeftX;
        private int topLeftY;
        private int bottomRightX;
        private int bottomRightY;

        /// <summary>
        /// @brief Инициализирует прямоугольник координатами углов
        /// </summary>
        public void Init(int x1, int y1, int x2, int y2)
        {
            topLeftX = x1;
            topLeftY = y1;
            bottomRightX = x2;
            bottomRightY = y2;
        }

        /// <summary>
        /// @brief Выводит координаты углов в консоль
        /// </summary>
        public override void Display()
        {
            Console.WriteLine($"Координаты: TL({topLeftX},{topLeftY}) BR({bottomRightX},{bottomRightY})");
        }

        /// <summary>
        /// @brief Считывает 4 координаты из консоли
        /// </summary>
        public override void Read()
        {
            Console.WriteLine("Введите x1 y1 x2 y2:");
            var input = Console.ReadLine().Split();
            topLeftX = int.Parse(input[0]);
            topLeftY = int.Parse(input[1]);
            bottomRightX = int.Parse(input[2]);
            bottomRightY = int.Parse(input[3]);
        }

        /// <summary>
        /// @brief Вычисляет площадь прямоугольника
        /// </summary>
        public override int CalculateArea()
        {
            return Math.Abs((bottomRightX - topLeftX) * (topLeftY - bottomRightY));
        }

        /// <summary>
        /// @brief Расчет площади с ограничением через out-параметр
        /// </summary>
        public void CalculateSquareOut(out int rect)
        {
            rect = Math.Min(CalculateArea(), 80);
        }

        /// <summary>
        /// @brief Расчет площади с модификацией ref-параметра
        /// </summary>
        public void CalculateSquareRef(ref int rect)
        {
            rect = CalculateArea();
            if (rect > 80) rect = 80;
        }

        /// <summary>
        /// @brief Объединяет два прямоугольника в минимальный охватывающий
        /// </summary>
        public Rectangle Add(Rectangle rect1, Rectangle rect2)
        {
            return new Rectangle
            {
                topLeftX = Math.Min(rect1.topLeftX, rect2.topLeftX),
                topLeftY = Math.Max(rect1.topLeftY, rect2.topLeftY),
                bottomRightX = Math.Max(rect1.bottomRightX, rect2.bottomRightX),
                bottomRightY = Math.Min(rect1.bottomRightY, rect2.bottomRightY)
            };
        }
    }
}