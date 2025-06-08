using System;

namespace TestingLR2
{
    public class MinDigit
    {
        public static int Minim(int a)
        {
            int min = a % 10;
            a /= 10;
            while (a != 0)
            {
                if (a % 10 < min)
                {
                    min = a % 10;
                }
                a /= 10;
            }
            return min;
        }

        static void Main(string[] args)
        {
            // Настройка кодировки для поддержки русского языка
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Установка заголовка консоли
            Console.Title = "Поиск минимальной цифры в числе";

            try
            {
                Console.WriteLine("Введите натуральное число: ");
                int a;

                // Проверка корректного ввода числа
                while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                {
                    Console.WriteLine("Ошибка! Введите целое положительное число: ");
                }

                int minDigit = MinDigit.Minim(a);
                Console.WriteLine($"Минимальная цифра в числе {a}: {minDigit}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }
    }
}