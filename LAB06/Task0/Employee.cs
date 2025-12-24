namespace OOP_INHERINANCE
{
    public class Employee
    {
        private static int nextID = 1;

        public int ID { get;}
        
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfHiring { get; set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public int Expierience => DateTime.Now.Year - DateOfHiring.Year;

        public static decimal StartSalary => 1500m;

        public Employee(string name, DateTime birth, DateTime hire)
        {
            ID = nextID;
            Name = name;
            DateOfBirth = birth;
            DateOfHiring = hire;
            nextID++;
        }

        public virtual decimal SalaryBonus()
        {
            return Expierience * 0.05m * StartSalary;
        }

        public decimal TotalSalary()
        {
            return StartSalary + SalaryBonus();
        }

        public override string ToString()
        {
            return $"{GetType().Name}: ID={ID}, Name={Name}, Age={Age}, Experience={Expierience}";
        }
    }
}