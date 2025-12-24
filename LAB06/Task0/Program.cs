using OOP_INHERINANCE;

Worker w1 = new Worker("Guiseppe Leonardi", new DateTime(1990, 6, 12), new DateTime(2013, 5, 6), 23);
Console.WriteLine(w1);
Console.WriteLine(w1.TotalSalary());

Employee w2 = new Worker("Guiseppe Leonardi", new DateTime(1995, 3, 12), new DateTime(2019, 5, 6), 18);
Console.WriteLine(w2);
Console.WriteLine(w2.TotalSalary());

Programmer p1 = new Programmer("Alison Krause", new DateTime(1990, 6, 12), new DateTime(2013, 5, 6), Level.MIDDLE);
Console.WriteLine(p1);
Console.WriteLine(p1.TotalSalary());

Employee p2 = new Programmer("Alex Dunlop", new DateTime(1995, 3, 12), new DateTime(2019, 5, 6), Level.SENIOR);
Console.WriteLine(p2);
Console.WriteLine(p2.TotalSalary());

Employee m1 = new Manager("Ritchy Mitchell", new DateTime(1995, 3, 12), new DateTime(2019, 5, 6), 12, true);
Console.WriteLine(m1);
Console.WriteLine(m1.TotalSalary());

Employee[] employees = { w1, w2, p1, p2, m1 };

decimal totalSalary = 0;

foreach (Employee emp in employees)
{
    totalSalary += emp.TotalSalary();
}

Console.WriteLine($"Average salary of unit = {totalSalary / employees.Length}");
