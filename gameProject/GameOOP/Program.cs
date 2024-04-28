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
                

                

                System.Timers.Timer timer = new System.Timers.Timer(100);
                Info.Player info = new Info.Player();
                Task.Run(() =>
                {
                    Render.Draw(Render.Field2);
                    
                });
                while (true)
                {
                    Moving();
                }
            }
            public class Info
            {
                private bool IsPassable { get; set; }
                private bool IsResponse {  get; set; }

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

                    public int x = 17;
                    public int y = 7;
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

                }
                public class Enemy
                {

                }
                public abstract class Properties
                {
                    static Player playerinf = new Player(false, false);
                    static Wall wallinf = new Wall(false, false);
                    static Stone stoneinf = new Stone(false, true);
                    static Tree treeinf = new Tree(false, true);
                    static Clear clearinf = new Clear(true, false);
                    Info info = new Info();
                    public int layerLvl {  get; set; }
                    public bool IsMovable {  get; set; }
                    public Properties(bool IsPassable, bool IsResponse)
                    {
                        info.IsPassable = IsPassable;
                        info.IsResponse = IsResponse;
                    }
                    static Properties[,] matrix =
                    {
                        {wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,wallinf},
                        {wallinf, clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,clearinf,stoneinf,clearinf,wallinf},
                        {wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf,wallinf},
                    };
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
                        }
                    }
                    public class Stone : Properties
                    {
                        public Stone(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                        }
                    }
                    public class Clear : Properties
                    {
                        public Clear(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                        }
                    }
                    public class Tree : Properties
                    {
                        public Tree(bool IsPassable, bool IsResponse) : base(IsPassable, IsResponse)
                        {
                        }
                    }
                    public static void SetMatrix(int x, int y)
                    {
                        double xx = x / 13;
                        double yy = y / 9;
                        int xi = (int)(xx + 0.5);
                        int yi = (int)(yy + 0.5);
                        matrix[yi, xi] = playerinf;
                    }
                    public static void ResetMatrix(int x, int y)
                    {
                        double xx = x / 13;
                        double yy = y / 9;
                        int xi = (int)(xx + 0.5);
                        int yi = (int)(yy + 0.5);
                        matrix[yi, xi] = clearinf;
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
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Trees.tree1,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Pustota.pustota,Textures.Kamushek.num1K,Textures.Pustota.pustota,Textures.Walls.wall1},
                    { Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1,Textures.Walls.wall1, },
                };

                

                public static void Draw(string[,][,] bArray)
                {

                    Engine.Render render = new Engine.Render();
                   
                    for (int y = 0; y < bArray.GetLength(0); y++)
                    {
                        for(int x = 0; x < bArray.GetLength(1); x++)
                        {
                            Drawing2nd(bArray[y, x], render.X(x), render.Y(y), ConsoleColor.Green);
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
                    private string[,] lastModelOfPlayer;

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
                    engine.cki = new ConsoleKeyInfo('\0', consoleKey, false, false, false);
                    
                    Thread.Sleep(10);
                    playerInfo.prevPos = [playerInfo.x, playerInfo.y];
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            ResetMatrix(playerInfo.x, playerInfo.y);
                            Drawing2nd(Textures.Pustota.pustota, playerInfo.x, playerInfo.y, ConsoleColor.Red);
                            playerInfo.y--;
                            SetMatrix(playerInfo.x, playerInfo.y);
                            animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, playerInfo.x, playerInfo.y, playerInfo.IsMoving(), 10f, animationsOfPlayer.dirOfMove,  ConsoleColor.Red);
                            break;
                        case ConsoleKey.S:
                            ResetMatrix(playerInfo.x, playerInfo.y);
                            Drawing2nd(Textures.Pustota.pustota, playerInfo.x, playerInfo.y, ConsoleColor.Red);
                            playerInfo.y++;
                            SetMatrix(playerInfo.x, playerInfo.y);
                            animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, playerInfo.x, playerInfo.y, playerInfo.IsMoving(), 10f, animationsOfPlayer.dirOfMove, ConsoleColor.Red);
                            break;
                        case ConsoleKey.D:
                            ResetMatrix(playerInfo.x, playerInfo.y);
                            Drawing2nd(Textures.Pustota.pustota, playerInfo.x, playerInfo.y, ConsoleColor.Red);
                            playerInfo.x += 2;
                            SetMatrix(playerInfo.x, playerInfo.y);
                            animationsOfPlayer.dirOfMove = "right";
                            animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, playerInfo.x, playerInfo.y,true,  10f, animationsOfPlayer.dirOfMove, ConsoleColor.Red);
                            break;
                        case ConsoleKey.A:
                            ResetMatrix(playerInfo.x, playerInfo.y);
                            Drawing2nd(Textures.Pustota.pustota, playerInfo.x, playerInfo.y, ConsoleColor.Red);
                            playerInfo.x--;
                            SetMatrix(playerInfo.x, playerInfo.y);
                            animationsOfPlayer.dirOfMove = "left";
                            animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, playerInfo.x, playerInfo.y, true, 10f, animationsOfPlayer.dirOfMove, ConsoleColor.Red);
                            break;
                    }
                    playerInfo.currentPos = [playerInfo.x, playerInfo.y];
                    if ( i == player.arrayOfModelsOfPlayer.GetLength(1))
                    {
                        i = 0;
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
