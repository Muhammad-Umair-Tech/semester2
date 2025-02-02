using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business_app;

namespace project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            while (true)
            {
                AppTitle();
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    AppTitle();
                    Console.WriteLine("CUSTOMER");
                    Console.WriteLine("Press any key to go to the home screen");
                    Console.ReadLine();
                    continue;
                }
                else if (choice == "2")
                {
                    AppTitle();
                    Console.WriteLine("ADMIN");
                    choice = ChoiceAdmin();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                }
                if (choice == "4")
                {
                    continue;
                }
                Console.WriteLine("Press any key to go to the home screen");
                Console.ReadLine();
                continue;
            }
        }







        static string ChoiceAdmin()
        {
            string name, password;
            Console.Write("Enter admin name: ");
            name = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            Admin adminObject = new Admin(name, password);

            while (true)
            {
                if (adminObject.AdminLoginFound())
                {
                    string choice;
                    AppTitle();
                    choice = adminObject.AdminMenu();
                    if (choice == "1")
                    {
                        adminObject.NewAdmin();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "2")
                    {
                        adminObject.ViewAdmins();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "3")
                    {
                        adminObject.ViewInventory();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else if (choice == "4")
                    {
                        adminObject.AddToInventory();
                        adminObject.UpdateInventoryArrays();
                        adminObject.UpdateInventoryFile();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                    }
                    else if (choice == "5") // edit details of a car
                    {
                        string carToEdit;
                        int engineToEdit;
                        Console.Write("Enter the name of the car to edit: ");
                        carToEdit = Console.ReadLine();
                        if (adminObject.CarExistsInInventory(carToEdit))
                        {
                            Console.Write("Enter the engine power of the car to edit: ");
                            engineToEdit = int.Parse(Console.ReadLine());
                            adminObject.UpdateCarOfEngine(engineToEdit);
                            adminObject.UpdateInventoryFile();
                            Console.WriteLine("Editing successful.");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, no such car is available.");
                        }
                    }
                    else if (choice == "6") // delete a car
                    {
                        string carToDelete;
                        int engineToDelete;
                        Console.Write("Enter the name of the car to delete: ");
                        carToDelete = Console.ReadLine();
                        if (adminObject.CarExistsInInventory(carToDelete))
                        {
                            Console.Write("Enter the engine power of the car to delete: ");
                            engineToDelete = int.Parse(Console.ReadLine());
                            adminObject.DeleteEngine(engineToDelete);
                            adminObject.UpdateInventoryFile();
                            Console.WriteLine("Deletion successful.");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, no such car is available.");
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
