using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameWeek3
{
    public class EnemyMovement
    {
        // receiving movingDownwards by reference so that changes made in the variable are also reflected in Main()
        public void MoveOnlyVertically(Enemy enemy, int yMin, int yMax, ref bool movingDownwards) // yMax = 25
        {
            if (movingDownwards == true)
            {
                if (enemy.y < yMax)
                {
                    Console.SetCursorPosition(enemy.x, enemy.y);
                    enemy.PrintEnemy();
                    Thread.Sleep(10);
                    enemy.EraseEnemy();
                    enemy.y++;
                }
                else
                {
                    movingDownwards = false;
                }
            }
            else if (movingDownwards == false)
            {
                if (enemy.y > yMin) // if moving_down = false, move up
                {
                    Console.SetCursorPosition(enemy.x, enemy.y);
                    enemy.PrintEnemy();
                    Thread.Sleep(10);
                    enemy.EraseEnemy();
                    enemy.y--;
                }
                else
                {
                    movingDownwards = true; // if enemy1 reaches the top boundary, can't move up further so moving_down = true 
                }
            }
        }
    }
}
