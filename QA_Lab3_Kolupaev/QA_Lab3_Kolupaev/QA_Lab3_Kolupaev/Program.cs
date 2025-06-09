using System;
using RectangleApp;

namespace RectangleProgram
{
    /**
    * @brief Главный класс приложения для работы с прямоугольниками
    * @details Демонстрирует:
    * - Полиморфизм через базовый класс Shape
    * - Работу с массивом фигур
    * - Создание и использование конкретного прямоугольника
    * - Интерактивный ввод данных
    */
    class Program
    {
        /**
        * @brief Точка входа в приложение
        * @param args Аргументы командной строки (не используются)
        */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                DemonstratePolymorphism();
                ProcessShapesArray();
                WorkWithConcreteRectangle();
                CreateUserRectangle();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }

        /**
        * @brief Демонстрирует принцип полиморфизма
        * @details Создает прямоугольник как экземпляр Shape и вызывает его методы
        * 
        * Использует тестовые данные:
        * - Точка A (2, 5)
        * - Точка B (10, 1)
        * - Ожидаемая площадь: 32
        * 
        */
        private static void DemonstratePolymorphism()
        {
            Console.WriteLine("1. Демонстрация полиморфизма:");
            Shape shape = new Rectangle();
            ((Rectangle)shape).Init(2, 5, 10, 1);
            shape.Display();
            shape.PrintArea();
        }

        /**
        * @brief Обрабатывает массив фигур
        * @details В текущей реализации содержит только один прямоугольник
        * с тестовыми координатами (3,6) и (8,2), площадь = 15
        */
        private static void ProcessShapesArray()
        {
            Console.WriteLine("\n2. Массив фигур:");
            Shape[] shapes = { new Rectangle() };
            ((Rectangle)shapes[0]).Init(3, 6, 8, 2);

            foreach (var shape in shapes)
            {
                shape.Display();
                shape.PrintArea();
            }
        }

        /**
        * @brief Работает с конкретным прямоугольником
        * @details Использует тестовые координаты (1,4) и (7,1),
        * ожидаемая площадь: 18
        */
        private static void WorkWithConcreteRectangle()
        {
            Console.WriteLine("\n3. Конкретный прямоугольник:");
            var rectangle = new Rectangle();
            rectangle.Init(1, 4, 7, 1);
            rectangle.Display();
            Console.WriteLine($"Площадь: {rectangle.CalculateArea()}");
        }

        /**
        * @brief Создает прямоугольник на основе пользовательского ввода
        * @details Использует метод Rectangle.Read() для ввода данных
        */
        private static void CreateUserRectangle()
        {
            Console.WriteLine("\n4. Создание пользовательского прямоугольника:");
            var userRectangle = new Rectangle();
            userRectangle.Read();
            userRectangle.Display();
            userRectangle.PrintArea();
        }
    }
}