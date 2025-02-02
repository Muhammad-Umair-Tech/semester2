using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppWeek3
{
    public class InventoryManager
    {
        public Car AddCar()
        {
            FileManagement fm = new FileManagement();
            Car car = new Car();

            Console.Write("Enter car name: ");
            car.name = Console.ReadLine();
            Console.Write("Enter company name: ");
            car.company = Console.ReadLine();
            Console.Write("Enter engine capacity(CC): ");
            car.engine = int.Parse(Console.ReadLine());
            Console.Write("Enter 1 for automatic and 0 for manual build: ");
            car.isAutomatic = Console.ReadLine() == "true";
            Console.Write("Enter 1 for petrol, 2 for hybrid and 3 for electric fuel: ");
            car.fuel = int.Parse(Console.ReadLine());
            fm.AppendInventoryFile(car);
            return car;
        }


        public void ViewCar(Car car)
        {
            Console.Write($"\t{car.company}\t\t{car.name}\t\t{car.engine}\t\t\t");
            if (car.isAutomatic == true) // checking wether the car is automatic (type)
            {
                Console.Write("Automatic");
            }
            else
            {
                Console.Write("Manual   ");
            }
            Console.Write("\t\t");
            if (car.fuel == 1)
            {
                Console.Write("Petrol     ");
            }
            else if (car.fuel == 2)
            {
                Console.Write("Hybrid     ");
            }
            else if (car.fuel == 3)
            {
                Console.Write("Electric   ");
            }
            Console.Write($"\t{car.price}\n");
        }


        public void EditCar(Car car)
        {
            Console.WriteLine("Editing: ");
            Console.Write("Enter car name: ");
            car.name = Console.ReadLine();
            Console.Write("Enter company name: ");
            car.company = Console.ReadLine();
            Console.Write("Enter engine capacity(CC): ");
            car.engine = int.Parse(Console.ReadLine());
            Console.Write("Enter 1 for automatic and 0 for manual build: ");
            car.isAutomatic = Console.ReadLine() == "true";
            Console.Write("Enter 1 for petrol, 2 for hybrid and 3 for electric fuel: ");
            car.fuel = int.Parse(Console.ReadLine());
        }
    }
}
