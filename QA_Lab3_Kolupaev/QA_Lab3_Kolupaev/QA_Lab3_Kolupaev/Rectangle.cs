using System;

namespace RectangleApp
{
    /**
    * @brief Класс, представляющий прямоугольник
    * @details Наследует абстрактный класс Shape.
    * Хранит координаты верхнего левого и нижнего правого углов.
    * 
    * Основные формулы:
    * - Ширина: width = bottomRightX - topLeftX
    * - Высота: height = topLeftY - bottomRightY
    * - Площадь: area = width × height
    */
    public class Rectangle : Shape
    {
        private int topLeftX;
        private int topLeftY;
        private int bottomRightX;
        private int bottomRightY;

        /**
        * @brief X-координата верхнего левого угла
        * @value Должна быть меньше BottomRightX
        */
        public int TopLeftX
        {
            get => topLeftX;
            set => topLeftX = value;
        }

        /**
        * @brief Отображает полную информацию о прямоугольнике
        * @details Формат вывода:
        * Прямоугольник:
        *   Верхний левый угол: (x, y)
        *   Нижний правый угол: (x, y)
        */
        public override void Display()
        {
            Console.WriteLine($"Прямоугольник:");
            Console.WriteLine($"  Верхний левый угол: ({topLeftX}, {topLeftY})");
            Console.WriteLine($"  Нижний правый угол: ({bottomRightX}, {bottomRightY})");
        }

        /**
        * @brief Вычисляет площадь прямоугольника
        * @return Площадь прямоугольника
        * @exception InvalidOperationException Если координаты не образуют правильный прямоугольник
        * 
        * Формула:
        *    S = (bottomRightX - topLeftX) × (topLeftY - bottomRightY)
        * 
        * Пример расчета:
        *    Для точек (2,5) и (10,1):
        *    S = (10 - 2) × (5 - 1) = 8 × 4 = 32
        * 
        * Визуализация тестового случая:
        * Результат: /image html C:\Projects\Repositories\Testing\QA_Lab3_Kolupaev\img\test.png
        */
        public override double CalculateArea()
        {
            if (bottomRightX <= topLeftX || bottomRightY >= topLeftY)
                throw new InvalidOperationException("Некорректные координаты прямоугольника");

            return (bottomRightX - topLeftX) * (topLeftY - bottomRightY);
        }

        /**
        * @brief Инициализирует прямоугольник заданными координатами
        * @param x1 X-координата верхнего левого угла
        * @param y1 Y-координата верхнего левого угла
        * @param x2 X-координата нижнего правого угла
        * @param y2 Y-координата нижнего правого угла
        * @exception ArgumentException Если x2 ≤ x1 или y2 ≥ y1
        */
        public void Init(int x1, int y1, int x2, int y2)
        {
            if (x2 <= x1 || y2 >= y1)
                throw new ArgumentException("Правый угол должен быть правее и ниже левого");

            topLeftX = x1;
            topLeftY = y1;
            bottomRightX = x2;
            bottomRightY = y2;
        }

        /**
        * @brief Считывает координаты прямоугольника из консоли
        * @details Запрашивает ввод, пока не будут введены корректные данные.
        * Формат ввода: четыре целых числа через пробел (x1 y1 x2 y2)
        * @example Пример ввода: "10 20 30 10"
        */
        public void Read()
        {
            while (true)
            {
                Console.WriteLine("Введите 4 координаты через пробел (x1 y1 x2 y2):");
                string[] coordinates = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 4 &&
                    int.TryParse(coordinates[0], out topLeftX) &&
                    int.TryParse(coordinates[1], out topLeftY) &&
                    int.TryParse(coordinates[2], out bottomRightX) &&
                    int.TryParse(coordinates[3], out bottomRightY))
                {
                    if (bottomRightX > topLeftX && bottomRightY < topLeftY)
                        return;
                    Console.WriteLine("Ошибка: правый угол должен быть правее и ниже левого!");
                }
                Console.WriteLine("Ошибка ввода! Нужно 4 целых числа.");
            }
        }
    }
}