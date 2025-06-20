using System;

namespace QA_Lab3_Kolupaev
{
    /// <summary>
    /// @brief Главный класс приложения для работы с геометрическими фигурами
    /// </summary>
    /// <remarks>
    /// Демонстрирует:
    /// - Создание и инициализацию прямоугольников
    /// - Использование out/ref параметров
    /// - Операции с фигурами
    /// 
    /// @par Пример вывода:
    /// @code{.unparsed}
    /// --- Пример 1: Создание прямоугольника ---
    /// Введите координаты прямоугольника (x1 y1 x2 y2):
    /// 2 5 10 1
    /// Верхний левый угол: (2, 5)
    /// Нижний правый угол: (10, 1)
    /// Площадь: 32
    /// @endcode
    /// 
    /// @image html C:\Projects\QA_Lab3_Kolupaev\QA_Lab3_Kolupaev\doc\img\program_output.png "Скриншот работы программы"
    /// </remarks>
    class Program
    {
        /// <summary>
        /// @brief Точка входа в приложение
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        /// <remarks>
        /// Последовательность работы:
        /// 1. Создание прямоугольника с ручным вводом
        /// 2. Демонстрация out/ref параметров
        /// 3. Операция сложения прямоугольников
        /// </remarks>
        static void Main(string[] args)
        {
            // Настройка кодировки для поддержки Unicode
            ConfigureConsole();

            // Пример 1: Основной функционал
            DemoBasicRectangle();

            // Пример 2: Параметры out/ref
            DemoOutRefParameters();

            // Пример 3: Операции с фигурами
            DemoRectangleOperations();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// @brief Настраивает консоль для работы с Unicode
        /// </summary>
        /// <remarks>
        /// Устанавливает:
        /// - Кодировку вывода UTF-8
        /// - Кодировку ввода UTF-8
        /// </remarks>
        private static void ConfigureConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Демонстрация работы с прямоугольниками";
        }

        /// <summary>
        /// @brief Демонстрирует создание и расчет площади прямоугольника
        /// </summary>
        /// <remarks>
        /// Шаги:
        /// 1. Создает новый прямоугольник
        /// 2. Запрашивает координаты у пользователя
        /// 3. Выводит информацию о фигуре
        /// 4. Рассчитывает площадь
        /// </remarks>
        private static void DemoBasicRectangle()
        {
            Console.WriteLine("\n--- Пример 1: Создание прямоугольника ---");

            Rectangle rect = new Rectangle();

            try
            {
                rect.Read();
                rect.Display();
                Console.WriteLine($"Площадь: {rect.CalculateArea()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// @brief Демонстрирует работу с out и ref параметрами
        /// </summary>
        /// <remarks>
        /// Показывает:
        /// 1. Ограничение площади через out-параметр
        /// 2. Модификацию значения через ref-параметр
        /// </remarks>
        private static void DemoOutRefParameters()
        {
            Console.WriteLine("\n--- Пример 2: Методы out и ref ---");

            var rect = new Rectangle();
            rect.Init(0, 10, 10, 0);

            // Out-параметр
            rect.CalculateSquareOut(out int limitedArea);
            Console.WriteLine($"Ограниченная площадь (out): {limitedArea}");

            // Ref-параметр
            int value = 100;
            rect.CalculateSquareRef(ref value);
            Console.WriteLine($"Модифицированная площадь (ref): {value}");
        }

        /// <summary>
        /// @brief Демонстрирует операции с прямоугольниками
        /// </summary>
        /// <remarks>
        /// Включает:
        /// 1. Создание двух прямоугольников
        /// 2. Их визуализацию
        /// 3. Операцию сложения (объединения)
        /// </remarks>
        private static void DemoRectangleOperations()
        {
            Console.WriteLine("\n--- Пример 3: Операции с прямоугольниками ---");

            // Первый прямоугольник
            var rect1 = new Rectangle();
            rect1.Init(2, 8, 6, 2);
            Console.WriteLine("Прямоугольник 1:");
            rect1.Display();

            // Второй прямоугольник
            var rect2 = new Rectangle();
            rect2.Init(5, 10, 12, 4);
            Console.WriteLine("\nПрямоугольник 2:");
            rect2.Display();

            // Результат сложения
            var combined = rect1.Add(rect1, rect2);
            Console.WriteLine("\nРезультат объединения:");
            combined.Display();
            Console.WriteLine($"Площадь объединения: {combined.CalculateArea()}");
        }
    }
}