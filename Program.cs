using Project.Entities;
using Project.Entities.Enums;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {

        Console.Write("Inform the worker name: ");
        string name = Console.ReadLine();

        Console.Write("Inform the worker level (JUNIOR, MID_LEVEL or SENIOR): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine().ToUpper());

        Console.Write("Inform the base salary (00.00): ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Inform the worker department: ");
        Department department = new Department(Console.ReadLine());

        Worker worker = new Worker(name, level, baseSalary, department);

        Console.Write("How many contracts do you like to insert? ");
        int contractNumber = int.Parse(Console.ReadLine());
        System.Console.WriteLine();

        for (int i = 0; i < contractNumber; i++)
        {
            System.Console.WriteLine($"Inform the data for the {i+1}º contract:");
            Console.Write("Inform the date (mm/dd/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Insert the value per hour (00.00): ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("How many hours have the contract? ");
            int hours = int.Parse(Console.ReadLine());
            HourContract contract = new HourContract(date, valuePerHour, hours);
            worker.AddContract(contract);
            System.Console.WriteLine();
        }

        System.Console.Write("Enter month and year to calculate income (mm/yyyy): ");
        string monthAndYear = Console.ReadLine();
        int month = int.Parse(monthAndYear.Substring(0,2));
        int year = int.Parse(monthAndYear.Substring(3));

        System.Console.WriteLine($"Name: {worker.Name}");
        System.Console.WriteLine($"Work Level: {worker.Level}");
        System.Console.WriteLine($"Department: {worker.Department.Name}");
        System.Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        System.Console.WriteLine();
    }
}