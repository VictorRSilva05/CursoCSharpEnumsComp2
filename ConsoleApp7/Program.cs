using ConsoleApp7.Entities;
using ConsoleApp7.Entities.Enums;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name: ");
            string departament = Console.ReadLine();

            Departament dpt = new Departament(departament);

            Console.WriteLine("Enter worker's data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("How many contracts to this worker? ");
            byte n = byte.Parse(Console.ReadLine());

            Worker worker = new Worker(name, workerLevel, salary, dpt);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter {i + 1} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                double hours = double.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, value, hours);

                worker.AddContract(hourContract);
            }

            Console.Write("Enter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + dpt.Name);
            Console.WriteLine("Income for: " + monthAndYear + " = " + worker.Income(month, year));
        }
    }
}
