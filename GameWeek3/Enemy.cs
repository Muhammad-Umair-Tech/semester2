using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWeek3
{
    public class Enemy
    {
        public int x;
        public int y;

        public Enemy(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;
        }


        public void PrintEnemy()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("     ^     ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("  <(\\./)> ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("     @     ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("  <==@     ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("     @     ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("    / \\   ");
        }


        public void EraseEnemy()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("           ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("           ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("           ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("           ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("           ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("           ");
        }
    }
}
