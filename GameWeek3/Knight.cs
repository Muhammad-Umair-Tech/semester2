using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWeek3
{
    public class Knight
    {
        public int x;
        public int y;

        public Knight(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;
        }


        public void PrintKnight()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("   ^^^  _  ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("Z (' ') F> ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(" \\__|__/  ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("    |      ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("    |      ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("   / \\    ");
        }


        public void EraseKnight()
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
