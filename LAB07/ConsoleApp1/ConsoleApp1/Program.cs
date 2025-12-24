using System;
using System.Collections.Generic;
using System.Linq;

// Интерфейс для зашифрованных файлов и папок
public interface IEncrypted
{
    string Password { get; set; }
    bool CheckPassword(string inputPassword);
}

// Базовый класс File
public abstract class File
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public double SizeMB { get; set; }
    public DateTime CreationDate { get; set; }
    public string Content { get; set; }

    public virtual void Open()
    {
        Console.WriteLine($"Открываем файл {Name}.{Extension}");
        Console.WriteLine($"Содержимое: {Content}");
    }

    public override string ToString()
    {
        return $"{Name}.{Extension} | Размер: {SizeMB} MB | Создан: {CreationDate:dd.MM.yyyy}";
    }
}

// Класс текстового документа
public class TextDocument : File
{
    public int PageCount { get; set; }
    public string Font { get; set; }
    public int FontSize { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" | Страниц: {PageCount} | Шрифт: {Font}";
    }
}

// Класс фотографии с шифрованием
public class Photo : File, IEncrypted
{
    public string Resolution { get; set; }
    public string CameraModel { get; set; }
    public bool IsColor { get; set; }
    public string Password { get; set; }

    public bool CheckPassword(string inputPassword)
    {
        return Password == inputPassword;
    }

    public override void Open()
    {
        Console.WriteLine($"Попытка открыть фото {Name}.{Extension}");

        if (!string.IsNullOrEmpty(Password))
        {
            Console.Write("Введите пароль: ");
            string input = Console.ReadLine();

            if (CheckPassword(input))
            {
                Console.WriteLine($"Фото открыто. Разрешение: {Resolution}");
                Console.WriteLine($"Содержимое: {Content}");
            }
            else
            {
                Console.WriteLine("Неверный пароль! Фото не открыто.");
            }
        }
        else
        {
            Console.WriteLine($"Фото открыто. Разрешение: {Resolution}");
            Console.WriteLine($"Содержимое: {Content}");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" | Разрешение: {Resolution} | Камера: {CameraModel}";
    }
}

// Класс видео с шифрованием
public class Video : File, IEncrypted
{
    public TimeSpan Duration { get; set; }
    public string Resolution { get; set; }
    public string Codec { get; set; }
    public string Password { get; set; }

    public bool CheckPassword(string inputPassword)
    {
        return Password == inputPassword;
    }

    public override void Open()
    {
        Console.WriteLine($"Попытка открыть видео {Name}.{Extension}");

        if (!string.IsNullOrEmpty(Password))
        {
            Console.Write("Введите пароль: ");
            string input = Console.ReadLine();

            if (CheckPassword(input))
            {
                Console.WriteLine($"Видео открыто. Длительность: {Duration:mm\\:ss}");
                Console.WriteLine($"Содержимое: {Content}");
            }
            else
            {
                Console.WriteLine("Неверный пароль! Видео не открыто.");
            }
        }
        else
        {
            Console.WriteLine($"Видео открыто. Длительность: {Duration:mm\\:ss}");
            Console.WriteLine($"Содержимое: {Content}");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" | Длительность: {Duration:mm\\:ss} | Разрешение: {Resolution}";
    }
}

// Класс аудио
public class Audio : File
{
    public TimeSpan Duration { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" | Длительность: {Duration:mm\\:ss} | Исполнитель: {Artist}";
    }
}

// Класс папки с шифрованием
public class Folder : IEncrypted
{
    private List<File> files;
    public string Name { get; set; }
    public string Password { get; set; }

    public Folder(string name)
    {
        Name = name;
        files = new List<File>();
    }

    public bool CheckPassword(string inputPassword)
    {
        return Password == inputPassword;
    }

    // Метод для добавления файла в папку
    public void AddToFolder(File f)
    {
        if (!files.Contains(f))
        {
            files.Add(f);
            Console.WriteLine($"Файл {f.Name}.{f.Extension} добавлен в папку {Name}");
        }
        else
        {
            Console.WriteLine($"Файл {f.Name}.{f.Extension} уже существует в папке {Name}");
        }
    }

