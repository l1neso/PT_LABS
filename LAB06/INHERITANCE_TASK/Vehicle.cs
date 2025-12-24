using System;

namespace INHERITANCE_TASK
{
    public class Vehicle
    {
        
        public string Model { get; set; }
        public int MaxSpeed { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public double FuelCapacity { get; set; }      
        public double CurrentFuel { get; set; }      
        public double FuelConsumption { get; set; }   

        
        
        public Vehicle(string model, int maxSpeed, DateTime productionDate, DateTime lastInspection, double fuelCapacity, double consumption)
        {
            Model = model;
            MaxSpeed = maxSpeed;
            ProductionDate = productionDate;
            LastInspectionDate = lastInspection;
            FuelCapacity = fuelCapacity;
            FuelConsumption = consumption;
            CurrentFuel = 0; 
        }
        
        public virtual bool IsInspectionRequired()
        {
            return (DateTime.Now - LastInspectionDate).TotalDays > 365;
        }

        public void PerformInspection()
        {
            LastInspectionDate = DateTime.Now;
            Console.WriteLine($"[INFO] {Model} прошел техосмотр. Новая дата: {LastInspectionDate.ToShortDateString()}");
        }

    
        public void Refuel(double liters)
        {
            if (CurrentFuel + liters > FuelCapacity)
            {
                CurrentFuel = FuelCapacity;
                Console.WriteLine($"[INFO] Бак {Model} залит полностью ({FuelCapacity} л).");
            }
            else
            {
                CurrentFuel += liters;
                Console.WriteLine($"[INFO] В {Model} залито {liters} л. Текущий уровень: {CurrentFuel} л.");
            }
        }

        
        public virtual bool TrySendOnTrip(double distanceKm)
        {
           
            double requiredFuel = (FuelConsumption / 100.0) * distanceKm;

            if (CurrentFuel >= requiredFuel)
            {
                CurrentFuel -= requiredFuel;
                Console.WriteLine($"[TRIP] {Model} успешно проехал {distanceKm} км. Осталось топлива: {CurrentFuel:F1} л.");
                return true;
            }
            else
            {
                Console.WriteLine($"[ERROR] {Model} не хватает топлива на {distanceKm} км! Нужно {requiredFuel:F1} л, а есть {CurrentFuel:F1} л.");
                return false;
            }
        }

        
        public override string ToString()
        {
            return $"{GetType().Name}: Модель={Model}, Скор={MaxSpeed}км/ч, Расход={FuelConsumption}л/100км";
        }
    }
}