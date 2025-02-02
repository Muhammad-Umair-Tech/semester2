using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppWeek3
{
    public class AdminManager
    {
        string adminCredentialsPath = "C:\\##Semester 2\\OOPL\\files\\admin_credentials.txt";

        List<Admin> admins = new List<Admin>();

        public AdminManager()
        {
            // loading data from file
            StreamReader file = new StreamReader(adminCredentialsPath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                admins.Add(ReadAdminFromFile(line));
            }
            file.Close();
        }



        public bool AdminLoginFound(string nameCheck, string passwordCheck)
        {
            foreach (Admin admin in admins)
            {
                if (admin.name == nameCheck && admin.password == passwordCheck)
                {
                    return true;
                }
            }
            return false;
        }



        public void NewAdmin()
        {
            if (admins.Count < 5)
            {
                StringValidation stringValidation = new StringValidation();
                Admin newAdmin = new Admin();
                FileManagement fm = new FileManagement();

                string name;
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                newAdmin.name = stringValidation.ValidateString(name);
                Console.Write("Create a password: ");
                newAdmin.password = Console.ReadLine();
                admins.Append(newAdmin);
                fm.AppendAdminFile(newAdmin);
            }
            else
            {
                Console.WriteLine("Maximum numbers of admins reached.");
            }
        }


        public void ViewAdmins()
        {
            foreach (Admin admin in admins)
            {
                Console.WriteLine($"Name: {admin.name}\nPassword: {admin.password}\n");
            }
        }


        public Admin ReadAdminFromFile(string line)
        {
            StringValidation sv = new StringValidation();
            Admin admin = new Admin();
            admin.name = sv.ParseData(line, 1);
            admin.password = sv.ParseData(line, 2);
            return admin;
        }
    }
}
