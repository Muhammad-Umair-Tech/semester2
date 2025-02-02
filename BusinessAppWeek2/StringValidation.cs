using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_app
{
    public class StringValidation
    {
        public string ValidateString(string line)
        {
            bool validInput = false;
            int ascii = 0;
            while (validInput == false)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    ascii = line[i];
                    if ((ascii >= 97 && ascii <= 122) || (ascii >= 65 && ascii <= 90) || ascii == 32)
                    {
                        validInput = true;
                    }
                    else
                    {
                        validInput = false;
                        break;
                    }
                }

                if (validInput == false)
                {
                    Console.WriteLine("Username should only contain letters. Try again: ");
                    line = Console.ReadLine();
                }
            }
            return line;
        }






        public string ParseData(string line, int field)
        {
            string word = "";
            int comma_count = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma_count++;
                }
                else if (comma_count == field)
                {
                    word += line[i];
                }
            }
            return word;
        }
    }
}
