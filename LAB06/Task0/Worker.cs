using System.Runtime.Intrinsics.Arm;

namespace OOP_INHERINANCE
{
    public class Worker : Employee
    {
        public int MonthlyShifts { get; set; }
        public Worker(string name, DateTime birth, DateTime hire, int shifts) : base(name, birth, hire)
        {
            MonthlyShifts = shifts;
        }

        public override decimal SalaryBonus()
        {
            decimal shiftBonus = 0;

            if (MonthlyShifts > 10 && MonthlyShifts <= 20)
            {
                shiftBonus = StartSalary * 0.5m;
            }

            else if (MonthlyShifts > 20)
            {
                shiftBonus = StartSalary;
            }

            return base.SalaryBonus() + shiftBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Shifts={MonthlyShifts}";
        }
    }
}