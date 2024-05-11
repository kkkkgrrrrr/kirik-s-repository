using System.Diagnostics;
using System.Text;
using System.Threading;
using static GameOOP.Game;
using static GameOOP.Game.Characters;
using System.Timers;
using System.Data;
using System;
using static GameOOP.Game.Engine.Info;
using static GameOOP.Game.Engine.Info.Properties;
using System.Dynamic;
using static System.Net.Mime.MediaTypeNames;
using static GameOOP.Game.Engine.HUD;

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
            ConsoleKeyInfo cki;
           
            public void RunGame()
            {
                //Console.SetBufferSize(700, 300);
                //Console.SetWindowSize(200, 100);
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Info.Player info = new Info.Player();
                Task.Run(() =>
                {
                    Render.Draw(Render.Field2);
                    
                });
                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    Info info = new Info();
                    Show_HUD(field_HUD);

                });


                while (true)
                {
                    Moving();
                }
            }
            public class Info
            {
                public static string[,][,] field_HUD =
                {
                    {HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11, HUD_Visual.partOfHUD11  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.healthPoints11,HUD_Visual.healthPoints12,HUD_Visual.healthPoints13,HUD_Visual.healthPoints14,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.healthPoints21,HUD_Visual.healthPoints22,HUD_Visual.healthPoints23,HUD_Visual.healthPoints24,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11, HUD_Visual.partOfHUD11  },
                };
                private bool IsResponse {  get; set; }
                public int coinx = 0;
                public int coiny = 0;
                public class Player
                {
                    
                    
                    public bool IsMoving()
                    {
                        if(currentPos != prevPos)
                        {
                            return true;
                        }
                        return(DateTime.Now - timeLastMove).TotalSeconds < timeMove;
                    }
                    private int healthPoints {  get; set; }
                    private int mana {  get; set; }

                    public DateTime timeLastMove;
                    public float timeMove = 0.5f;

                    public int x = 39;
                    public int y = 27;
                    public int[] currentPos = new int[2];
                    public int[] prevPos = new int[2];

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

                    public int X_Matrix(int x)
                    { 
                        return (int)(x/ 13);
                    }
                    public int Y_Matrix(int y)
                    {
                        return (int)(y / 9);
                    }
                    public int matrix_X = 3;
                    public int matrix_Y = 3;
                }
                public static int[] GetIndexesOfArray2D(Properties[,] array, Properties unit)
                {
                    for(int i = 0; i < array.GetLength(0); i++)
                    {
                        for(int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] == unit)
                            {
                                return [j, i];
                            }
                        }
                    }
                    return [-1, -1];
                }

                public class Enemy
                {

                }
                public abstract class Properties
                {
                    static Player playerinf = new Player(true, false);
                    static Wall wallinf = new Wall(false, false);
                    static Stone stoneinf = new Stone(false, true);
                    static Tree treeinf = new Tree(false, true);
                    static Clear clearinf = new Clear(true, false);
                    static Coin1 coin1inf = new Coin1(false, true);
                    
                    Info info = new Info();
                    public int layerLvl {  get; set; }
                    public bool IsMovable {  get; set; }
                    public bool IsResponse {  get; set; }
                    public bool IsPassable {  get; set; }
                    public Properties(bool IsPassable, bool IsResponse)
                    {
                        this.IsPassable = IsPassable;
                        this.IsResponse = IsResponse;
                    }
                    public static Properties[,] Buildmatrix(string[,][,] map)
                    { 
                        Properties[,] matrix = new Properties[map.GetLength(0) * 2, map.GetLength(1) * 2];
                        
                        for (int i = 0; i < map.GetLength(0); i++)
                        {
                            for (int j = 0; j < map.GetLength(1); j++)
                            {
                                if (map[i, j] == Textures.Pustota.pustota)
                                {
                                    matrix[i, j] = clearinf;
                                }    
                                if (map[i, j] == Textures.Trees.tree1)
                                {
                                    matrix[i, j] = treeinf;
                                    matrix[i - 1, j -1] = treeinf;
                                    matrix[i - 1, j] = treeinf;
                                    matrix[i, j - 1] = treeinf;
                                }  
                                if (map[i, j] == Textures.Kamushek.num1K)
                                {
                                    matrix[i, j] = stoneinf;
                                    matrix[i - 1, j - 1] = stoneinf;
                                    matrix[i - 1, j] = stoneinf;
                                    matrix[i, j - 1] = stoneinf;
                                }
                                if (map[i, j] == Textures.Coins.coin1)
                                {
                                    matrix[i, j] = coin1inf;
                                    matrix[i - 1, j - 1] = coin1inf;
                                    matrix[i - 1, j] = coin1inf;
                                    matrix[i, j - 1] = coin1inf;
                                }
                                if (map[i, j] == Textures.Walls.wall1)
                                {
                                    matrix[i, j] = wallinf;

                                }
                                if (map[i, j] == Textures.Walls.wall1 && j >= 1 && i >= 1)
                                {
                                    matrix[i - 1, j -1] = wallinf;
                                    matrix[i - 1, j] = wallinf;
                                    matrix[i, j - 1] = wallinf;
                                }
                            }
                        }
                        return matrix;
                    }
                    public static Properties[,] matrix = Buildmatrix(Render.Field2);
                    public static Properties[,] matrix2 =
                    {
                        {wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,treeinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,treeinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,treeinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,treeinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,treeinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf},
                        {wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf},
                    };
                    
                    public static void PropertiesActivation(int x, int y, int nextX, int nextY)
                    {
                        Info info = new Info();
                        if(matrix[(int)(nextY / Textures.Player.movingModelOfPlayerL1.GetLength(0)), (int)(nextX / Textures.Player.movingModelOfPlayerL1.GetLength(1))] == treeinf)
                        {
                            field_HUD[8, 3] = HUD_Visual.tree1;
                            field_HUD[8, 4] = HUD_Visual.tree2;
                            Show_HUD(field_HUD);
                        }
                        if(matrix[(int)(nextY / Textures.Player.movingModelOfPlayerL1.GetLength(0)), (int)(nextX / Textures.Player.movingModelOfPlayerL1.GetLength(1))] == wallinf)
                        {
                            Console.SetCursorPosition(400, 100);
                            Console.Write("ДЕРЕВОsdasdas");
                        }
                        if (matrix[(int)(nextY / Textures.Player.movingModelOfPlayerL1.GetLength(0)), (int)(nextX / Textures.Player.movingModelOfPlayerL1.GetLength(1))] == coin1inf)
                        {
                            field_HUD[7, 3] = HUD_Visual.monetka1;
                            field_HUD[7, 4] = HUD_Visual.monetka2;
                            field_HUD[7, 5] = HUD_Visual.monetka3;
                            Show_HUD(field_HUD);
                            int xx = nextX;
                            int yy = nextY;
                            Drawing2ndRev1(Textures.Pustota.pustota, GetIndexesOfArray2D(matrix, coin1inf)[0] + 1, GetIndexesOfArray2D(matrix, coin1inf)[1] + 1, ConsoleColor.Black);
                            matrix[GetIndexesOfArray2D(matrix, coin1inf)[0] - 1, GetIndexesOfArray2D(matrix, coin1inf)[1] - 1] = clearinf;
                            matrix[GetIndexesOfArray2D(matrix, coin1inf)[0], GetIndexesOfArray2D(matrix, coin1inf)[1]] = clearinf;
                            matrix[GetIndexesOfArray2D(matrix, coin1inf)[0], GetIndexesOfArray2D(matrix, coin1inf)[1] - 1] = clearinf;
                            matrix[GetIndexesOfArray2D(matrix, coin1inf)[0] - 1, GetIndexesOfArray2D(matrix, coin1inf)[1]] = clearinf;
                            
                        }
                    }
                    public class Player : Properties
                    {
                        public Player(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                        }
                    }
                    public class Wall : Properties
                    {
                        public Wall(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                            bool GetBoolOfPassable()
                            {
                                return IsPassable;
                            }
                        }
                    }
                    public class Stone : Properties
                    {
                        public Stone(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                            bool GetBoolOfPassable()
                            {
                                return IsPassable;
                            }
                        }
                    }
                    public class Clear : Properties
                    {
                        public Clear(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                            bool GetBoolOfPassable()
                            {
                                return IsPassable;
                            }
                        }
                    }
                    public class Tree : Properties
                    {
                        public Tree(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                            bool GetBoolOfPassable()
                            {
                                return IsPassable;
                            }
                        }
                    }
                    public class Coin1 : Properties
                    {
                        public Coin1(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                            bool GetBoolOfPassable()
                            {
                                return IsPassable;
                            }
                        }
                    }
                    public static void SetMatrix(int x, int y)
                    {
                        matrix[y, x] = playerinf;
                    }
                    public static void ResetMatrix(int x, int y)
                    {
                        matrix[y, x] = clearinf;
                    }
                }
                
            }

            public class HUD
            {
                public  class HUD_Visual
                {
                    public static string[,] healthPoint =
                {
                    {"_","_","_","_","_","_","_","_","_","_","_","_" },
                    {"|"," "," "," "," "," "," "," "," "," "," ","|" },
                    {"_","_","_","_","_","_","_","_","_","_","_","_" },

                };
                    public static string[,] partOfHUD11 =
                    {
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                };
                    
                    public static string[,] partOfHUD21 =
                    {
                    {"█","█","█","█","█","█"," "," "," "," "," "," " },
                    {"█","█","█","█","█","█"," "," "," "," "," "," " },
                    {"█","█","█","█","█","█"," "," "," "," "," "," " },
                    {"█","█","█","█","█","█"," "," "," "," "," "," " },
                    {"█","█","█","█","█","█"," "," "," "," "," "," " },
                };
                    public static string[,] partOfHUD23 =
                    {
                    {" "," "," "," "," "," ","█","█","█","█","█","█" },
                    {" "," "," "," "," "," ","█","█","█","█","█","█" },
                    {" "," "," "," "," "," ","█","█","█","█","█","█" },
                    {" "," "," "," "," "," ","█","█","█","█","█","█" },
                    {" "," "," "," "," "," ","█","█","█","█","█","█" },
                };
                    public static string[,] partOfHUDClear =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                };
                    public static string[,] healthPoints11 =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█","█","█","█" },
                    };
                    public static string[,] healthPoints12 =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {"█","█","█","█","█","█","█"," "," "," "," "," " },
                    };
                    public static string[,] healthPoints21 =
                    {
                    {" "," "," "," "," ","█","█","█","█","█","█","█" },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    {" "," "," "," "," ","█","█","█","█"," "," "," " },
                    };
                    public static string[,] healthPoints22 =
                    {
                    {"█","█","█","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    {" "," "," ","█","█","█","█"," "," "," "," "," " },
                    };
                    public static string[,] healthPoints13 =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█"," "," "," "," ","█","█","█","█" },
                    {"█","█","█","█"," "," "," "," ","█","█","█","█" },
                    };
                    public static string[,] healthPoints23 =
                    {
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    };
                    public static string[,] healthPoints14 =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," ","█","█","█","█"," "," "," "," " },
                    {" "," "," "," ","█","█","█","█"," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    };
                    public static string[,] healthPoints24 =
                    {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {" "," "," "," ","█","█","█","█"," "," "," "," " },
                    {" "," "," "," ","█","█","█","█"," "," "," "," " },
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    };
                    public static string[,] monetka1 =
                    {
                    {"█"," "," "," ","█"," "," ","█","█"," "," ","█" },
                    {"█","█"," ","█","█"," ","█"," "," ","█"," ","█" },
                    {"█"," ","█"," ","█"," ","█"," "," ","█"," ","█" },
                    {"█"," "," "," ","█"," ","█"," "," ","█"," ","█" },
                    {"█"," "," "," ","█"," "," ","█","█"," "," ","█" },
                    };
                    public static string[,] monetka2 =
                    {
                    {"█"," "," "," ","█"," ","█","█","█","█"," ","█" },
                    {" ","█"," "," ","█"," ","█"," "," "," "," ","█" },
                    {" "," ","█"," ","█"," ","█","█","█","█"," "," " },
                    {" "," "," ","█","█"," ","█"," "," "," "," "," " },
                    {" "," "," "," ","█"," ","█","█","█","█"," "," " },
                    };
                    public static string[,] monetka3 =
                    {
                    {" "," "," ","█"," "," "," "," "," "," "," "," " },
                    {" "," "," ","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█"," "," "," "," "," "," "," "," "," " },
                    {" ","█"," "," "," "," "," "," "," "," "," "," " },
                    {" ","█"," "," "," "," "," "," "," "," "," "," " },
                    };

                    public static string[,] tree1 =
                    {
                    {"█","█","█","█","█","█","█"," ","█","█","█"," " },
                    {" "," "," ","█"," "," "," "," ","█"," "," ","█" },
                    {" "," "," ","█"," "," "," "," ","█","█","█"," " },
                    {" "," "," ","█"," "," "," "," ","█"," ","█"," " },
                    {" "," "," ","█"," "," "," "," ","█"," "," ","█" },
                    };
                    public static string[,] tree2 =
                    {
                    {" ","█","█","█","█","█"," ","█","█","█","█","█" },
                    {" ","█"," "," "," "," "," ","█"," "," "," "," " },
                    {" ","█","█","█","█","█"," ","█","█","█","█","█" },
                    {" ","█"," "," "," "," "," ","█"," "," "," "," " },
                    {" ","█","█","█","█","█"," ","█","█","█","█","█" },
                    };
                }

                public static void Drawing2nd(string[,] array, int X, int Y, ConsoleColor color)
                {
                    Console.ForegroundColor = color;
                    Console.CursorVisible = false;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            Console.SetCursorPosition(j + X + 270, i + Y);
                            Console.Write(array[i, j]);
                        }

                    }
                    

                }


                public static void Show_HUD(string[,][,] field)
                {
                    
                    for (int y = 0; y < field.GetLength(0); y++)
                    {
                        for (int x = 0; x < field.GetLength(1); x++)
                        {
                            
                            if (x >= 1 && x <=5 && y >= 1 && y <=2)
                            {
                                Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.Red);
                            }
                            else if (field[y, x] == HUD_Visual.tree1 || field[y, x] == HUD_Visual.tree2)
                            {
                                Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.Green);
                            }
                            else if (field[y, x] == HUD_Visual.monetka1 || field[y, x] == HUD_Visual.monetka2 || field[y, x] == HUD_Visual.monetka3)
                            {
                                Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.Yellow);
                            }
                            else
                            {
                                Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.DarkYellow);
                            }
                            
                        }
                    }
                }
            }
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
                public static string[,][,] Field2 =
                {
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Trees.tree1,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Coins.coin1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Kamushek.num1K,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                };

                

                public static void Draw(string[,][,] bArray)
                {
                    
                    Engine.Render render = new Engine.Render();
                    Info info = new Info();
                    for (int y = 0; y < bArray.GetLength(0); y++)
                    {
                        for(int x = 0; x < bArray.GetLength(1); x++)
                        {
                            if (bArray[y, x] == Textures.Walls.wall1)
                            {
                                Drawing2nd(bArray[y, x], render.X(x), render.Y(y), ConsoleColor.DarkBlue);
                            }
                            else if (bArray[y, x] == Textures.Kamushek.num1K)
                            {
                                Drawing2nd(bArray[y, x], render.X(x), render.Y(y), ConsoleColor.DarkGray);
                            }
                            else if ((bArray[y, x] == Textures.Coins.coin1))
                            {
                                
                                Drawing2nd(bArray[y, x], render.X(x), render.Y(y), ConsoleColor.Yellow);
                            }
                            else
                            {
                                Drawing2nd(bArray[y, x], render.X(x), render.Y(y), ConsoleColor.Green);
                            }
                            
                        }
                    }
                    
                }
            }

            public class Animations
            {
                public void AnimatedMoveDraw(string[,][,] arrayOfModelsOfObject, int X, int Y, bool IsMoving, float speed, string direction, ConsoleColor color)
                {
                    Player player = new Player();
                    Info.Player playerInfo = new Info.Player();
                    Console.ForegroundColor = color;
                    Console.CursorVisible = false;
                    int t = 0;
                    string[,] currentModel(string[,][,] ArrayOfModels, bool IsMoving, string direction1)
                    {
                        int d;
                        if (IsMoving)
                        {
                            if (direction == "right")
                            {
                                playerInfo.timeLastMove = DateTime.Now;
                                d = 1;
                                return ArrayOfModels[t, d];
                            }
                            else
                            {
                                playerInfo.timeLastMove = DateTime.Now;
                                d = 0;
                                return ArrayOfModels[t, d];
                            }
                        }
                        else
                        {
                            t = 0;
                            return Textures.Player.normalModelOfPlayerL;
                        }

                        
                    }
                    if (t == arrayOfModelsOfObject.GetLength(0))
                    {
                        t = 0;
                    }
                    for (int i = 0; i < currentModel(arrayOfModelsOfObject, IsMoving, player.dirOfMove).GetLength(0); i++)
                    {
                        for (int j = 0; j < currentModel(arrayOfModelsOfObject, IsMoving, player.dirOfMove).GetLength(1); j++)
                        {
                            Console.SetCursorPosition(j + X, i + Y );
                            Console.Write(currentModel(arrayOfModelsOfObject, IsMoving, player.dirOfMove)[i, j]);
                        }

                    }
                }
                public class Player
                {
                    

                    public string dirOfMove { get; internal set; }
                    

                    /*public string[,] CurrentPlayerModel(bool IsMoving)
                    {
                        Textures.Player player = new Textures.Player();

                        if (IsMoving)
                        {
                            if (dirOfMove == "right")
                            {
                                lastModelOfPlayer = Textures.Player.normalModelOfPlayerR;
                                return Textures.Player.normalModelOfPlayerR;
                            }
                            else if (dirOfMove == "left")
                            {
                                lastModelOfPlayer = Textures.Player.normalModelOfPlayerL;
                                return Textures.Player.normalModelOfPlayerL;
                            }
                        }
                        else
                            return lastModelOfPlayer;
                        return lastModelOfPlayer;
                    }*/
                }
            }

            public static void Drawing2nd(string[,] array, int X, int Y, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.CursorVisible = false;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(array[i, j]);
                    }

                }
            }
            public static void Drawing2ndRev1(string[,] array, int X, int Y, ConsoleColor color)
            {

                Console.ForegroundColor = color;
                Console.CursorVisible = false;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(j + X * 13, i + Y * 9);
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
            public class Textures
            {
                public class Player
                {

                    public static string[,] normalModelOfPlayerR =
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
                    public static string[,] movingModelOfPlayerR1 =
                    {
                    {" ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "_", "▓", "_", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", " ", "▓", "_", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", " ", " ", " ", "▓", " ", " ", " ", " " },
                    };

                    public static string[,] normalModelOfPlayerL =
                    {
                    {" ", " ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "_", "▓", "_", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", "▓", " ", "_", "▓", "▓", " ", "▓", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                    };
                    public static string[,] movingModelOfPlayerL1 =
                    {
                    {" ", " ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "_", "▓", "_", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "_", "▓", " ", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", " ", " ", " ", "▓", " ", " ", " ", " " },
                    };

                    public string[,][,] arrayOfModelsOfPlayer =
                    {
                        { normalModelOfPlayerL,normalModelOfPlayerR},
                        { movingModelOfPlayerL1, movingModelOfPlayerR1 }

                    };

                }
                public  class Kamushek
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
                public static class Trees
                {
                    public static string[,] tree1 =
                    {
                    {" ", " ", "H", "W", "W", "W", "W", "W", "W", "W", "H", " ", " " },
                    {" ", "V", "V", "A", "#", "#", "#", "#", "#", "A", "V", "V", " " },
                    {"W", "W", "V", "A", "#", "/", "#", "\\", "#", "A", "V", "W", "W" },
                    {"W", "W", "W", "#", "#", "#", "#", "#", "#", "#", "W", "W", "W" },
                    {" ", "\\", "V", "M", "M", "\\", "█", "/", "M", "M", "V", "/", " " },
                    {" ", " ", "W", "V", " ", " ", "█", " ", " ", "V", "W", " ", " " },
                    {" ", " ", " ", " ", " ", "V", "█", "V", " ", " ", " ", " ", " " },
                    {" ", " ", "A", "X", "X", "X", "X", "X", "X", "X", "A", " ", " " },
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                };
                }
                public static class Coins
                {
                    public static string[,] coin1 =
                    {
                    { " ", " ", " ", "█", "█", "█", "█", "█", "█", "█", " ", " ", " " },
                    { " ", "█", "█", "█", " ", " ", " ", " ", " ", "█", "█", "█", " " },
                    { "█", "█", " ", " ", " ", " ", "█", " ", " ", " ", " ", "█", "█" },
                    { "█", " ", " ", " ", " ", "█", "█", "█", " ", " ", " ", " ", "█" },
                    { "█", " ", " ", " ", "█", "█", "█", "█", "█", " ", " ", " ", "█" },
                    { "█", " ", " ", " ", " ", "█", "█", "█", " ", " ", " ", " ", "█" },
                    { "█", "█", " ", " ", " ", " ", "█", " ", " ", " ", " ", "█", "█" },
                    { " ", "█", "█", "█", " ", " ", " ", " ", " ", "█", "█", "█", " " },
                    { " ", " ", " ", "█", "█", "█", "█", "█", "█", "█", " ", " ", " " }
                    };
                }
            }
            public static void Moving()
            {
                Engine engine = new Engine();
                
                Textures.Player player = new Textures.Player();
                Info.Player playerInfo = new Info.Player();
                Animations animations = new Animations();
                Animations.Player animationsOfPlayer = new Animations.Player();
                int i = 0;
                while (true)
                {
                    ConsoleKey consoleKey;
                    
                    consoleKey = Console.ReadKey(true).Key;
                    int playerNextX = playerInfo.x;
                    int playerNextY = playerInfo.y;
                    Thread.Sleep(10);
                    playerInfo.prevPos = [playerInfo.x, playerInfo.y];
                    SetMatrix(playerInfo.matrix_X, playerInfo.matrix_Y);
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            playerNextY--;
                            break;
                        case ConsoleKey.S:
                            playerNextY++;
                            break;
                        case ConsoleKey.D:
                            animationsOfPlayer.dirOfMove = "right";
                            playerNextX +=2;
                            break;
                        case ConsoleKey.A:
                            animationsOfPlayer.dirOfMove = "left";
                            playerNextX -=2;
                            break;

                    }
                    playerInfo.matrix_X = (int)(playerInfo.x / 13);
                    playerInfo.matrix_Y = (int)(playerInfo.y / 9);
                    if (matrix[playerInfo.Y_Matrix(playerNextY), playerInfo.X_Matrix(playerNextX)].IsPassable)
                    {
                        ResetMatrix(playerInfo.matrix_X, playerInfo.matrix_Y);
                       
                        Drawing2nd(Textures.Pustota.pustota, playerInfo.x, playerInfo.y, ConsoleColor.Red);
                        playerInfo.x = playerNextX;
                        playerInfo.y = playerNextY;
                        SetMatrix(playerInfo.matrix_X, playerInfo.matrix_Y);
                        animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, playerInfo.x, playerInfo.y, playerInfo.IsMoving(), 10f, animationsOfPlayer.dirOfMove, ConsoleColor.Red);
                    }
                    else
                    {
                        PropertiesActivation(playerInfo.x, playerInfo.y, playerNextX, playerNextY);
                    }
                    
                }

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
            Engine engine = new Engine();

            engine.RunGame();
        }
    }
}