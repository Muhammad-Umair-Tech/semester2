using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppWeek3
{
    public class FileManagement
    {
        public string adminPath = "C:\\##Semester 2\\OOPL\\files\\admin_credentials.txt";
        public string inventoryPath = "C:\\##Semester 2\\OOPL\\files\\records.txt";

        public void AppendAdminFile(Admin admin)
        {
            StreamWriter file = new StreamWriter(adminPath, true);
            file.Write($"\n{admin.name},{admin.password}");
            file.Flush();
            file.Close();
        }

        public void AppendInventoryFile(Car car)
        {
            StreamWriter file = new StreamWriter(inventoryPath, true);
            file.Write($"\n{car.company},{car.name},{car.engine},{car.isAutomatic},{car.fuel},{car.price}");
            file.Flush();
            file.Close();
        }
    
        
        public void UpdateInventoryFile(List<Car> cars)
        {
            StreamWriter file = new StreamWriter(inventoryPath);
            file.Write($"{cars[0].company},{cars[0].name},{cars[0].engine},{cars[0].isAutomatic},{cars[0].fuel},{cars[0].price}");
            for (int i = 1; i < cars.Count; i++)
            {
                file.Write($"\n{cars[i].company},{cars[i].name},{cars[i].engine},{cars[i].isAutomatic},{cars[i].fuel},{cars[i].price}");
            }
            file.Flush();
            file.Close();
        }


        public List<Car> LoadInventory(List<Car> cars)
        {
            StringValidation stringValidation = new StringValidation();
            StreamReader file = new StreamReader(inventoryPath);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                Car newCar = new Car();
                newCar.company = stringValidation.ParseData(line, 1);
                newCar.name = stringValidation.ParseData(line, 2);
                newCar.engine = int.Parse(stringValidation.ParseData(line, 3));
                newCar.isAutomatic = stringValidation.ParseData(line, 4) == "True";
                newCar.fuel = int.Parse(stringValidation.ParseData(line, 5));
                newCar.price = int.Parse(stringValidation.ParseData(line, 6));
                cars.Add(newCar);
            }
            file.Close();
            return cars;
        }
    }
}
