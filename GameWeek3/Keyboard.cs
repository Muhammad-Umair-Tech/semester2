using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWeek3
{
    public class Keyboard
    {
        public bool IsKeyPressed(ConsoleKey key)
        {
            if (Console.KeyAvailable) // check if a key has been pressed
            {
                return Console.ReadKey(true).Key == key; // check if the pressed key is equal to the passed key
            } // the true arguement means we don't want to display the pressed key
            return false;
        }
    }
}
