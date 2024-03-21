using System.Threading;
using static GameOOP.Game;
using static GameOOP.Game.Characters;

namespace GameOOP
{
    public class Game
    {
        public class Characters
        {
            
            public class Hero
            {
                public int x = 12;
                public int y = 13;
                public int healthPoint, armorPoint;

                public Hero(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }

            }
            public class Enemy
            {
                public class Chupakabra
                {
                    
                    public int healthPoint, armorPoint;

                }
            }
        }

        public class Level
        {
            public class Level1
            {
                public static int x_size = 100;
                public static int y_size = 40;

            }
        }

        private class Objects
        {

        }
        private class HUD
        {

        }
        public class Control
        {
            Characters.Hero hero = new Characters.Hero(10, 12);
            public void Moving(int x, int y)
            {
                x = hero.x;
                y = hero.y;

                
                ConsoleKey consoleKey;
                while (true)
                {
                    consoleKey = Console.ReadKey().Key;
                    switch (consoleKey) 
                    {
                        case ConsoleKey.W:
                            hero.y--;
                            break;
                        case ConsoleKey.S:
                            hero.y++;
                            break;
                        case ConsoleKey.D:
                            hero.x++;
                            break;
                        case ConsoleKey.A:
                            hero.x--;
                            break;
                    }
                }
            }
        }
        public class Display
        {
            
            public void Disp()
            {
                Characters.Hero hero = new Characters.Hero(10, 12);
                Control control = new Control();


                Task.Run(() =>
                {
                    
                    while (true)
                    {
                        ConsoleKey consoleKey;
                        Thread.Sleep(10);
                        consoleKey = Console.ReadKey(true).Key;
                        switch (consoleKey)
                        {
                            case ConsoleKey.W:
                                if (hero.y > 0)
                                    hero.y--;
                                else
                                    break;
                                break;
                            case ConsoleKey.S:
                                if (hero.y < Level.Level1.y_size)
                                    hero.y++;
                                else
                                    break;
                                break;
                            case ConsoleKey.D:
                                if (hero.y < Level.Level1.x_size)
                                    hero.x++;
                                else
                                    break;
                                break;
                            case ConsoleKey.A:
                                if (hero.x > 0)
                                    hero.x--;
                                else
                                    break;
                                break;
                        }
                        Console.Clear();
                    }
                });

                while (true)
                {
                   
                    
                    
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(hero.x, hero.y);
                    Console.Write("$");
                }
            }
        }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Game.Display display = new Game.Display();

            display.Disp();
        }
    }
}
