using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameWeek3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Keyboard keyboard = new Keyboard();
            Knight knight = new Knight(1, 1);
            Enemy enemy1 = new Enemy(115, 1);
            KnightMovement moveControl = new KnightMovement();
            EnemyMovement moveEnemy = new EnemyMovement();

            string choice;

            bool e1MovingDown = true;
            bool exitGame = false;
            int health = 100;

            do
            {
                choice = Menu();
                if (choice == "1") // game logic
                {
                    PrintMaze();
                    knight.PrintKnight();
                    enemy1.PrintEnemy();
                    while (true)
                    {
                        if (health == 0)
                        {
                            EndScreen();
                            exitGame = true;
                            break;
                        }
                        //if (keyboard.IsKeyPressed(ConsoleKey.Escape))
                        //{
                        //    Console.WriteLine("ESC Pressed");
                        //    exitGame = true;
                        //    break;
                        //}

                        Thread.Sleep(100);
                        moveEnemy.MoveOnlyVertically(enemy1, 1, 25, ref e1MovingDown); // passing variable by reference
                        if (keyboard.IsKeyPressed(ConsoleKey.RightArrow) && knight.x < 115)
                        {
                            moveControl.MoveKnightRight(knight);
                        }
                        if (keyboard.IsKeyPressed(ConsoleKey.LeftArrow) && knight.x > 1)
                        {
                            moveControl.MoveKnightLeft(knight);
                        }
                        if (keyboard.IsKeyPressed(ConsoleKey.UpArrow) && knight.y > 1) // stay inside boundary, thus y > 1
                        {
                            moveControl.MoveKnightUp(knight);
                        }
                        if (keyboard.IsKeyPressed(ConsoleKey.DownArrow) && knight.y < 25)
                        {
                            moveControl.MoveKnightDown(knight);
                        }
                        moveControl.KnightCollision(knight, enemy1, ref health); // sets health to 0
                    }
                }
                else if (choice == "2")
                {
                    exitGame = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    string enter = Console.ReadLine();
                    continue;
                }
            }
            while (!exitGame);
        }


        static string Menu()
        {
            string choice;
            Console.Clear();
            Console.WriteLine("1. Start the game");
            Console.WriteLine("2. Exit");
            Console.Write("Choice: ");
            choice = Console.ReadLine();
            return choice;
        }


        static void EndScreen()
        {
            Console.Clear();
            Console.WriteLine("Game over.");
            string enter = Console.ReadLine();
        }


        static void PrintMaze()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("###############################################################################################################################");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("#                                                                                                                             #");
            Console.WriteLine("###############################################################################################################################");
        }
    }
}
