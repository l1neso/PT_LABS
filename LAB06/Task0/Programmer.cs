
namespace OOP_INHERINANCE
{
    public enum Level { JUNIOR, MIDDLE, SENIOR }
    public class Programmer : Employee
    {
        public Level ProgrammerLevel { get; set; }
        public Programmer(string name, DateTime birth, DateTime hire, Level level) : base(name, birth, hire)
        {
            ProgrammerLevel = level;
        }

        public override decimal SalaryBonus()
        {
            decimal levelBonus = 0;
            switch (ProgrammerLevel)
            {
                case Level.JUNIOR:
                    levelBonus = StartSalary;
                    break;
                case Level.MIDDLE:
                    levelBonus = StartSalary * 1.5m;
                    break;
                case Level.SENIOR:
                    levelBonus = StartSalary * 3m;
                    break;
            }

            return base.SalaryBonus() + levelBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Level={ProgrammerLevel}";
        }
    }
}