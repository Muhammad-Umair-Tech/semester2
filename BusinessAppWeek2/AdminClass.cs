using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace business_app
{
    public class Admin
    {
        StringValidation stringValidation = new StringValidation();

        string adminCredentialsPath = "C:\\##Semester 2\\OOPL\\files\\admin_credentials.txt";
        string inventoryFilePath = "C:\\##Semester 2\\OOPL\\files\\records.txt";

        string nameCheck, passwordCheck;

        int totalCars = 0;
        string[] companies = new string[30];
        string[] cars = new string[30];
        int[] engines = new int[30];
        bool[] isAutomatic = new bool[30];
        int[] fuels = new int[30];
        int[] prices = new int[30];


        // constructor
        public Admin(string nameInput, string passwordInput)
        {
            nameCheck = nameInput;
            passwordCheck = passwordInput;
        }



        public bool CarExistsInInventory(string carToCheck)
        {
            bool carExists = false;
            for (int i = 0; i <= totalCars; i++)
            {
                if (carToCheck ==  cars[i])
                {
                    carExists = true;
                    break;
                }
            }
            return carExists;
        }




        public int SearchAnEngineIndex(int engine)
        {
            for (int i = 0; i <= totalCars; i++)
            {
                if (engines[i] == engine)
                    return i;
            }
            return -1;
        }



        public void DeleteEngine(int engineToDelete)
        {
            int index = SearchAnEngineIndex(engineToDelete);
            if (index != -1)
            {
                for (int i = index; i <= totalCars; i++)
                {
                    cars[i] = cars[i + 1];
                    engines[i] = engines[i + 1];
                    companies[i] = companies[i + 1];
                    isAutomatic[i] = isAutomatic[i + 1];
                    fuels[i] = fuels[i + 1];
                    prices[i] = prices[i + 1];
                }
                cars[totalCars] = "";
                engines[totalCars] = 0;
                companies[totalCars] = "";
                isAutomatic[totalCars] = false;
                fuels[totalCars] = 0;
                prices[totalCars] = 0;
                totalCars--;
            }
            else
            {
                Console.WriteLine("Sorry, no such car exists.");
            }
        }



        public void UpdateCarOfEngine(int engine)
        {
            int toUpdateIndex = SearchAnEngineIndex(engine);
            if (toUpdateIndex != -1)
            {
                Console.Write("Company: ");
                companies[toUpdateIndex] = Console.ReadLine();
                Console.Write("Car model name: ");
                cars[toUpdateIndex] = Console.ReadLine();
                Console.Write("Engine capacity(CC): ");
                engines[toUpdateIndex] = int.Parse(Console.ReadLine());
                Console.Write("Price: ");
                prices[toUpdateIndex] = int.Parse(Console.ReadLine());
                Console.Write("Is automatic(1/0): ");
                isAutomatic[toUpdateIndex] = Console.ReadLine() == "true";
                Console.Write("Fuel - 1 for petrol, 2 for hybrid, 3 for electric: ");
                fuels[toUpdateIndex] = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Sorry, no such car is available.");
            }
        }



        public void AddToInventory()
        {
            if (totalCars < 30)
            {
                Console.Write("\nCompany: ");
                companies[totalCars + 1] = Console.ReadLine();
                Console.Write("Car model name: ");
                cars[totalCars + 1] = Console.ReadLine();
                Console.Write("Engine capacity(CC): ");
                engines[totalCars + 1] = int.Parse(Console.ReadLine());
                Console.Write("Price(PKR): ");
                prices[totalCars + 1] = int.Parse(Console.ReadLine());
                Console.Write("Is automatic(1/0): ");
                isAutomatic[totalCars + 1] = Console.ReadLine() == "1";
                Console.Write("Fuel - 1 for petrol, 2 for hybrid, 3 for electric: ");
                fuels[totalCars + 1] = int.Parse(Console.ReadLine());
                totalCars++;
            }
            else
            {
                Console.WriteLine("\"No more room in the dealership for more cars.\"");
            }
        }





        public void ViewInventory()
        {
            LoadInventoryArrays();
            int count = 1;
            Console.WriteLine("\n\n\tCompany\t\tCar\t\tEngine(cc) \t\tType\t\t\tFuel\t\tPrice(PKR)\n");
            for (int i = 0; i <= totalCars; i++)
            {
                ViewDetailsOfaCar(i, count);
                count++;
            }
        }





        public void ViewDetailsOfaCar(int index, int count)
        {
            Console.Write($"{count}\t{companies[index]}\t\t{cars[index]}\t\t{engines[index]}\t\t\t");
            if (isAutomatic[index] == true) // checking wether the car is automatic (type)
                Console.Write("Automatic");
            else
                Console.Write("Manual   ");
            Console.Write("\t\t");
            if (fuels[index] == 1)         // checking fuel type
                Console.Write("Petrol     ");
            else if (fuels[index] == 2)
                Console.Write("Hybrid     ");
            else if (fuels[index] == 3)
                Console.Write("Electric   ");
            Console.Write($"\t{prices[index]}\n");
        }






        public void LoadInventoryArrays()
        {
            int index = 0;
            string line = "";
            StreamReader file = new StreamReader(inventoryFilePath);
            while ((line = file.ReadLine()) != null)
            {
                companies[index] = stringValidation.ParseData(line, 1);
                cars[index] = stringValidation.ParseData(line, 2);
                engines[index] = int.Parse(stringValidation.ParseData(line, 3));
                isAutomatic[index] = stringValidation.ParseData(line, 4) == "1";
                fuels[index] = int.Parse(stringValidation.ParseData(line, 5));
                prices[index] = int.Parse(stringValidation.ParseData(line, 6));
                index++;
            }
            totalCars = index - 1; // total_cars is always exactly equal to the total number of cars
            file.Close();
        }





        public void UpdateInventoryArrays()
        {
            StreamWriter file = new StreamWriter(inventoryFilePath);
            file.Write($"{companies[0]},{cars[0]},{engines[0]},{isAutomatic[0]},{fuels[0]},{prices[0]}");
            for (int i = 0; i <= totalCars; i++)
            {
                file.Write($"\n{companies[i]},{cars[i]},{engines[i]},{isAutomatic[i]},{fuels[i]},{prices[i]}");
            }
            file.Close();
        }




        public void UpdateInventoryFile()
        {
            StreamWriter file = new StreamWriter(inventoryFilePath);
            file.Write($"{companies[0]},{cars[0]},{engines[0]},{isAutomatic[0]},{fuels[0]},{prices[0]}");
            for (int i = 0; i <= totalCars; i++)
            {
                file.Write($"\n{companies[i]},{cars[i]},{engines[i]},{isAutomatic[i]},{fuels[i]},{prices[i]}");
            }
            file.Flush();
            file.Close();
        }




        public void NewAdmin()
        {
            // count already existing admins
            int admins = 0;
            using (StreamReader file = new StreamReader(adminCredentialsPath))
            {
                while (file.ReadLine() != null)
                {
                    admins++;
                }
            }

            // new admin
            if (admins < 5)
            {
                // taking in the new admin's name and password
                string name, password;
                Console.Write("Enter admin name: ");
                name = Console.ReadLine();
                name = stringValidation.ValidateString(name);
                Console.Write("Create a password: ");
                password = Console.ReadLine();

                // password should not contain commas
                bool comma_found = false;
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == ',')
                    {
                        Console.WriteLine("Password should not contain \',\'");
                        comma_found = true;
                        break;
                    }
                }

                // append the file if the name and password are valid
                if (comma_found == false)
                {
                    using (StreamWriter file_variable = new StreamWriter(adminCredentialsPath, true))
                    {
                        file_variable.Write("\n");
                        file_variable.Write(name);
                        file_variable.Write(",");
                        file_variable.Write(password);
                        file_variable.Flush();
                        admins++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Maximum number of admins reached");
            }
        }








        public void ViewAdmins()
        {
            string line;
            using (StreamReader file = new StreamReader(adminCredentialsPath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine("Name: " + stringValidation.ParseData(line, 1));
                    Console.WriteLine("Password: " + stringValidation.ParseData(line, 2));
                    Console.WriteLine("\n");
                }
            }
        }






        public bool AdminLoginFound()
        {
            StringValidation stringValidation = new StringValidation();

            // load_admin_credentials function 
            string[] admin_names = new string[5];
            string[] admin_passwords = new string[5];
            int index = 0;
            string line;
            using (StreamReader file = new StreamReader(adminCredentialsPath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    admin_names[index] = stringValidation.ParseData(line, 1);
                    admin_passwords[index] = stringValidation.ParseData(line, 2);
                    index++;
                }
            }

            // admin_login_found function
            for (int i = 0; i < 5; i++)
            {
                if (nameCheck == admin_names[i] && passwordCheck == admin_passwords[i])
                {
                    return true;
                }
            }
            return false;
        }







        public string AdminMenu()
        {
            string choice;
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
    }
}