    // Метод для удаления файла из папки
    public void DeleteFromFolder(File f)
    {
        if (files.Remove(f))
        {
            Console.WriteLine($"Файл {f.Name}.{f.Extension} удален из папки {Name}");
        }
        else
        {
            Console.WriteLine($"Файл {f.Name}.{f.Extension} не найден в папке {Name}");
        }
    }

    // Метод для вычисления суммарного веса папки
    public double CalculateTotalCapacity()
    {
        double total = 0;
        foreach (var file in files)
        {
            total += file.SizeMB;
        }
        return total;
    }

    // Метод для получения всех видеофайлов
    public List<File> GetAllVideos()
    {
        return files.Where(f => f is Video).ToList();
    }

    // Метод для открытия папки (с сортировкой по дате создания)
    public void OpenFolder()
    {
        Console.WriteLine($"\nПопытка открыть папку '{Name}'");

        if (!string.IsNullOrEmpty(Password))
        {
            Console.Write("Введите пароль для папки: ");
            string input = Console.ReadLine();

            if (!CheckPassword(input))
            {
                Console.WriteLine("Неверный пароль! Доступ к папке запрещен.");
                return;
            }
        }

        Console.WriteLine($"\n=== Содержимое папки '{Name}' (отсортировано по дате создания) ===");

        var sortedFiles = files.OrderBy(f => f.CreationDate).ToList();

        if (sortedFiles.Count == 0)
        {
            Console.WriteLine("Папка пуста");
        }
        else
        {
            foreach (var file in sortedFiles)
            {
                Console.WriteLine($"  - {file}");
            }
        }

        Console.WriteLine($"Общий размер: {CalculateTotalCapacity():F2} MB\n");
    }

    // Переопределение операторов == и !=
    public static bool operator ==(Folder folder1, Folder folder2)
    {
        if (ReferenceEquals(folder1, null) && ReferenceEquals(folder2, null))
            return true;
        if (ReferenceEquals(folder1, null) || ReferenceEquals(folder2, null))
            return false;

        return Math.Abs(folder1.CalculateTotalCapacity() - folder2.CalculateTotalCapacity()) < 0.01;
    }

    public static bool operator !=(Folder folder1, Folder folder2)
    {
        return !(folder1 == folder2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Folder other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return CalculateTotalCapacity().GetHashCode();
    }
}

// Основной класс программы
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Тестирование файловой системы ===\n");

        // Создаем файлы
        var textDoc = new TextDocument
        {
            Name = "Документ",
            Extension = "docx",
            SizeMB = 2.5,
            CreationDate = new DateTime(2024, 1, 15),
            Content = "Это текстовый документ с важной информацией.",
            PageCount = 10,
            Font = "Arial",
            FontSize = 12
        };

        var photo1 = new Photo
        {
            Name = "Отпуск",
            Extension = "jpg",
            SizeMB = 4.2,
            CreationDate = new DateTime(2024, 2, 20),
            Content = "Фото с отдыха на море.",
            Resolution = "1920x1080",
            CameraModel = "Canon EOS 5D",
            IsColor = true,
            Password = "1234" // Защищено паролем
        };

        var video1 = new Video
        {
            Name = "Концерт",
            Extension = "mp4",
            SizeMB = 150.0,
            CreationDate = new DateTime(2024, 3, 10),
            Content = "Запись живого концерта.",
            Duration = TimeSpan.FromMinutes(45),
            Resolution = "1920x1080",
            Codec = "H.264",
            Password = "qwerty" // Защищено паролем
        };

        var audio1 = new Audio
        {
            Name = "Песня",
            Extension = "mp3",
            SizeMB = 8.5,
            CreationDate = new DateTime(2024, 1, 5),
            Content = "Аудиозапись музыкальной композиции.",
            Duration = TimeSpan.FromMinutes(3.5),
            Artist = "The Beatles",
            Album = "Abbey Road"
        };

        var photo2 = new Photo
        {
            Name = "Портрет",
            Extension = "png",
            SizeMB = 3.8,
            CreationDate = new DateTime(2024, 2, 28),
            Content = "Портретное фото.",
            Resolution = "1280x720",
            CameraModel = "Nikon D850",
            IsColor = true
            // Без пароля
        };

