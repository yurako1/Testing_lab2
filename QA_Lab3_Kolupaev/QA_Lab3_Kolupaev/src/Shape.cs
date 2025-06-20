/// <summary>
/// Абстрактный базовый класс для геометрических фигур  
/// </summary>
/// <remarks>
/// @brief Определяет общий интерфейс для всех фигур в системе
/// @image html C:\Projects\QA_Lab3_Kolupaev\QA_Lab3_Kolupaev\doc\img\rectangle_example.png "Пример прямоугольника"
/// 
/// @dot
/// digraph G {
///   node [shape=box, fontname=Helvetica, fontsize=10];
///   edge [arrowhead=empty];
///   
///   Shape [label="Shape\n(abstract)", style=filled, fillcolor="#e0e0ff"];
///   Rectangle [label="Rectangle"];
///   
///   Shape -> Rectangle;
/// }
/// @enddot
/// </remarks>
public abstract class Shape
{
    /// <summary>
    /// @brief Отображает информацию о фигуре в консоли
    /// </summary>
    public abstract void Display();

    /// <summary>
    /// @brief Считывает параметры фигуры из пользовательского ввода
    /// </summary>
    public abstract void Read();

    /// <summary>
    /// @brief Вычисляет площадь фигуры
    /// </summary>
    /// <returns>Площадь в квадратных единицах</returns>
    public abstract int CalculateArea();
}