using System.Text;
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

                public string alias = "♥";
                public int x = 12;
                public int y = 13;
                public int healthPoint;
                /*public int healthPoint
                {
                    get
                    {
                        return healthPoint;
                    }
                    set
                    {
                        if (value >= 100)
                        {
                            healthPoint = 100;
                        }
                        else if (value < 0)
                        {
                            healthPoint = 0;
                        }
                        else
                        {
                            healthPoint = value;
                        }
                    }
                }*/
                public int armorPoint;

                public Hero(int x, int y, int hp)
                {
                    this.x = x;
                    this.y = y;
                    healthPoint = hp;
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
                public static string[,] map =
                {
                    {"▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","▓"},
                    {"▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓","▓"}

                };
                public static void RenderLvl()
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    for (int y = 0; y < map.GetLength(0); y++)
                    {
                        for (int x = 0; x < map.GetLength(1); x++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.SetCursorPosition(x, y);
                            Console.Write(map[y, x]);
                        }
                    }
                }

            }
        }

        private class Objects
        {

        }
        public class HUD
        {
            public string HPView(int hp)
            {
                
                if (hp == 0)
                    return "□□□□□";
                else if (hp > 0 && hp <= 20)
                    return "♥□□□□";
                else if (hp > 21 && hp <= 40)
                    return "♥♥□□□";
                else if (hp > 41 && hp <= 60)
                    return "♥♥♥□□";
                else if (hp > 61 && hp <= 80)
                    return "♥♥♥♥□";
                else if (hp > 81 && hp <= 100)
                    return "♥♥♥♥♥";
                else
                    return "";
            }
            public void ViewHUD(int hp)
            {
                Console.BackgroundColor= ConsoleColor.Black;
                Console.SetCursorPosition(Level.Level1.map.GetLength(1) + 10, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(HPView(hp));
            }
            
        }
        public class Control
        {
            Characters.Hero hero = new Characters.Hero(10, 12, 100);
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

                
                Characters.Hero hero = new Characters.Hero(10, 12, 70);
                Control control = new Control();

                Level.Level1.RenderLvl();

                Task.Run(() =>
                {
                    HUD hUD = new HUD();
                    while (true)
                    {
                        Thread.Sleep(1000);
                        hUD.ViewHUD(hero.healthPoint);
                        if (hero.y == 2)
                        {
                            Thread.Sleep(500);
                            hero.healthPoint = hero.healthPoint - 5;
                            hUD.ViewHUD(hero.healthPoint);
                        }
                    }

                });

                while (true)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(hero.x, hero.y);
                    Console.Write(hero.alias);
                    ConsoleKey consoleKey;
                    Thread.Sleep(10);
                    consoleKey = Console.ReadKey(true).Key;

                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            if (hero.y > 1)
                            {
                                Console.SetCursorPosition(hero.x, hero.y);
                                Console.Write(" ");
                                hero.y--;
                            }
                            else
                                break;
                            break;
                        case ConsoleKey.S:
                            if (hero.y < Level.Level1.map.GetLength(0) - 2)
                            {
                                Console.SetCursorPosition(hero.x, hero.y);
                                Console.Write(" ");
                                hero.y++;
                            }
                            else
                                break;
                            break;
                        case ConsoleKey.D:
                            if (hero.x < Level.Level1.map.GetLength(1) - 2)
                            {
                                Console.SetCursorPosition(hero.x, hero.y);
                                Console.Write(" ");
                                hero.x++;
                            }
                            else
                                break;
                            break;
                        case ConsoleKey.A:
                            if (hero.x > 1)
                            {
                                Console.SetCursorPosition(hero.x, hero.y);
                                Console.Write(" ");
                                hero.x--;
                            }
                            else
                                break;
                            break;
                        default: break;
                    }



                }
            }
        }
        
        public class Engine
        {
            public class Render
            {
                public int X(int x)
                {
                    x *= 13;
                    return x;
                }
                public int Y(int y)
                {
                    y *= 9;
                    return y;
                }
                public static string[,][,] Field =
                    {
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota ,Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Player.normPos, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                        {Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota , Textures.Pustota.pustota, Textures.Pustota.pustota ,Textures.Pustota.pustota ,Textures.Pustota.pustota , },
                    };
                public static string[,][,] Field2 =
{
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Player.chudik,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Kamushek.num1K,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                };
                public static void Draw(string[,][,] bArray)
                {
                    Engine.Render render = new Engine.Render();
                    for (int y = 0; y < bArray.GetLength(0); y++)
                    {
                        for(int x = 0; x < bArray.GetLength(1); x++)
                        {
                            Drawing2nd(bArray[y, x], render.X(x), render.Y(y));
                        }
                    }
                }
            }
        }

        public static void Drawing2nd(string[,] array, int X, int Y)
        { 
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j + X, i + Y);
                    Console.Write(array[i, j]);
                }
                
            }
            

        }

        public static void Testing(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static class Textures
        {
            public static class Player
            {
                public static string[,] normPos =
                {
                    {" ", " ", " ", " ", " ", "_", "^", "_", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "/", "q", " ", "q", "\\", " ", " ", " ", " " },
                    {" ", " ", " ", ".", "\\", " ", "-", " ", "/", ".", " ", " ", " " },
                    {" ", "4", "S", "A", "M", "M", "M", "M", "M", "A", "S", "\\", " " },
                    {" ", "H", " ", "\\", "H", "Й", "Ш", "Й", "H", "7", " ", "H", " " },
                    {"A", "M", " ", " ", "V", "Ы", "Ш", "Ы", "7", " ", " ", "M", "A" },
                    {" ", " ", " ", ".", "W", "#", "M", "#", "W", ".", " ", " ", " " },
                    {" ", " ", " ", "'", "Ш", " ", " ", " ", "Ш", "*", " ", " ", " " },
                    {" ", " ", " ", "C", "Я", " ", " ", " ", "R", "D", " ", " ", " " },
                };

                public static string[,] chudik =
                {
                    {" ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "_", "▓", "_", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", "▓", " ", "▓", "▓", "_", " ", "▓", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                };
                
            }

            public static class Kamushek
            {
                public static string[,] num1K =
                {
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "*", "*", "*", "", " ", " ", " ", " ", " " },
                    {" ", " ", "#", "*", "*", "*", "*", "*", " ", " ", " ", " ", " " },
                    {" ", " ", "#", "#", "*", "*", "#", "#", "#", " ", " ", " ", " " },
                    {" ", "#", "#", "#", "*", "*", "#", "#", "#", "#", "#", " ", " " },
                    {"#", "#", "#", "#", "*", "*", "#", "#", "#", "#", "#", " ", " " },
                    {"#", "#", "#", "#", "*", "*", "#", "#", "#", "#", "#", "#", "#" }
                };
            }
            public static class Pustota
            {
                public static string[,] pustota =
                {
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }
                };
            }

            public static class Walls
            {
                public static string[,] wall1 =
                {
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                };
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Zapusk()
            {
                Game.Display display = new Game.Display();
                Console.Title = "Game";
                Console.OutputEncoding = Encoding.UTF8;
/*                display.Disp();*/
            }
            static void Testing(string[,] array)
            {
                Console.Clear();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(array.GetLength(0));
                Console.WriteLine(array.GetLength(1));
            }
            Zapusk();
            Engine.Render.Draw(Engine.Render.Field2);
        }
    }
}