        var video2 = new Video
        {
            Name = "Интервью",
            Extension = "avi",
            SizeMB = 120.0,
            CreationDate = new DateTime(2024, 3, 15),
            Content = "Интервью с известным человеком.",
            Duration = TimeSpan.FromMinutes(30),
            Resolution = "1280x720",
            Codec = "MPEG-4"
            // Без пароля
        };

        var audio2 = new Audio
        {
            Name = "Подкаст",
            Extension = "wav",
            SizeMB = 15.0,
            CreationDate = new DateTime(2024, 2, 10),
            Content = "Запись подкаста о технологиях.",
            Duration = TimeSpan.FromMinutes(60),
            Artist = "TechTalk",
            Album = "Выпуск 42"
        };

        // Создаем папки
        var folder1 = new Folder("Рабочие документы")
        {
            Password = "admin123" // Папка с паролем
        };

        var folder2 = new Folder("Медиатека");
        // Папка без пароля

        // Добавляем файлы в первую папку
        Console.WriteLine("Добавление файлов в первую папку:");
        folder1.AddToFolder(textDoc);
        folder1.AddToFolder(photo1);
        folder1.AddToFolder(video1);
        folder1.AddToFolder(audio1);
        folder1.AddToFolder(photo2);

        // Пытаемся добавить тот же файл повторно
        folder1.AddToFolder(textDoc);

        Console.WriteLine();

        // Добавляем файлы во вторую папку
        Console.WriteLine("Добавление файлов во вторую папку:");
        folder2.AddToFolder(video2);
        folder2.AddToFolder(audio2);
        folder2.AddToFolder(photo1); // Этот файл уже в первой папке
        folder2.AddToFolder(video1);
        folder2.AddToFolder(photo2);

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Тестируем открытие защищенных файлов
        Console.WriteLine("Тестирование открытия защищенных файлов:");
        Console.WriteLine("\n1. Открытие фото с паролем (правильный пароль: 1234):");
        photo1.Open();

        Console.WriteLine("\n2. Открытие видео с паролем (правильный пароль: qwerty):");
        video1.Open();

        Console.WriteLine("\n3. Открытие фото без пароля:");
        photo2.Open();

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Тестируем открытие папок
        Console.WriteLine("Тестирование открытия папок:");
        Console.WriteLine("\n1. Открытие папки с паролем (правильный пароль: admin123):");
        folder1.OpenFolder();

        Console.WriteLine("\n2. Открытие папки без пароля:");
        folder2.OpenFolder();

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Тестируем другие методы
        Console.WriteLine("Тестирование дополнительных методов:");

        Console.WriteLine($"\nОбщий размер первой папки: {folder1.CalculateTotalCapacity():F2} MB");
        Console.WriteLine($"Общий размер второй папки: {folder2.CalculateTotalCapacity():F2} MB");

        Console.WriteLine("\nВидеофайлы в первой папке:");
        var videosInFolder1 = folder1.GetAllVideos();
        foreach (var video in videosInFolder1)
        {
            Console.WriteLine($"  - {video}");
        }

        Console.WriteLine("\nВидеофайлы во второй папке:");
        var videosInFolder2 = folder2.GetAllVideos();
        foreach (var video in videosInFolder2)
        {
            Console.WriteLine($"  - {video}");
        }

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Тестируем операторы сравнения
        Console.WriteLine("Тестирование сравнения папок:");
        Console.WriteLine($"Папка '{folder1.Name}' == Папка '{folder2.Name}': {folder1 == folder2}");
        Console.WriteLine($"Папка '{folder1.Name}' != Папка '{folder2.Name}': {folder1 != folder2}");

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Тестируем удаление файла
        Console.WriteLine("Тестирование удаления файла из папки:");
        folder1.DeleteFromFolder(textDoc);
        folder1.DeleteFromFolder(textDoc); // Второй раз - файла уже нет

        Console.WriteLine("\nСодержимое первой папки после удаления:");
        folder1.OpenFolder();

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("Тестирование завершено!");
    }
}