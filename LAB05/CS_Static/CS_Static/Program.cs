using CS_Static;
using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        try
        {
            // Создание экземпляров CustomString
            CustomString str1 = new CustomString("Hello");
            CustomString str2 = new CustomString("World");

            Console.WriteLine("Созданы строки:");
            Console.WriteLine($"str1: {str1}");
            Console.WriteLine($"str2: {str2}");
            Console.WriteLine();

            // Проверка свойства Value
            Console.WriteLine("Проверка свойства Value:");
            Console.WriteLine($"str1.Value = {str1.Value}");
            Console.WriteLine($"str2.Value = {str2.Value}");
            Console.WriteLine();

            // Изменение значения через свойство
            str1.Value = "Привет";
            Console.WriteLine($"После изменения str1.Value: {str1}");
            Console.WriteLine();

            // Проверка оператора +
            CustomString concatenated = str1 + str2;
            Console.WriteLine("Результат str1 + str2:");
            Console.WriteLine(concatenated);
            Console.WriteLine();

            // Проверка оператора *
            CustomString repeated = str1 * 3;
            Console.WriteLine("Результат str1 * 3:");
            Console.WriteLine(repeated);
            Console.WriteLine();

            // Проверка Equals
            CustomString str3 = new CustomString("12345");
            CustomString str4 = new CustomString("67890");
            CustomString str5 = new CustomString("ABC");

            Console.WriteLine("Сравнение строк по длине:");
            Console.WriteLine($"str1 (длина {str1.Value.Length}) = {str1}");
            Console.WriteLine($"str3 (длина {str3.Value.Length}) = {str3}");
            Console.WriteLine($"str5 (длина {str5.Value.Length}) = {str5}");
            Console.WriteLine();

            Console.WriteLine($"str1.Equals(str3): {str1.Equals(str3)}");
            Console.WriteLine($"str1.Equals(str5): {str1.Equals(str5)}");
            Console.WriteLine();

            // Проверка обработки ошибок
            Console.WriteLine("Проверка обработки ошибок:");
            try
            {
                str1.Value = null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка при установке null: {ex.Message}");
            }

            try
            {
                CustomString str6 = new CustomString(null);        //Проверка обработки некорректных данных
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка при создании с null: {ex.Message}");
            }

            try
            {
                CustomString invalid = str1 * -1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка при умножении на отрицательное число: {ex.Message}");    
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        }
    }
}