using System;

namespace INHERITANCE_TASK
{
    public class Truck : Vehicle
    {
        
        public double LoadCapacityTons { get; set; }

        public Truck(string model, int maxSpeed, DateTime prodDate, DateTime lastInsp, double fuelCap, double consumption, double loadCapacity)
            : base(model, maxSpeed, prodDate, lastInsp, fuelCap, consumption)
        {
            LoadCapacityTons = loadCapacity;
        }

        public override bool IsInspectionRequired()
        {
            return (DateTime.Now - LastInspectionDate).TotalDays > 180;
        }

       
        public override bool TrySendOnTrip(double distanceKm)
        {
            bool success = base.TrySendOnTrip(distanceKm); 
            if (success)
            {
                Console.WriteLine($"   -> Грузовик везет {LoadCapacityTons} тонн груза.");
            }
            return success;
        }

        public override string ToString()
        {
            return base.ToString() + $", Груз={LoadCapacityTons}т";
        }
    }
}