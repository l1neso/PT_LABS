
namespace OOP_INHERINANCE
{
    public class Manager : Employee
    {
        public bool HasEducation { get; set; }
        public int NumberOfEmployees { get; set; }
        public Manager(string name, DateTime birth, DateTime hire, int empCount, bool isEducated = false) : base(name, birth, hire)
        {
            NumberOfEmployees = empCount;
            HasEducation = isEducated;
        }

        public override decimal SalaryBonus()
        {
            decimal managerBonus;

            if (NumberOfEmployees > 10 && NumberOfEmployees <= 20)
            {
                managerBonus = HasEducation ? StartSalary * 1.5m : StartSalary * 2;
            }

            else if (NumberOfEmployees > 20)
            {
                managerBonus = HasEducation ? StartSalary * 3 : StartSalary * 2;
            }

            else
            {
                managerBonus = HasEducation ? StartSalary : StartSalary * 0.75m;
            }

            return base.SalaryBonus() + managerBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $"EmployeesCount={NumberOfEmployees}";
        }
    }
}