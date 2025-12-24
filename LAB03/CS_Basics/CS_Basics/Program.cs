using System.Text;

namespace CS_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            bool exit = false;
            while (!exit)                 //main цикл
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("  Лабораторная работа №3 - CS_Basics");
                Console.WriteLine("  Основны языка програмирования C#");
                Console.WriteLine("========================================");              
                Console.WriteLine("Блок 1. Переменные и операторы.");
                Console.WriteLine("Блок 2. Условные операторы.");
                Console.WriteLine("Блок 3. Циклы.");
                Console.WriteLine("Блок 4. Массивы.");
                Console.WriteLine("Блок 5. Функции.");
                Console.Write("\nВыбери блок: ");

                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "1":
                        Block1();
                        break;
                    case "2":
                        Block2();
                        break;
                    case "3":
                        Block3();
                        break;
                    case "4":
                        Block4();
                        break;
                    case "5":
                        Block5();
                        break;
                    case "9":
                        exit = true;
                        Console.WriteLine("Закрывается...");
                        break;
                    default:
                        Console.WriteLine("Неправильная опция. Ввидте корректный вариант.");
                        Console.ReadKey();
                        break;
                }
            }

        }
        static void Block1()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 1. Переменные и операторы.");
                Console.WriteLine("========================================");
                Console.WriteLine("2. ИМТ");
                Console.WriteLine("4. Перевод времени");
                Console.WriteLine("6. Цена со скидкой");
                Console.WriteLine("9. Вернутся в меню");
                Console.Write("\nВыбери задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Введите вес в кг: ");
                        double.TryParse(Console.ReadLine(), out double weight);
                        Console.Write("Введите роств cm: ");                                                            //Рассчётм ИМТ
                        double.TryParse(Console.ReadLine(), out double heightCm);
                        if ((heightCm > 0) && (weight > 0))
                        {
                            double heightM = heightCm / 100.0;
                            double bmi = weight / (heightM * heightM);
                            Console.WriteLine($"ИМТ: {bmi:F1}");
                        }
                        else { Console.WriteLine("Знчение веса или роста должно быть больше нуля. Введите ещё раз:"); }
                        Pause();
                        break;
                    case "4":
                        Console.Write("Перевод времени: ");
                        if (int.TryParse(Console.ReadLine(), out int totalSeconds))
                        {
                            int hours = totalSeconds / 3600;
                            int minutes = (totalSeconds % 3600) / 60;                                            //Перевод секунд в формат времени
                            int seconds = totalSeconds % 60;
                            Console.WriteLine($"Результат: {hours:D2}:{minutes:D2}:{seconds:D2}");
                        }
                        else { Console.WriteLine("Неправильный ввод."); }
                        Pause();
                        break;
                    case "6":
                        Console.Write("Введите цену: ");
                        double.TryParse(Console.ReadLine(), out double price);
                        Console.Write("Введите процент скдики (%): ");
                        double.TryParse(Console.ReadLine(), out double discount);
                        double finalPrice = price - (price * discount / 100);                                      //цена со скидкой
                        Console.WriteLine($"Итоговая цена: {finalPrice:F2}");
                        Pause();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }

        }
        static void Block2()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 2. Условные операторы.");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Тип треугольника");
                Console.WriteLine("4. Оценка по числу");
                Console.WriteLine("6. Конвертация валют");
                Console.WriteLine("9. Вернутся в меню");
                Console.Write("\nВыбери задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Сторона A: ");
                        double.TryParse(Console.ReadLine(), out double a);
                        Console.Write("Сторона B: ");
                        double.TryParse(Console.ReadLine(), out double b);
                        Console.Write("Сторона C: ");
                        double.TryParse(Console.ReadLine(), out double c);

                        if (a + b > c && a + c > b && b + c > a)
                        {
                            if (a == b && b == c) Console.WriteLine("Равносторонний.");
                            else if (a == b || a == c || b == c) Console.WriteLine("Равнобедренный");           //ОПРЕДЕЛЕНИЕ ТИПА ТРЕУГОЛЬНИКА
                            else Console.WriteLine("Разносторонний");
                        }
                        else
                        {
                            Console.WriteLine("Стороны не создают треугольник");
                        }
                        Pause();
                        break;
                    case "4":
                        Console.Write("Введите оценку (1-5): ");
                        int.TryParse(Console.ReadLine(), out int grade);
                        switch (grade)
                        {
                            case 1: Console.WriteLine("Плохо"); break;
                            case 2: Console.WriteLine("Неудовлетворительно"); break;
                            case 3: Console.WriteLine("Удовлетворительно"); break;
                            case 4: Console.WriteLine("Хорошо"); break;
                            case 5: Console.WriteLine("Отлично"); break;
                            default: Console.WriteLine("Неправильный ввод."); break;
                        }
                        Pause();
                        break;
                    case "6":
                        Console.Write("Введите сумму в Рублях: ");
                        double.TryParse(Console.ReadLine(), out double amount);
                        Console.Write("Выберите валюту (1:USD, 2:EUR, 3:GBP): ");
                        switch (Console.ReadLine())
                        {
                            case "1": Console.WriteLine($"{amount * 0.011:F2} USD"); break;
                            case "2": Console.WriteLine($"{amount * 0.010:F2} EUR"); break;
                            case "3": Console.WriteLine($"{amount * 0.0087:F2} GBP"); break;                             //КОНВЕРТАЦИЯ ВАЛЮТ
                            default: Console.WriteLine("Неправильный ввод."); break;
                        }
                        Pause();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }
        static void Block3()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 3. Циклы.");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Переворот числа");
                Console.WriteLine("4. Максимальное нечетное");
                Console.WriteLine("6. Арифметическая прогрессия ");
                Console.WriteLine("9. Вернутся в меню");
                Console.Write("\nВыбери задачу: ");

                switch (Console.ReadLine())
                {

                    case "2":
                        Console.Write("Введите целое: ");
                        int.TryParse(Console.ReadLine(), out int numToReverse);
                        int reversed = 0;                                                              //Переворот числа
                        int inputCopy = numToReverse;
                        while (inputCopy != 0)
                        {
                            reversed = reversed * 10 + inputCopy % 10;
                            inputCopy /= 10;
                        }
                        Console.WriteLine($"Перевернутое число: {reversed}");
                        Pause();
                        break;
                    case "4":
                        Console.Write("Начало (a): ");
                        int.TryParse(Console.ReadLine(), out int start);
                        Console.Write("Конец (b): ");
                        int.TryParse(Console.ReadLine(), out int end);
                        bool found = false;                                                             //max num
                        for (int i = end; i >= start; i--)
                        {
                            if (i % 2 != 0)
                            {
                                Console.WriteLine($"Максимальное нечетное число: {i}");
                                found = true;
                                break;
                            }
                        }
                        if (!found) Console.WriteLine("Не найденно нечетных.");
                        Pause();
                        break;
                    case "6":
                        Console.Write("Количество членов ряда (n): ");
                        int.TryParse(Console.ReadLine(), out int terms);
                        Console.Write("Первый член ряда (a1): ");
                        double.TryParse(Console.ReadLine(), out double firstTerm);
                        Console.Write("Разница ряда (d): ");
                        double.TryParse(Console.ReadLine(), out double diff);

                        double currentTerm = firstTerm;                                                 //Ариф прогр
                        double progressionSum = 0;
                        Console.Write("Ряд: ");
                        for (int i = 0; i < terms; i++)
                        {
                            Console.Write(currentTerm + " ");
                            progressionSum += currentTerm;
                            currentTerm += diff;
                        }
                        Console.WriteLine($"\nСумма: {progressionSum}");
                        Pause();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }
        static void Block4()
        {
            bool back = false;
            Random rand = new Random();                                            //massiv
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 4. Массивы.");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Второй по велечине элемент");
                Console.WriteLine("4. Четные элементы в столбцах");
                Console.WriteLine("6. Диагонали матрица");
                Console.WriteLine("9. Вернутся в меню");
                Console.Write("\nВыбери задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Введите размер массива: ");
                        if (int.TryParse(Console.ReadLine(), out int size) && size >= 2)
                        {
                            int[] arr = new int[size];
                            for (int i = 0; i < size; i++) arr[i] = rand.Next(1, 101);
                            Console.WriteLine("Массив: " + string.Join(", ", arr));

                            int largest = int.MinValue;
                            int secondLargest = int.MinValue;                                 
                            foreach (int num in arr)
                            {
                                if (num > largest)
                                {
                                    secondLargest = largest;
                                    largest = num;
                                }
                                else if (num > secondLargest && num != largest)
                                {
                                    secondLargest = num;
                                }
                            }
                            Console.WriteLine($"Второй по велечине элемент: {secondLargest}");
                        }
                        else { Console.WriteLine("Размер больше двух!."); }
                        Pause();
                        break;
                    case "4":
                        Console.Write("Количество рядов: ");
                        int.TryParse(Console.ReadLine(), out int rowsEven);
                        Console.Write("Количество столбцов: ");
                        int.TryParse(Console.ReadLine(), out int colsEven);
                        if (rowsEven > 0 && colsEven > 0)
                        {
                            int[,] matrix = new int[rowsEven, colsEven];
                            Console.WriteLine("\nМатрица:");
                            for (int i = 0; i < rowsEven; i++)
                            {
                                for (int j = 0; j < colsEven; j++)
                                {
                                    matrix[i, j] = rand.Next(1, 101);
                                    Console.Write(matrix[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }

                            int[] evenCounts = new int[colsEven];
                            for (int j = 0; j < colsEven; j++)
                            {
                                for (int i = 0; i < rowsEven; i++)
                                {
                                    if (matrix[i, j] % 2 == 0)
                                    {
                                        evenCounts[j]++;
                                    }
                                }
                            }
                            Console.WriteLine("\nЧетные в столбцах: " + string.Join(", ", evenCounts));
                        }
                        Pause();
                        break;
                    case "6":
                        Console.Write("Размер матрицы (n x n): ");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            int[,] matrix = new int[n, n];
                            Console.WriteLine("\nМатрица:");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++)
                                {
                                    matrix[i, j] = rand.Next(1, 101);
                                    Console.Write(matrix[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }

                            int maxMain = int.MinValue;
                            int maxSecondary = int.MinValue;
                            for (int i = 0; i < n; i++)                                       //Работа с диагоналями матрицы    
                            {
                                if (matrix[i, i] > maxMain) maxMain = matrix[i, i];
                                if (matrix[i, n - 1 - i] > maxSecondary) maxSecondary = matrix[i, n - 1 - i];
                            }
                            Console.WriteLine($"\nМаксимальный на главной диагонали: {maxMain}");
                            Console.WriteLine($"Максимум на второй диагонали: {maxSecondary}");
                            Console.WriteLine($"Сумма: {maxMain + maxSecondary}");
                        }
                        Pause();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }
        static void Block5()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 5. Функции.");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Генерация ");
                Console.WriteLine("4. Сумма цифр числа");
                Console.WriteLine("6. Разделение числа");
                Console.WriteLine("8. Длинны строк");
                Console.WriteLine("9. Вернутся в меню");
                Console.Write("\nВыбери задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        int[] randomArray = GenerateArray(10, 1, 100);
                        Console.WriteLine("Массив: " + string.Join(", ", randomArray));
                        Pause();
                        break;
                    case "4":
                        Console.Write("Число для суммы цифр: ");
                        int.TryParse(Console.ReadLine(), out int numToSum);
                        Console.WriteLine($"Сумма: {DigitSum(numToSum)}");
                        Pause();
                        break;
                    case "6":
                        Split(123.456, out int whole, out double frac);
                        Console.WriteLine($"Число 123.456 -> Целая часть: {whole}, Дробная: {frac:F3}");
                        Pause();
                        break;
                    case "8":
                        int[] lengths = GetLengths("Hello", "World", "from", "C#");
                        Console.WriteLine("Длинна строк: " + string.Join(", ", lengths));
                        Pause();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }
        // --- Helpers for Block 5 ---
        static long Factorial(int n)
        {
            if (n < 0) return 0;
            return n == 0 ? 1 : n * Factorial(n - 1);
        }

        static int[] GenerateArray(int count, int min, int max)
        {
            Random rand = new Random();
            int[] arr = new int[count];
            for (int i = 0; i < count; i++) arr[i] = rand.Next(min, max + 1);
            return arr;
        }

        static int SumRecursive(int[] array, int index)
        {
            if (index >= array.Length) return 0;
            return array[index] + SumRecursive(array, index + 1);
        }

        static int DigitSum(int number)
        {
            number = Math.Abs(number);
            return number == 0 ? 0 : number % 10 + DigitSum(number / 10);
        }

        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }

        static void Split(double number, out int whole, out double fraction)
        {
            whole = (int)number;
            fraction = number - whole;
        }

        static int[] FilterEven(params int[] numbers)
        {
            List<int> evens = new List<int>();
            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                {
                    evens.Add(n);
                }
            }
            return evens.ToArray();
        }

        static int[] GetLengths(params string[] strings)
        {
            int[] lengths = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                lengths[i] = strings[i].Length;
            }
            return lengths;
        }



        static void Pause()
        {
            Console.WriteLine("\nНажмите любую кнопку чтобы продолжить...");
            Console.ReadKey();
        }
    }
}