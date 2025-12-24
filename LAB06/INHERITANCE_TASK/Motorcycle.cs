using System;

namespace INHERITANCE_TASK
{
    public class Motorcycle : Vehicle
    {
        
        public bool HasSidecar { get; set; }

        public Motorcycle(string model, int maxSpeed, DateTime prodDate, DateTime lastInsp, double fuelCap, double consumption, bool hasSidecar)
            : base(model, maxSpeed, prodDate, lastInsp, fuelCap, consumption)
        {
            HasSidecar = hasSidecar;
        }

        public override string ToString()
        {
            string sidecarStr = HasSidecar ? "С коляской" : "Без коляски";
            return base.ToString() + $", {sidecarStr}";
        }
    }
}