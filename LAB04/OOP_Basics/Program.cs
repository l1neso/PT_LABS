
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("Демонстрация работы с классом Box.\n");
        
        try
        {
            // --- 1. Создание корректного объекта ---
            Console.WriteLine("Создаем первую коробку (10x20x30)...");
            Box mainBox = new Box(10, 20, 30, true);
            mainBox.PrintBox();

            // --- 2. Проверка метода IsFit() ---
            Console.WriteLine("Проверяем, поместится ли коробка 5x5x5:");
            bool fits1 = mainBox.IsFit(5, 5, 5);
            Console.WriteLine(fits1 ? "Да, поместится." : "Нет, не поместится."); // Ожидаем: Да

            Console.WriteLine("\nПроверяем, поместится ли коробка 15x25x5 (с учетом поворота):");
            bool fits2 = mainBox.IsFit(15, 25, 5); // После сортировки: {5, 15, 25} vs {10, 20, 30}
            Console.WriteLine(fits2 ? "Да, поместится." : "Нет, не поместится."); // Ожидаем: Да

            Console.WriteLine("\nПроверяем, поместится ли коробка 15x25x35:");
            bool fits3 = mainBox.IsFit(15, 25, 35);
            Console.WriteLine(fits3 ? "Да, поместится." : "Нет, не поместится."); // Ожидаем: Нет
            Console.WriteLine();


            // --- 3. Проверка изменения свойств ---
            Console.WriteLine("Изменяем высоту первой коробки на 40...");
            mainBox.Height = 40;
            mainBox.PrintBox();


            // --- 4. Демонстрация валидации (генерация исключения) ---
            Console.WriteLine("Попытка создать коробку с некорректными размерами (-5x10x10)...");
            Box invalidBox = new Box(-5, 10, 10, false);
            invalidBox.PrintBox(); // Этот код не выполнится

        }
        catch (ArgumentException ex)
        {
            // Ловим исключение, сгенерированное свойством
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОШИБКА ВАЛИДАЦИИ: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\nПрограмма завершила работу.");
    }
}