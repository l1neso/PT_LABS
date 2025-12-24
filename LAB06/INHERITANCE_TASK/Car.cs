using System;

namespace INHERITANCE_TASK
{
    public class Car : Vehicle
    {
        
        public int PassengerSeats { get; set; }

        
        public Car(string model, int maxSpeed, DateTime prodDate, DateTime lastInsp, double fuelCap, double consumption, int seats)
            : base(model, maxSpeed, prodDate, lastInsp, fuelCap, consumption)
        {
            PassengerSeats = seats;
        }

        
        public override string ToString()
        {
            return base.ToString() + $", Мест={PassengerSeats}";
        }
    }
}