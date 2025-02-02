using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameWeek3
{
    public class KnightMovement
    {
        public void MoveKnightRight(Knight knight)
        {
            knight.EraseKnight();
            knight.x++;
            knight.PrintKnight();
        }


        public void MoveKnightLeft(Knight knight)
        {
            knight.EraseKnight();
            knight.x--;
            knight.PrintKnight();
        }


        public void MoveKnightUp(Knight knight)
        {
            knight.EraseKnight();
            knight.y--;
            knight.PrintKnight();
        }


        public void MoveKnightDown(Knight knight)
        {
            knight.EraseKnight();
            knight.y++;
            knight.PrintKnight();
        }

        public void KnightCollision(Knight knight, Enemy enemy, ref int health)
        {
            if ((knight.x <= enemy.x + 11 && knight.x + 11  >= enemy.x) && (knight.y <= enemy.y + 6 && knight.y + 6 >= enemy.y))
            {
                health = 0;
            }
        }
    }
}
