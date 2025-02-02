using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppWeek3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManagement fm = new FileManagement();
            List<Car> cars = new List<Car>();
            cars = fm.LoadInventory(cars);

            string homeChoice;
            while (true)
            {
                homeChoice = HomeScreen();
                if (homeChoice == "1")
                {
                    AppTitle();
                    Console.WriteLine("CUSTOMER");
                    Console.WriteLine("Press any key to go to the home screen");
                    Console.ReadLine();
                    continue;
                }
                else if (homeChoice == "2")
                {
                    AppTitle();
                    Console.WriteLine("ADMIN");
                    homeChoice = ChoiceAdmin(cars);
                }
                else if (homeChoice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                }
                if (homeChoice == "4")
                {
                    continue;
                }
                Console.WriteLine("Press any key to go to the home screen");
                Console.ReadLine();
                continue;
            }
        }



        static string ChoiceAdmin(List<Car> cars)
        {
            string name, password;
            Console.Write("Enter admin name: ");
            name = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            FileManagement fm = new FileManagement();
            AdminManager adminManager = new AdminManager();
            InventoryManager inventoryManager = new InventoryManager();

            while (true)
            {
                if (adminManager.AdminLoginFound(name, password))
                {
                    string choice;
                    choice = AdminMenu();
                    if (choice == "1")
                    {
                        adminManager.NewAdmin();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "2")
                    {
                        adminManager.ViewAdmins();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "3") // view cars in inventory
                    {
                        int counting = 1;
                        cars.Clear();
                        cars = fm.LoadInventory(cars);
                        Console.Write("\tCompany\t\tCar\t\tEngine(cc) \t\tType\t\t\tFuel\t\tPrice(PKR)\n\n");
                        foreach (Car car in cars)
                        {
                            Console.Write(counting);
                            inventoryManager.ViewCar(car);
                            counting++;
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "4") // add a car
                    {
                        cars.Append(inventoryManager.AddCar());
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "5") // edit details of a car
                    {
                        try
                        {
                            string carToEdit;
                            int engineToEdit;
                            bool carNotFound = true;
                            Console.Write("Enter the name of the car to edit: ");
                            carToEdit = Console.ReadLine();
                            Console.Write("Enter the engine capacity of the car to edit(CC): ");
                            engineToEdit = int.Parse(Console.ReadLine());

                            foreach (Car car in cars)
                            {
                                if (carToEdit == car.name)
                                {
                                    if (engineToEdit == car.engine)
                                    {
                                        inventoryManager.EditCar(car);
                                        carNotFound = false;
                                        fm.UpdateInventoryFile(cars);
                                        Console.WriteLine("Editing successful.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                            if (carNotFound == true)
                            {
                                Console.WriteLine("No such car is available.");
                                Console.ReadLine();
                                continue;
                            }
                            continue;

                        }
                        catch (FormatException) // if the user enters a string for engine, for example
                        {
                            Console.WriteLine("Incorrect input.");
                            Console.ReadLine();
                            continue;
                        }
                    }
                    else if (choice == "6") // delete a car
                    {
                        try
                        {
                            string carToDelete;
                            int engineToDelete;
                            bool carNotFound = true;
                            Console.Write("Enter the name of the car to edit: ");
                            carToDelete = Console.ReadLine();
                            Console.Write("Enter the engine capacity of the car to edit(CC): ");
                            engineToDelete = int.Parse(Console.ReadLine());

                            foreach (Car car in cars)
                            {
                                if (car.name == carToDelete)
                                {
                                    if (car.engine == engineToDelete)
                                    {
                                        cars.Remove(car);
                                        carNotFound = false;
                                        fm.UpdateInventoryFile(cars);
                                        Console.WriteLine("Deletion successful.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                            if (carNotFound == true)
                            {
                                Console.WriteLine("No such car is available.");
                                Console.ReadLine();
                                continue;
                            }
                            continue;
                        }
                        catch (FormatException) // if the user enters a string for engine, for example
                        {
                            Console.WriteLine("Incorrect input.");
                            Console.ReadLine();
                            continue;
                        }
                    }
                    else if (choice == "7")
                    {
                        return "4";
                    }
                    Console.WriteLine("Incorrect input. Press any key to continue");
                    Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Incorrect name or password");
                    return "";
                }
            }
        }


        static string AdminMenu()
        {
            string choice;
            AppTitle();
            Console.WriteLine("ADMIN");
            Console.WriteLine("Welcome!");
            Console.WriteLine("Choose by entering the corresponding number");
            Console.WriteLine("1. New admin sign up");
            Console.WriteLine("2. View admins");
            Console.WriteLine("3. View inventory");
            Console.WriteLine("4. Add a car");
            Console.WriteLine("5. Edit details of a car");
            Console.WriteLine("6. Delete a car");
            Console.WriteLine("7. Back to home page");
            Console.Write("Choice: ");
            choice = Console.ReadLine();
            return choice;
        }


        static string HomeScreen()
        {
            string choice;
            AppTitle();
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");
            choice = Console.ReadLine();
            return choice;
        }



        static void AppTitle()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t ###  #   # ##### ##### ##   ## ##### ####  # #     #####        ####  #####  ###  #     ##### ####   ###  #   # # ####  ");
            Console.WriteLine("\t#   # #   #   #   #   # # # # # #   # #   # # #     #            #   # #     #   # #     #     #   # #     #   # # #   # ");
            Console.WriteLine("\t##### #   #   #   #   # #  #  # #   # ####  # #     ####         #   # ####  ##### #     ####  ####   ###  ##### # ####  ");
            Console.WriteLine("\t#   # #   #   #   #   # #     # #   # #   # # #     #            #   # #     #   # #     #     #   #     # #   # # #     ");
            Console.WriteLine("\t#   # #####   #   ##### #     # ##### ####  # ##### #####        ####  ##### #   # ##### ##### #   #  ###  #   # # #     ");
            Console.WriteLine("\n\n");
        }
    }
}
