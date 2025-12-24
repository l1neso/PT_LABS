using System.Text; 
using INHERITANCE_TASK;

class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        
        Console.WriteLine("=== БЛОК 1: ИНИЦИАЛИЗАЦИЯ ТРАНСПОРТНОГО ПАРКА (10 ЭЛЕМЕНТОВ) ===");
        
        Vehicle[] vehicles = new Vehicle[10];

        
        vehicles[0] = new Car("Toyota Camry", 210, new DateTime(2018, 5, 1), DateTime.Now.AddMonths(-11), 60, 8.5, 5);
        vehicles[1] = new Truck("Volvo FH16", 140, new DateTime(2015, 3, 12), DateTime.Now.AddMonths(-7), 400, 30.0, 20); // ТО просрочен для грузовика (6 мес)
        vehicles[2] = new Motorcycle("Yamaha R1", 299, new DateTime(2020, 6, 15), DateTime.Now, 18, 6.0, false);
        vehicles[3] = new Car("Lada Vesta", 180, new DateTime(2019, 10, 1), new DateTime(2021, 1, 1), 55, 7.2, 5); // ТО просрочен для авто (365 дней)
        vehicles[4] = new Truck("KAMAZ 5490", 110, new DateTime(2021, 1, 20), DateTime.Now.AddMonths(-5), 350, 28.5, 15);
        vehicles[5] = new Car("BMW X5", 250, new DateTime(2022, 2, 2), DateTime.Now.AddDays(-1), 80, 12.0, 5);
        vehicles[6] = new Motorcycle("Ural", 120, new DateTime(1995, 4, 12), new DateTime(2018, 1, 1), 20, 8.0, true); // ТО просрочен
        vehicles[7] = new Car("Tesla Model 3", 261, new DateTime(2023, 1, 1), DateTime.Now, 0, 0, 5); // Электромобиль
        vehicles[8] = new Truck("MAN TGX", 130, new DateTime(2017, 8, 30), DateTime.Now, 380, 29.0, 18);
        vehicles[9] = new Motorcycle("Kawasaki Ninja", 280, new DateTime(2021, 5, 20), DateTime.Now.AddMonths(-1), 17, 5.8, false);

        
        foreach (var v in vehicles)
        {
            Console.WriteLine(v);
        }
        Console.WriteLine();

        
        Console.WriteLine("=== БЛОК 2: ТЕСТИРОВАНИЕ МЕТОДОВ (10 СЦЕНАРИЕВ) ===");

        // --- Тест 1: Проверка логики техосмотра для Легкового Автомобиля (365 дней) ---
        Vehicle carForTest = vehicles[3]; // Lada Vesta (ТО был в 2021)
        Console.WriteLine($"\n[1] Тест ТО Car: {carForTest.Model}. Дата ТО: {carForTest.LastInspectionDate.ToShortDateString()}");
        if (carForTest.IsInspectionRequired())
        {
            Console.WriteLine($"   -> Срок истек! Проходим ТО и обновляем дату.");
            carForTest.PerformInspection();
        }
        
        // --- Тест 2: Проверка переопределенной логики ТО для Грузовика (180 дней) ---
        Vehicle truckForTest = vehicles[1]; // Volvo FH16 (ТО был 7 месяцев назад)
        Console.WriteLine($"\n[2] Тест ТО Truck (Override): {truckForTest.Model}. Дата ТО: {truckForTest.LastInspectionDate.ToShortDateString()}");
        if (truckForTest.IsInspectionRequired())
        {
            Console.WriteLine($"   -> Срок истек! (Срок для грузовиков 6 мес). Проходим ТО.");
            truckForTest.PerformInspection();
        }
        
        // --- Тест 3: Проверка ТО для машины, у которой он свежий ---
        Vehicle freshCar = vehicles[0]; // Toyota Camry (ТО был 11 месяцев назад)
        Console.WriteLine($"\n[3] Тест ТО Fresh Car: {freshCar.Model}. Дата ТО: {freshCar.LastInspectionDate.ToShortDateString()}");
        if (!freshCar.IsInspectionRequired())
        {
            Console.WriteLine($"   -> Техосмотр не требуется. (Срок 365 дней ещё не истёк).");
        }

        // --- Тест 4: Попытка поехать с пустым баком (Должна быть ошибка) ---
        Vehicle emptyTankTruck = vehicles[4]; // KAMAZ (CurrentFuel = 0)
        Console.WriteLine($"\n[4] Тест Trip: {emptyTankTruck.Model}. Бак: {emptyTankTruck.CurrentFuel} л.");
        Console.WriteLine($"   -> Попытка поехать на 100 км:");
        emptyTankTruck.TrySendOnTrip(100);

        // --- Тест 5: Перелив бака (Проверка ограничения FuelCapacity) ---
        Vehicle refuelCar = vehicles[5]; // BMW X5 (Бак 80 л, сейчас 0)
        Console.WriteLine($"\n[5] Тест Refuel: {refuelCar.Model}. Бак: {refuelCar.FuelCapacity} л.");
        refuelCar.Refuel(50); 
        refuelCar.Refuel(50); 

        // --- Тест 6: Успешная поездка после заправки ---
        // Используем машину из Теста 5, в ней 80 л. 
        Console.WriteLine("\n[6] Тест Trip (Success): Едем на 500 км");
        refuelCar.TrySendOnTrip(500); 
        Console.WriteLine($"   -> Осталось топлива: {refuelCar.CurrentFuel:F1} л.");


        // --- Тест 7: Поездка, на которую не хватит остатка ---
        Console.WriteLine("\n[7] Тест Trip (Failure): Едем на 200 км");
        refuelCar.TrySendOnTrip(200);

        // --- Тест 8: Тест на электромобиль (расход 0) ---
        Vehicle electricCar = vehicles[7];
        Console.WriteLine($"\n[8] Тест Electric Car: {electricCar.Model}. Расход: {electricCar.FuelConsumption}");
        electricCar.TrySendOnTrip(1000); // Должен проехать, т.к. расход 0.

        // --- Тест 9: Заправка электромобиля (Должен не сработать или залиться 0) ---
        Console.WriteLine("\n[9] Тест Refuel Electric Car:");
        electricCar.Refuel(50); // Топливо не добавится, т.к. FuelCapacity = 0.

        // --- Тест 10: Проверка вывода ToString() для дочерних классов ---
        Console.WriteLine("\n[10] Тест ToString() всех классов:");
        Console.WriteLine($"   Car: {vehicles[0]}");
        Console.WriteLine($"   Truck: {vehicles[1]}");
        Console.WriteLine($"   Motorcycle: {vehicles[2]}");


        // =================================================================================
        // БЛОК 3: ДОПОЛНЕНИЕ
        // =================================================================================
        Console.WriteLine("\n=== БЛОК 3: АНАЛИТИКА ПО ПАРКУ ===");

        double totalConsumption = 0;
        foreach (var v in vehicles)
        {
            totalConsumption += v.FuelConsumption;
        }
        double averageConsumption = totalConsumption / vehicles.Length;
        Console.WriteLine($"Средний расход топлива по парку (10 ТС): {averageConsumption:F2} л/100км");

      
        Vehicle fastestVehicle = vehicles[0]; 
        
        foreach (var v in vehicles)
        {
            if (v.MaxSpeed > fastestVehicle.MaxSpeed)
            {
                fastestVehicle = v;
            }
        }
        Console.WriteLine($"Самый быстрый транспорт: {fastestVehicle.Model} (Скорость: {fastestVehicle.MaxSpeed} км/ч)");
    }
}