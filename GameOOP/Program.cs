﻿using System.Text;
using GameOOP;
using static GameOOP.Engine;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;
using System.IO;
using static GameOOP.Info;
using System.Numerics;
namespace GameOOP
{
    public class SaveGameStats
    {
        public SaveGameStats()
        {
            healthPoints = (int)SaveCollection["healthPoints"];
            coins = (int)SaveCollection["coins"];
            InDialogue = (bool)SaveCollection["InDialogue"];
            dirOfMove = (string)SaveCollection["dirOfMove"];
            playerActualX = (int)SaveCollection["playerActualX"];
            playerActualY = (int)SaveCollection["playerActualY"];
            playerNextX = (int)SaveCollection["playerNextX"];
            playerNextY = (int)SaveCollection["playerNextY"];
            numberOfField = (int)SaveCollection["numberOfField"];

        }
        public static Dictionary<string, object> SaveCollection = new Dictionary<string, object>
                {
                    {"healthPoints", healthPoints = 100},
                    {"coins", coins = 0},
                    {"numberOfField", numberOfField = 1},
                    {"InDialogue", InDialogue},
                    {"dirOfMove", dirOfMove},
                    {"playerActualX", playerActualX  = 50},
                    {"playerActualY", playerActualY  = 70},
                    {"playerNextX", playerNextX},
                    {"playerNextY", playerNextY},

                };
        public static int healthPoints { get; set; } = 100;
        public static bool InDialogue = false;
        public static string dirOfMove { get; set; }
        public static int playerActualX { get; set; } = 50;
        public static int playerActualY { get; set; } = 70;
        public static int playerNextX { get; set; }
        public static int playerNextY { get; set; }
        public static int numberOfField { get; set; } = 1;
        public static int coins { get; set; } = 0;

        public static string[,] CurrentModelOfPlayer { get; set; } = Textures.Player.movingModelOfPlayerR1;

        public Dictionary<int, string> listOfFiles = new Dictionary<int, string>();
        public void Save(string name)
        {
            string savesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");
            string saveFilePath = Path.Combine(savesFolderPath, $"{name}.txt");
            using (StreamWriter writer = new StreamWriter(saveFilePath, false))
            {
                foreach (object unit in SaveCollection)
                {
                    string text = Convert.ToString(unit).Trim('[', ']');
                    writer.WriteLine(text);
                }
            }
        }
        public void Load(string name)
        {
            string savesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");
            string saveFilePath = Path.Combine(savesFolderPath, $"{name}.txt");
            using (StreamReader reader = new StreamReader(saveFilePath, true))
            {
                string infa = reader.ReadToEnd().Trim('[', ']');
                string[] array = infa.Split("\n");
                foreach (string unit in array)
                {
                    if (!string.IsNullOrWhiteSpace(unit))
                    {
                        string nameOfValue = unit.Substring(0, unit.IndexOf(','));
                        string value = unit.Substring(unit.LastIndexOf(',') + 1).Trim();
                        switch (nameOfValue)
                        {
                            case "healthPoints":
                            case "numberOfField":
                            case "playerActualX":
                            case "playerActualY":
                            case "playerNextX":
                            case "playerNextY":
                            case "coins":
                                SaveCollection[nameOfValue] = Convert.ToInt32(value);
                                break;
                            case "InDialogue":
                                SaveCollection[nameOfValue] = Convert.ToBoolean(value);
                                break;
                            case "dirOfMove":
                                SaveCollection[nameOfValue] = value;
                                break;
                            default:
                                SaveCollection[nameOfValue] = value;
                                break;
                        }

                    }
                }

            }

            Engine engine = new Engine();
            engine.RunGame();

        }
        public void SavesWindow()
        {

            string savesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");

            string[] filePaths = Directory.GetFiles(savesFolderPath);

            string[] fileNames = new string[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                fileNames[i] = Path.GetFileName(filePaths[i]);
            }

            int j = 1;
            foreach (string fileName in fileNames)
            {
                listOfFiles.Add(j, Path.GetFileName(fileName.Replace(".txt", "")));
                DialogWindow.DialogEngine.DialogueText($"{j}){fileName}", 180, 85 + j * 10, 0, ConsoleColor.Green);
                j++;
            }
        }
    }
    public class Info
    {

        public void PropertiesActivation1(Properties properties)
        {
            properties.PropertiesActivate();
        }
        private bool IsResponse { get; set; }
        public int coinx = 0;
        public int coiny = 0;
        public class Player1
        {
            public bool CanMove { get; set; } = true;
            public Player1(int initialHealth)
            {
                healthPoints = (int)SaveGameStats.SaveCollection["healthPoints"];
            }
            public bool InDialogue = false;
            public bool IsMoving()
            {
                if (currentPos != prevPos)
                {
                    return true;
                }
                return (DateTime.Now - timeLastMove).TotalSeconds < timeMove;
            }
            public int healthPoints { get; private set; } = (int)SaveGameStats.SaveCollection["healthPoints"];
            private int mana { get; set; }
            public float speed = 12f;

            public DateTime timeLastMove;
            public float timeMove = 0.5f;

            public int x = (int)SaveGameStats.SaveCollection["playerActualX"];
            public int y = (int)SaveGameStats.SaveCollection["playerActualY"];
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
            public void HealHp(int hp)
            {
                SaveGameStats.SaveCollection["healthPoints"] = (int)SaveGameStats.SaveCollection["healthPoints"] + hp;
                if ((int)SaveGameStats.SaveCollection["healthPoints"] > 100)
                {
                    SaveGameStats.SaveCollection["healthPoints"] = 100;
                }
                //SaveGameStats.healthPoints = healthPoints;
                HUD.HealthPointVisual((int)SaveGameStats.SaveCollection["healthPoints"]);

            }
            public void DamageHP(int hp)
            {

                SaveGameStats.SaveCollection["healthPoints"] = (int)SaveGameStats.SaveCollection["healthPoints"] - hp;
                if ((int)SaveGameStats.SaveCollection["healthPoints"] < 0)
                {
                    SaveGameStats.SaveCollection["healthPoints"] = 0;
                }
                //SaveGameStats.healthPoints = healthPoints;
                HUD.HealthPointVisual((int)SaveGameStats.SaveCollection["healthPoints"]);
            }

            public int X_Matrix(int x)
            {
                return (int)(x / 13);
            }
            public int Y_Matrix(int y)
            {
                return (int)(y / 9);
            }
            public int matrix_X { get; set; }
            public int matrix_Y { get; set; }
        }
        public static int[] GetIndexesOfArray2D(Properties[,] array, Properties unit)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
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


    }
    public abstract class Properties
    {
        public abstract void PropertiesActivate();
        public object name { get; set; }
        public static Dictionary<string, Properties> PropertiesCollection = new Dictionary<string, Properties>
                    {
                        {"#", new Wall(false, false, "wallinf")},
                        {"@", new Wall(false, true, "wallinf2")},
                        {" ", new Clear(true, false, "clearinf")},
                        {"m", new Merchant(false, true, "merchantinf")},
                        {"s", new Stone(false, true, "stoneinf")},
                        {"t11", new Tree(false, true, "treeinf")},
                        {"t12", new Tree(false, true, "treeinf")},
                        {"t21", new Tree(false, true, "treeinf")},
                        {"t22", new Tree(false, true, "treeinf")},
                        {"c", new Coin1(false, true, "coin1inf")},
                        {"f", new Frog(false, true, "froginf")},
                    };
        public static Properties[,] matrix1;
        public static Properties[,] matrix2;
        static Player playerinf = new Player(true, false, "playerinf");
        static Clear clearinf = new Clear(true, false, "clearinf");

        Info info = new Info();
        public int layerLvl { get; set; }
        public bool IsMovable { get; set; }

        public bool IsResponse { get; set; }
        public bool IsPassable { get; set; }
        public Properties(bool IsPassable, bool IsResponse)
        {
            this.IsPassable = IsPassable;
            this.IsResponse = IsResponse;
        }
        public static Properties[,] BuildMatrix(string[,] field)
        {
            Properties[,] matrix = new Properties[field.GetLength(0) * 2, field.GetLength(1) * 2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if ((field[i, j] == "#" || field[i, j] == "@") && j >= 1 && i >= 1)
                    {
                        matrix[i - 1, j] = PropertiesCollection[field[i, j]];
                        matrix[i, j - 1] = PropertiesCollection[field[i, j]];
                        matrix[i - 1, j - 1] = PropertiesCollection[field[i, j]];

                    }
                    else if (field[i, j] == " " || field[i, j] == "#" || field[i, j] == "@")
                    {
                        matrix[i, j] = PropertiesCollection[field[i, j]];
                    }
                    else
                    {
                        matrix[i, j] = PropertiesCollection[field[i, j]];
                        matrix[i - 1, j] = PropertiesCollection[field[i, j]];
                        matrix[i, j - 1] = PropertiesCollection[field[i, j]];
                        matrix[i - 1, j - 1] = PropertiesCollection[field[i, j]];
                    }

                }
            }
            return matrix;
        }

        public class Player : Properties
        {
            public Player(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }
            public override void PropertiesActivate()
            {

            }
        }
        public class Merchant : Properties
        {
            public Merchant(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {
                Player1 player = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
                player.HealHp(30);
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                if (consoleKey == ConsoleKey.E)
                {
                    SaveGameStats.InDialogue = true;
                    player.CanMove = false;
                    Engine.Drawing2nd(DialogWindow.DialogueWindow_Visual.dialogueCompanionName, 17, 110, ConsoleColor.Magenta);
                    DialogWindow.DialogueWindow_Visual.DrawingDialoguePortraitMercant(DialogWindow.DialogueWindow_Visual.dialogueCompanionPortrait, 10, 116, ConsoleColor.Magenta, ConsoleColor.Blue);
                    DialogWindow.DialogEngine.DialogueActivationMerchant(0);
                    consoleKey = Console.ReadKey(true).Key;
                    if (consoleKey == ConsoleKey.E || consoleKey == ConsoleKey.W || consoleKey == ConsoleKey.S || consoleKey == ConsoleKey.D || consoleKey == ConsoleKey.A)
                    {
                        player.CanMove = true;
                        for (int i = 0; i < DialogWindow.DialogueWindow_Visual.dialogueCompanionPortrait.GetLength(0) + 6; i++)
                        {
                            for (int j = 0; j < DialogWindow.DialogueWindow_Visual.dialogueCompanionPortrait.GetLength(1); j++)
                            {
                                Console.SetCursorPosition(430 + j, 82 + i);
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }
        }
        public class Coin1 : Properties
        {
            public Coin1(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }
            public override void PropertiesActivate()
            {
                SaveGameStats.SaveCollection["coins"] = (int)SaveGameStats.SaveCollection["coins"] + 1;
                HUD.coinsVisual((int)SaveGameStats.SaveCollection["coins"]);
                Console.SetCursorPosition(10, 3);
                Engine.Drawing2ndRev1(Textures.Clear.clear, GetIndexesOfArray2D(matrix2, PropertiesCollection.GetValueOrDefault("c"))[0] + 1, GetIndexesOfArray2D(matrix2, PropertiesCollection.GetValueOrDefault("c"))[1] + 1, ConsoleColor.Black);
                int xx = GetIndexesOfArray2D(matrix2, PropertiesCollection.GetValueOrDefault("c"))[0];
                int yy = GetIndexesOfArray2D(matrix2, PropertiesCollection.GetValueOrDefault("c"))[1];
                matrix2[yy, xx] = PropertiesCollection.GetValueOrDefault(" ");
                matrix2[yy + 1, xx] = PropertiesCollection.GetValueOrDefault(" ");
                matrix2[yy, xx + 1] = PropertiesCollection.GetValueOrDefault(" ");
                matrix2[yy + 1, xx + 1] = PropertiesCollection.GetValueOrDefault(" ");
            }
        }
        public class Wall : Properties
        {
            public Wall(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {

                if (name == "wallinf2")
                {
                    Render render = new Render();
                    int width = render.FieldCollection[SaveGameStats.numberOfField].GetLength(1) * 13;
                    if (SaveGameStats.playerActualX > width / 2)
                    {
                        SaveGameStats.playerActualX = width - SaveGameStats.playerActualX + 2;
                        SaveGameStats.numberOfField += 1;
                        SaveGameStats.SaveCollection["numberOfField"] = SaveGameStats.numberOfField;
                    }
                    else
                    {
                        SaveGameStats.playerActualX = width - SaveGameStats.playerActualX - 14;
                        SaveGameStats.numberOfField -= 1;
                        SaveGameStats.SaveCollection["numberOfField"] = SaveGameStats.numberOfField;
                    }
                    Engine.RunField(render, SaveGameStats.numberOfField);

                }
            }
        }
        public class Stone : Properties
        {
            public Stone(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {

            }
        }
        public class Clear : Properties
        {
            public Clear(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {

            }
        }
        public class Tree : Properties
        {
            public Tree(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {

            }
        }
        public class Frog : Properties
        {
            public Frog(bool IsPassable, bool IsResponse, object name) : base(IsPassable, IsResponse)
            {
                this.name = name;
            }

            public override void PropertiesActivate()
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                if (consoleKey == ConsoleKey.E)
                {
                    Player1 player = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
                    SaveGameStats.InDialogue = true;
                    player.CanMove = false;
                    DialogWindow.DialogEngine.DialogueActivationFrog(0);
                    if (consoleKey == ConsoleKey.E || consoleKey == ConsoleKey.W || consoleKey == ConsoleKey.S || consoleKey == ConsoleKey.D || consoleKey == ConsoleKey.A)
                    {
                        player.CanMove = true;
                        SaveGameStats.InDialogue = false;
                        for (int i = 0; i < DialogWindow.DialogueWindow_Visual.dialogueCompanionPortrait.GetLength(0) + 6; i++)
                        {
                            for (int j = 0; j < DialogWindow.DialogueWindow_Visual.dialogueCompanionPortrait.GetLength(1); j++)
                            {
                                Console.SetCursorPosition(430 + j, 82 + i);
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }
        }

        public static void SetMatrix(int x, int y)
        {
            matrix2[y, x] = new Properties.Player.Player(true, false, "playerinf");
        }
        public static void ResetMatrix(int x, int y)
        {
            matrix2[y, x] = new Properties.Clear.Clear(true, false, "clearinf");
        }
    }
    public class HUD
    {
        public class HUD_Visual
        {
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
            public static string[,] coinsHUD11 =
            {
                    {" "," "," "," "," "," "," "," "," "," "," "," " },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█"," "," "," "," ","█","█","█","█" },
                    {"█","█","█","█"," "," "," "," "," ","█","█","█" },
                    };
            public static string[,] coinsHUD21 =
            {
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█","█"," "," "," "," "," "," "," "," " },
                    {"█","█","█","█"," "," "," "," "," ","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    {"█","█","█","█","█","█","█","█","█","█","█","█" },
                    };
            public static class HUDNumbers
            {

                public static string[,] HUD0Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD0Number02 =
                {
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD1Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█"," "," "," "," " },
                        {" ","█","█","█","█","█","█","█"," "," "," "," " },
                        {" "," "," "," "," ","█","█","█"," "," "," "," " },
                        {" "," "," "," "," ","█","█","█"," "," "," "," " },
                        };
                public static string[,] HUD1Number02 =
                {
                        {" "," "," "," "," ","█","█","█"," "," "," "," " },
                        {" "," "," "," "," ","█","█","█"," "," "," "," " },
                        {" "," "," "," "," ","█","█","█"," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD2Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD2Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," "," "," "," "," " },
                        {" ","█","█","█"," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD3Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD3Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD4Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD4Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD5Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD5Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD6Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," "," "," "," "," " },
                        {" ","█","█","█"," "," "," "," "," "," "," "," " },
                        };
                public static string[,] HUD6Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD7Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," ","█","█","█","█","█"," " },
                        {" "," "," "," "," "," ","█","█","█","█","█"," " },
                        };
                public static string[,] HUD7Number02 =
                {
                        {" "," "," "," "," ","█","█","█","█"," "," "," " },
                        {" "," "," "," ","█","█","█","█"," "," "," "," " },
                        {" "," "," ","█","█","█","█"," "," "," "," "," " },
                        {" "," ","█","█","█","█"," "," "," "," "," "," " },
                        {" ","█","█","█","█"," "," "," "," "," "," "," " },
                        };
                public static string[,] HUD8Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD8Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,] HUD9Number01 =
                {
                        {" "," "," "," "," "," "," "," "," "," "," "," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█"," "," "," "," ","█","█","█"," " },
                        };
                public static string[,] HUD9Number02 =
                {
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" "," "," "," "," "," "," "," ","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        {" ","█","█","█","█","█","█","█","█","█","█"," " },
                        };
                public static string[,][,] ArrayOfHUDNumbers =
                {
                            {HUD0Number01,HUD0Number02},
                            {HUD1Number01,HUD1Number02},
                            {HUD2Number01,HUD2Number02},
                            {HUD3Number01,HUD3Number02},
                            {HUD4Number01,HUD4Number02},
                            {HUD5Number01,HUD5Number02},
                            {HUD6Number01,HUD6Number02},
                            {HUD7Number01,HUD7Number02},
                            {HUD8Number01,HUD8Number02},
                            {HUD9Number01,HUD9Number02},
                        };
            }
            public static string[,][,] field_HUD =
        {
                    {HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11,HUD_Visual.partOfHUD11, HUD_Visual.partOfHUD11  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.healthPoints11,HUD_Visual.healthPoints12,HUD_Visual.healthPoints13,HUD_Visual.healthPoints14,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.healthPoints21,HUD_Visual.healthPoints22,HUD_Visual.healthPoints23,HUD_Visual.healthPoints24,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.coinsHUD11,HUD_Visual.healthPoints14,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
                    {HUD_Visual.partOfHUD21,HUD_Visual.coinsHUD21,HUD_Visual.healthPoints24,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUDClear,HUD_Visual.partOfHUD23  },
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
        }

        public static void Drawing2nd(string[,] array, int X, int Y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j + X + 430, i + Y);
                    Console.Write(array[i, j]);
                }

            }


        }

        public static void HealthPointVisual(int hp)
        {
            ConsoleColor color = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Drawing2nd(HUD_Visual.partOfHUDClear, 5 * 12, 5, ConsoleColor.Red);
            Drawing2nd(HUD_Visual.partOfHUDClear, 5 * 12, 5 * 2, ConsoleColor.Red);
            Drawing2nd(HUD_Visual.partOfHUDClear, 5 * 12, 5 * 3, ConsoleColor.Red);
            int[] n = new int[3];
            int i = 0;
            while (hp > 0)
            {
                n[i]  = hp % 10;
                hp /= 10;
                HUD.HUD_Visual.field_HUD[1, 7 - i] = HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 0];
                HUD.HUD_Visual.field_HUD[2, 7 - i] = HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 1];
                Drawing2nd(HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 0], (7 - i) * 12, 5, ConsoleColor.Red);
                Drawing2nd(HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 1], (7 - i) * 12, 5 * 2, ConsoleColor.Red);
                i++;
            }
            Console.BackgroundColor = color;
        }
        public static void coinsVisual(int coins)
        {
            ConsoleColor color = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            int[] n = new int[2];
            int i = 0;
            while (coins > 0)
            {
                n[i]  = coins % 10;
                coins /= 10;
                HUD.HUD_Visual.field_HUD[4, 4 - i] = HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 0];
                HUD.HUD_Visual.field_HUD[5, 4 - i] = HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 1];
                Drawing2nd(HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 0], (4 - i) * 12, 5 * 4, ConsoleColor.DarkYellow);
                Drawing2nd(HUD_Visual.HUDNumbers.ArrayOfHUDNumbers[n[i], 1], (4 - i) * 12, 5 * 5, ConsoleColor.DarkYellow);
                i++;
            }
            Console.BackgroundColor = color;
        }
        public static void Show_HUD(string[,][,] field)
        {

            Player1 player = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
            coinsVisual(SaveGameStats.coins);
            HealthPointVisual(player.healthPoints);
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (x >= 1 && x <= 7 && y >= 1 && y <= 2)
                    {
                        Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.Red);
                    }
                    else
                    {
                        Drawing2nd(field[y, x], x * 12, y * 5, ConsoleColor.DarkYellow);
                    }

                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    public class DialogWindow
    {
        public class DialogEngine
        {
            public static void DialogueActivationMerchant(int number)
            {
                if (number == 0)
                {
                    DialogueText("hello, stranger!", 80, 115, 70, ConsoleColor.DarkMagenta);
                    DialogueText("how did you get here?", 80, 122, 70, ConsoleColor.DarkMagenta);
                    DialogueText("1)hi! um... i dont even know.", 380, 115, 0, ConsoleColor.DarkGreen);
                    DialogueText("who are you?", 380, 122, 0, ConsoleColor.DarkGreen);
                    DialogueText("2)hello, im just taking a walk", 380, 129, 0, ConsoleColor.DarkGreen);
                    ConsoleKey answ = Console.ReadKey(true).Key;
                    while (answ != ConsoleKey.D1 && answ != ConsoleKey.D2)
                    {
                        answ = Console.ReadKey(true).Key;
                    }
                    if (answ == ConsoleKey.D1)
                    {
                        for (int i = 0; i < 35; i++)
                        {
                            for (int j = 0; j < 550; j++)
                            {
                                Console.SetCursorPosition(j + 80, i + 115);
                                Console.Write(" ");
                            }
                        }
                        DialogueText("im a merchant in this strange town.", 80, 115, 70, ConsoleColor.DarkMagenta);
                        DialogueText("i sell soooo weird and interesting things))", 80, 122, 70, ConsoleColor.DarkMagenta);
                        DialogueText("they will interest you!", 80, 129, 70, ConsoleColor.DarkMagenta);
                        Thread.Sleep(500);
                        DialogueText("1)oh wow, thats so cool,", 380, 115, 0, ConsoleColor.DarkGreen);
                        DialogueText("but i have no money((", 380, 122, 0, ConsoleColor.DarkGreen);
                        DialogueText("2)can you tell me about this town?", 380, 129, 0, ConsoleColor.DarkGreen);
                        answ = Console.ReadKey(true).Key;
                        while (answ != ConsoleKey.D1 && answ != ConsoleKey.D2)
                        {
                            answ = Console.ReadKey(true).Key;
                        }
                        if (answ == ConsoleKey.D1)
                        {

                            for (int i = 0; i < 35; i++)
                            {
                                for (int j = 0; j < 550; j++)
                                {
                                    Console.SetCursorPosition(j + 80, i + 115);
                                    Console.Write(" ");
                                }
                            }
                            DialogueText("ohh, dear, thats not problem,", 80, 115, 70, ConsoleColor.DarkMagenta);
                            DialogueText("you can sell me something.", 80, 122, 70, ConsoleColor.DarkMagenta);
                            DialogueText("...  ", 80, 129, 500, ConsoleColor.DarkMagenta);
                            DialogueText("   ", 80, 129, 0, ConsoleColor.DarkMagenta);
                            DialogueWindow_Visual.DrawingDialoguePortraitMercant(DialogueWindow_Visual.dialogueCompanionPortraitEvil, 10, 116, ConsoleColor.Magenta, ConsoleColor.Red);
                            DialogueText("what about your soul?))", 80, 129, 70, ConsoleColor.Red);
                            Thread.Sleep(2000);
                            for (int i = 0; i < 35; i++)
                            {
                                for (int j = 0; j < 550; j++)
                                {
                                    Console.SetCursorPosition(j + 80, i + 115);
                                    Console.Write(" ");
                                }
                            }
                            DialogueWindow_Visual.DrawingDialoguePortraitMercant(DialogueWindow_Visual.dialogueCompanionPortrait, 10, 116, ConsoleColor.Magenta, ConsoleColor.Cyan);
                            DialogueText("just joking heh)))", 80, 115, 70, ConsoleColor.DarkMagenta);
                            DialogueText("1)wait... what? what do you mean?", 380, 115, 0, ConsoleColor.DarkGreen);
                            DialogueText("2)im ready to sell my soul", 380, 122, 0, ConsoleColor.DarkRed);
                            answ = new ConsoleKey();
                            answ = Console.ReadKey(true).Key;
                            while (answ != ConsoleKey.D1 && answ != ConsoleKey.D2)
                            {
                                answ = Console.ReadKey(true).Key;
                            }
                            if (answ == ConsoleKey.D1)
                            {
                                for (int i = 0; i < 35; i++)
                                {
                                    for (int j = 0; j < 550; j++)
                                    {
                                        Console.SetCursorPosition(j + 80, i + 115);
                                        Console.Write(" ");
                                    }
                                }
                                DialogueText("boy, i am telling you.", 80, 115, 70, ConsoleColor.DarkMagenta);
                                DialogueText("you should be ready", 80, 122, 70, ConsoleColor.DarkMagenta);
                                DialogueText("for such jokes!", 80, 129, 70, ConsoleColor.DarkMagenta);
                                DialogueText("1)leave the dialogue", 380, 115, 0, ConsoleColor.DarkGreen);

                                answ = Console.ReadKey(true).Key;
                                while (answ != ConsoleKey.D1)
                                {
                                    answ = Console.ReadKey(true).Key;
                                }
                                if (answ == ConsoleKey.D1)
                                {
                                    for (int i = 0; i < 60; i++)
                                    {
                                        for (int j = 0; j < 900; j++)
                                        {
                                            Console.SetCursorPosition(j, i + 110);
                                            Console.Write(" ");
                                        }
                                    }
                                    for (int i = 0; i < 60; i++)
                                    {
                                        for (int j = 0; j < 900; j++)
                                        {
                                            Console.SetCursorPosition(j, i + 110);
                                            Console.Write(" ");
                                        }
                                    }

                                }

                            }
                            else if (answ == ConsoleKey.D2)
                            {
                                Animations.AfterDeathAnimation("You have lost your soul)");
                            }
                        }
                        else if (answ == ConsoleKey.D2)
                        {
                            for (int i = 0; i < 35; i++)
                            {
                                for (int j = 0; j < 550; j++)
                                {
                                    Console.SetCursorPosition(j + 80, i + 115);
                                    Console.Write(" ");
                                }
                            }
                            DialogueText("this place once was popular among ", 80, 115, 70, ConsoleColor.DarkMagenta);
                            DialogueText("adventurers, merchants, and other people,", 80, 122, 70, ConsoleColor.DarkMagenta);
                            DialogueText("but everything changed since", 80, 129, 70, ConsoleColor.DarkMagenta);
                            DialogueText("(unknown) became our governor", 80, 136, 70, ConsoleColor.DarkMagenta);
                            DialogueText("1) god, what happened", 380, 115, 0, ConsoleColor.DarkGreen);
                            DialogueText("to this place?", 380, 122, 0, ConsoleColor.DarkGreen);
                            DialogueText("2) who is that (unknown)?", 380, 129, 0, ConsoleColor.DarkGreen);
                            DialogueText("is he villain?", 380, 136, 0, ConsoleColor.DarkGreen);
                            answ = Console.ReadKey(true).Key;
                            while (answ != ConsoleKey.D1 && answ != ConsoleKey.D2)
                            {
                                answ = Console.ReadKey(true).Key;
                            }
                            if (answ == ConsoleKey.D1)
                            {
                                for (int i = 0; i < 35; i++)
                                {
                                    for (int j = 0; j < 550; j++)
                                    {
                                        Console.SetCursorPosition(j + 80, i + 115);
                                        Console.Write(" ");
                                    }
                                }
                                DialogueText("most of the towns population", 80, 115, 70, ConsoleColor.DarkMagenta);
                                DialogueText("died or went missing.", 80, 122, 70, ConsoleColor.DarkMagenta);
                                DialogueText("since then, strange personalities", 80, 129, 70, ConsoleColor.DarkMagenta);
                                DialogueText("began to appear", 80, 136, 70, ConsoleColor.DarkMagenta);
                            }
                            else if (answ == ConsoleKey.D2)
                            {
                                for (int i = 0; i < 35; i++)
                                {
                                    for (int j = 0; j < 550; j++)
                                    {
                                        Console.SetCursorPosition(j + 80, i + 115);
                                        Console.Write(" ");
                                    }
                                }
                                DialogueText("kf2t5wn1b8vs95try4plm8azs", 80, 115, 100, ConsoleColor.DarkRed);
                                DialogueText("1)leave the dialogue", 380, 136, 0, ConsoleColor.DarkGreen);
                                while (answ != ConsoleKey.D1)
                                {
                                    answ = Console.ReadKey(true).Key;
                                }
                                if (answ == ConsoleKey.D1)
                                {
                                    for (int i = 0; i < 60; i++)
                                    {
                                        for (int j = 0; j < 900; j++)
                                        {
                                            Console.SetCursorPosition(j, i + 110);
                                            Console.Write(" ");
                                        }
                                    }
                                    for (int i = 0; i < 60; i++)
                                    {
                                        for (int j = 0; j < 900; j++)
                                        {
                                            Console.SetCursorPosition(j, i + 110);
                                            Console.Write(" ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (answ == ConsoleKey.D2)
                    {
                        for (int i = 0; i < 35; i++)
                        {
                            for (int j = 0; j < 550; j++)
                            {
                                Console.SetCursorPosition(j + 80, i + 115);
                                Console.Write(" ");
                            }
                        }
                        DialogueText("you choose the wrong", 80, 115, 70, ConsoleColor.DarkMagenta);
                        DialogueText("place to walk!", 80, 122, 70, ConsoleColor.DarkMagenta);
                        DialogueText("look around sometimes...", 80, 129, 70, ConsoleColor.DarkRed);
                        DialogueText("1)leave the dialogue", 380, 115, 0, ConsoleColor.DarkGreen);

                        answ = Console.ReadKey(true).Key;
                        while (answ != ConsoleKey.D1)
                        {
                            answ = Console.ReadKey(true).Key;
                        }
                        if (answ == ConsoleKey.D1)
                        {
                            for (int i = 0; i < 60; i++)
                            {
                                for (int j = 0; j < 900; j++)
                                {
                                    Console.SetCursorPosition(j, i + 110);
                                    Console.Write(" ");
                                }
                            }
                        }
                    }
                    SaveGameStats.InDialogue = false;
                }
            }
            public static void DialogueActivationFrog(int number)
            {
                DialogueText("froggy", 20, 115, 0, ConsoleColor.Green);
                if (number == 0)
                {
                    DialogueText("hello, dear player!", 80, 115, 70, ConsoleColor.Green);
                    DialogueText("i am froggy", 80, 122, 70, ConsoleColor.Green);
                    DialogueText("i am here to teach you the basics of this game.", 80, 129, 70, ConsoleColor.Green);

                    Thread.Sleep(3000);

                    DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                    DialogueText("                                                            ", 80, 122, 0, ConsoleColor.Green);
                    DialogueText("                                                            ", 80, 129, 0, ConsoleColor.Green);

                    DialogueText("to move, use the keys (w), (a), (s), (d).", 80, 115, 70, ConsoleColor.Green);
                    DialogueText("to interact with objects, use the key (e).", 80, 122, 70, ConsoleColor.Green);

                    Thread.Sleep(3000);

                    DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                    DialogueText("                                                            ", 80, 122, 0, ConsoleColor.Green);

                    DialogueText("to leave the game use the key (esc)", 80, 115, 70, ConsoleColor.Green);

                    Thread.Sleep(3000);

                    DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);

                    DialogueText("in dialogue you can answer, if its possible", 80, 115, 70, ConsoleColor.Green);
                    DialogueText("on the right side of dialogue window", 80, 122, 70, ConsoleColor.Green);
                    DialogueText("you can see your answer lines", 80, 129, 70, ConsoleColor.Green);

                    Thread.Sleep(3000);

                    DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                    DialogueText("                                                            ", 80, 122, 0, ConsoleColor.Green);
                    DialogueText("                                                            ", 80, 129, 0, ConsoleColor.Green);

                    DialogueText("lets practice!", 80, 115, 70, ConsoleColor.Green);
                    Thread.Sleep(2000);
                    DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                    DialogueText("hello, how are you?", 80, 115, 70, ConsoleColor.Green);
                    DialogueText("press 1 or 2 or 3 to choose the line", 80, 136, 70, ConsoleColor.Green);
                    DialogueText("1)hi, frog!", 420, 115, 0, ConsoleColor.DarkGreen);

                    ConsoleKey answ = Console.ReadKey(true).Key;
                    while (answ != ConsoleKey.D1)
                    {
                        answ = Console.ReadKey(true).Key;
                    }
                    if (answ == ConsoleKey.D1)
                    {
                        DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                        DialogueText("                                                            ", 80, 136, 0, ConsoleColor.Green);
                        DialogueText("               ", 420, 115, 0, ConsoleColor.DarkGreen);
                        DialogueText("nice! you did it very well", 80, 115, 70, ConsoleColor.Green);
                        DialogueText("so i think you are completely ready", 80, 122, 70, ConsoleColor.Green);
                        DialogueText("good luck to you, stranger", 80, 129, 70, ConsoleColor.Green);

                        Thread.Sleep(3000);

                        DialogueText("                                                            ", 80, 115, 0, ConsoleColor.Green);
                        DialogueText("                                                            ", 80, 122, 0, ConsoleColor.Green);
                        DialogueText("                                                            ", 80, 129, 0, ConsoleColor.Green);

                        DialogueText("do not trust anyone here!", 80, 115, 90, ConsoleColor.DarkRed);
                        DialogueText("press (e) to leave the dialogue...", 80, 129, 70, ConsoleColor.Green);

                        answ = Console.ReadKey(true).Key;
                        while (answ != ConsoleKey.E)
                        {
                            answ = Console.ReadKey(true).Key;
                        }
                        if (answ == ConsoleKey.E)
                        {
                            DialogueText("                                                                                        ", 20, 115, 0, ConsoleColor.Green);
                            DialogueText("                                                                                        ", 20, 129, 0, ConsoleColor.Green);
                        }
                    }
                }
            }

            public static void DialogueText(string text, int x, int y, int time, ConsoleColor color)
            {

                for (int i = 0; i < text.Length; i++)
                {
                    Thread.Sleep(time);
                    char letter = text[i];
                    if (letter >= 'a' && letter <= 'z')
                    {
                        int index = letter - 'a';
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == ',')
                    {
                        int index = 26;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == '.')
                    {
                        int index = 27;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == ' ')
                    {
                        int index = 28;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == '?')
                    {
                        int index = 29;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], x + i * 7, y + 0, color);
                    }
                    else if (letter == '!')
                    {
                        int index = 30;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == '(')
                    {
                        int index = 31;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == ')')
                    {
                        int index = 32;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter >= '0' && letter <= '9')
                    {
                        int index = letter - '0' + 33;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                    else if (letter == '-')
                    {
                        int index = 43;
                        Drawing2nd(DialogueWindowLetters.arrayOfLetters[index], i * 7 + x, y + 0, color);
                    }
                }
            }
        }
        public class DialogueWindowLetters
        {
            public static string[,] letterA =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterB =
            {
                    {" ","█","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterC =
            {
                    {" "," ","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," ","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterD =
            {
                    {" ","█","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterE =
            {
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterF =
            {
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterG =
            {
                    {" "," ","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," ","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterH =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterI =
            {
                    {" ","█","█","█","█","█"," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterJ =
            {
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," "," ","█"," "," " },
                    {" ","█","█","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterK =
            {
                    {" ","█"," "," ","█","█"," " },
                    {" ","█"," "," ","█"," "," " },
                    {" ","█","█","█"," "," "," " },
                    {" ","█"," "," ","█"," "," " },
                    {" ","█"," "," ","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterL =
            {
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterM =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█"," ","█","█"," " },
                    {" ","█"," ","█"," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterN =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█"," "," ","█"," " },
                    {" ","█"," ","█"," ","█"," " },
                    {" ","█"," "," ","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterO =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterP =
            {
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterQ =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterR =
            {
                    {" ","█","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" ","█"," "," ","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterS =
            {
                    {" "," ","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterT =
            {
                    {" ","█","█","█","█","█"," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterU =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterV =
           {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█"," ","█"," "," " },
                    {" "," ","█"," ","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterW =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," ","█"," ","█"," " },
                    {" ","█"," ","█"," ","█"," " },
                    {" "," ","█"," ","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterX =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█"," ","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," ","█"," ","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterY =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█"," ","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] letterZ =
            {
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] comma =
            {
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    };
            public static string[,] dot =
            {
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] space =
            {
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] answchar =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," ","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] exclamationPointchar =
            {
                    {" "," ","█","█","█"," "," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number0 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number1 =
            {
                    {" "," "," ","█"," "," "," " },
                    {" "," ","█","█"," "," "," " },
                    {" ","█"," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number2 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," ","█","█"," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number3 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," "," ","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number4 =
            {
                    {" ","█"," "," "," ","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number5 =
            {
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" ","█","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number6 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number7 =
            {
                    {" ","█","█","█","█","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," ","█"," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number8 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" ","█","█","█","█","█"," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] number9 =
            {
                    {" "," ","█","█","█"," "," " },
                    {" ","█"," "," "," ","█"," " },
                    {" "," ","█","█","█","█"," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," ","█","█","█"," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] bracketR =
            {
                    {" ","█"," "," "," "," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" "," ","█"," "," "," "," " },
                    {" ","█"," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] bracketL =
            {
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," "," ","█"," "," " },
                    {" "," "," "," "," ","█"," " },
                    {" "," "," "," "," "," "," " },
                    };
            public static string[,] dash =
            {
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," ","█","█","█","█"," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    {" "," "," "," "," "," "," " },
                    };


            public static string[][,] arrayOfLetters =
            {
                        letterA,
                        letterB,
                        letterC,
                        letterD,
                        letterE,
                        letterF,
                        letterG,
                        letterH,
                        letterI,
                        letterJ,
                        letterK,
                        letterL,
                        letterM,
                        letterN,
                        letterO,
                        letterP,
                        letterQ,
                        letterR,
                        letterS,
                        letterT,
                        letterU,
                        letterV,
                        letterW,
                        letterX,
                        letterY,
                        letterZ,
                        comma,
                        dot,
                        space,
                        answchar,
                        exclamationPointchar,
                        bracketL,
                        bracketR,
                        number0,
                        number1,
                        number2,
                        number3,
                        number4,
                        number5,
                        number6,
                        number7,
                        number8,
                        number9,
                        dash,
                    };
        }
        public class DialogueWindow_Visual
        {
            public static void DrawingDialoguePortraitMercant(string[,] array, int X, int Y, ConsoleColor color, ConsoleColor color2)
            {
                Console.CursorVisible = false;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (j > 15 && j < 21 && i > 7 && i < 10 || i > 7 && i < 10 && j > 34 && j < 41)
                        {
                            Console.ForegroundColor = color2;
                        }
                        else
                        {
                            Console.ForegroundColor = color;
                        }
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(array[i, j]);
                    }

                }


            }
            public static string[,] dialogueCompanionName =
            {
                    {"█"," "," "," ","█"," ","█","█","█","█"," ","█","█","█"," "," "," ","█","█","█"," ","█"," "," "," ","█"," "," ","█","█"," "," ","█"," "," "," ","█"," ","█","█","█","█","█", },
                    {"█","█"," ","█","█"," ","█"," "," "," "," ","█"," "," ","█"," ","█"," "," "," "," ","█"," "," "," ","█"," ","█"," "," ","█"," ","█","█"," "," ","█"," "," "," ","█"," "," ", },
                    {"█"," ","█"," ","█"," ","█","█","█","█"," ","█","█","█"," "," ","█"," "," "," "," ","█","█","█","█","█"," ","█","█","█","█"," ","█"," ","█"," ","█"," "," "," ","█"," "," ", },
                    {"█"," "," "," ","█"," ","█"," "," "," "," ","█"," "," ","█"," ","█"," "," "," "," ","█"," "," "," ","█"," ","█"," "," ","█"," ","█"," "," ","█","█"," "," "," ","█"," "," ", },
                    {"█"," "," "," ","█"," ","█","█","█","█"," ","█"," "," ","█"," "," ","█","█","█"," ","█"," "," "," ","█"," ","█"," "," ","█"," ","█"," "," "," ","█"," "," "," ","█"," "," ", },
                    };
            public static string[,] dialogueCompanionPortrait =
            {
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," ","█","█","█","█","█"," ","█","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█"," ","█","█","█","█","█"," "," "," "," "," "," ", },
                    {" "," "," "," ","█","█","█"," ","█","█","█","█","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█"," "," "," "," ", },
                    {" "," "," ","█","█","█","█","█","█"," ","█"," ","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█"," ","█"," ","█"," "," "," ", },
                    {" "," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█","█","█"," ","█","█","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█"," ","█","█","█","█","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█"," ","█"," ","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█"," "," "," ","█","█","█"," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," ","█","█","█"," "," "," "," ","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," ","█","█","█","█"," "," "," ","█","█","█","█","█","█","█","█"," "," "," ","█","█","█","█"," "," "," ","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█"," ","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█"," ","█"," ","█"," "," ", },
                    {" "," "," ","█"," ","█"," ","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█"," "," "," ","█","█","█","█","█","█"," "," "," ","█","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█"," ","█"," ","█"," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█"," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," ","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█"," "," ","█","█","█","█","█","█","█","█"," "," ","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ", },
                    {" "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," ", },
                    {" "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," ", },
                    {" ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    };
            public static string[,] dialogueCompanionPortraitEvil =
            {
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," ","█","█","█","█","█"," ","█","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█"," ","█","█","█","█","█"," "," "," "," "," "," ", },
                    {" "," "," "," ","█","█","█"," ","█","█","█","█","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█"," "," "," "," ", },
                    {" "," "," ","█","█","█","█","█","█"," ","█"," ","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█"," ","█","█"," ","█"," ","█"," "," "," ", },
                    {" "," ","█"," ","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█","█","█"," ","█","█","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█"," ","█","█","█","█","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█"," ","█"," ","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█"," "," "," ","█","█","█"," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," ","█","█","█"," "," "," "," ","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," ","█","█","█","█"," "," "," ","█","█","█","█","█","█","█","█"," "," "," ","█","█","█","█"," "," "," ","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," ","█"," "," ", },
                    {" "," ","█","█","█"," ","█","█","█"," ","█","█","█","█","█","█","█","█","█"," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," ","█","█","█","█","█","█","█","█","█"," ","█","█","█"," ","█","█","█"," "," ", },
                    {" "," ","█"," ","█"," ","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█"," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," ","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█"," ","█"," ","█"," "," ", },
                    {" "," "," ","█"," ","█"," ","█"," ","█"," ","█"," ","█","█","█","█","█","█","█","█"," "," "," "," ","█","█","█","█","█","█"," "," "," "," ","█","█","█","█","█","█","█","█"," ","█"," ","█"," ","█"," ","█"," ","█"," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█"," "," ","█","█","█","█","█","█","█","█","█","█","█","█"," "," ","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","█","█","█","█"," "," ","█","█","█","█","█","█","█","█"," "," ","█","█","█","█"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," "," "," "," ", },
                    {" "," "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," "," ", },
                    {" "," ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," "," ", },
                    {" ","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█"," ", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    {"█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█","█", },
                    };
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

        public Dictionary<int, string[,]> FieldCollection = new Dictionary<int, string[,]>()
                {
                    {1, Field1 },
                    {2, Field2 },
                };
        public static string[,] Field1 =
        {
                    {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "f", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "@", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                };
        public static string[,] Field2 =
        {
                    {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                    {"#", " ", " ", " ", " ", "s", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "t11", "t12", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", "s", " ", " ", " ", "t21", "t22", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "m", " ", " ", " ", " ", "#", },
                    {"@", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"@", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"@", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"@", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", " ", " ", " ", " ", " ", " ", "t11", "t12", " ", " ", " ", " ", " ", " ", " ", "t11", "t12", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", },
                    {"#", " ", " ", "s", " ", " ", " ", " ", " ", "t21", "t22", " ", " ", "c", " ", " ", " ", " ", "t21", "t22", " ", " ", " ", " ", " ", " ", " ", "s", " ", " ", " ", "#", },
                    {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                };


        public static void Draw(string[,] field)
        {
            Render render = new Render();
            Info info = new Info();
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    Drawing2nd(Textures.TexturesCollection[field[y, x]].texture, render.X(x), render.Y(y), Textures.TexturesCollection[field[y, x]].color);
                }
            }
        }
    }
    public class Animations
    {
        public void AnimatedMoveDraw(string[,][,] arrayOfModelsOfObject, int X, int Y, bool IsMoving, float speed, string direction, ConsoleColor color)
        {
            Player player = new Player();
            Player1 playerInfo = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
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
                    Console.SetCursorPosition(j + X, i + Y);
                    Console.Write(currentModel(arrayOfModelsOfObject, IsMoving, player.dirOfMove)[i, j]);
                }

            }
        }
        public class Player
        {
            public string dirOfMove { get; internal set; }

        }

        public static void AfterDeathAnimation(string reason)
        {
            Console.Clear();
            DialogWindow.DialogEngine.DialogueText("you are dead.", 280, 44, 330, ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 80; i++)
            {

                for (int j = 0; j < 80; j++)
                {
                    if (j == 3|| j == 29 || j == 40 || j == 60 || j == 71 || j == 79)
                    {
                        Console.SetCursorPosition(280 + j, 49 + i);
                        Console.Write("█");
                    }
                }
                Thread.Sleep(1200);
            }

        }
    }
    public class Textures
    {
        public ConsoleColor color { get; set; }
        public string[,] texture { get; set; }
        public Textures()
        {

        }
        public Textures(string[,] texture, ConsoleColor color)
        {
            this.color = color;
            this.texture = texture;
        }


        public static Dictionary<string, Textures> TexturesCollection = new Dictionary<string, Textures>
                {
                    {"#", new Textures(Walls.wall1, ConsoleColor.Blue) },
                    {"@", new Textures(Walls.wall2, ConsoleColor.Blue) },
                    {" ", new Textures(Clear.clear, ConsoleColor.Black) },
                    {"m", new Textures(NPC.Mercant.movingModelOfMerchantR1, ConsoleColor.Magenta) },
                    {"t11", new Textures(Trees.tree11, ConsoleColor.Green) },
                    {"t12", new Textures(Trees.tree12, ConsoleColor.Green) },
                    {"t21", new Textures(Trees.tree21, ConsoleColor.Green) },
                    {"t22", new Textures(Trees.tree22, ConsoleColor.Green) },
                    {"s", new Textures(Stone.stone1, ConsoleColor.Gray) },
                    {"c", new Textures(Coins.coin1, ConsoleColor.Yellow) },
                    {"f", new Textures(NPC.Frog.frogModel, ConsoleColor.Green) },
                };
        public class Player
        {

            public static string[,] normalModelOfPlayerR =
            {
                    {" ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", "▓", " ", "▓", "▓", " ", " ", "▓", " ", " ", " " },
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
                    {" ", " ", " ", " ", " ", " ", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", " ", " ", "▓", " ", " ", "▓", "▓", " ", "▓", " ", " ", " " },
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
        public class NPC
        {
            public class Mercant
            {
                public static string[,] movingModelOfMerchantR1 =
                {
                        {" ", " ", " ", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                        {" ", "▓", "▓", "▓", " ", "▓", "▓", " ", "▓", "▓", "▓", " ", " " },
                        {" ", " ", " ", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                        {" ", " ", " ", " ", " ", "▓", "▓", " ", " ", " ", " ", " ", " " },
                        {" ", " ", " ", "▓", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " " },
                        {" ", " ", "▓", " ", " ", "▓", "▓", " ", " ", " ", "▓", " ", " " },
                        {" ", "▓", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " ", " " },
                        {" ", " ", " ", "▓", " ", " ", " ", "▓", " ", " ", " ", " ", " " },
                        {" ", " ", " ", "▓", " ", " ", " ", " ", "▓", " ", " ", " ", " " },
                        };
            }
            public class Frog
            {
                public static string[,] frogModel =
                {
                        {" ", " ", "▓", "▓", " ", " ", " ", " ", " ", "▓", "▓", " ", " " },
                        {" ", "▓", "▓", "▓", "▓", " ", " ", " ", "▓", "▓", "▓", "▓", " " },
                        {"▓", "▓", "▓", " ", "▓", "▓", "▓", "▓", "▓", " ", "▓", "▓", "▓" },
                        {"▓", "▓", "▓", " ", "▓", "▓", "▓", "▓", "▓", " ", "▓", "▓", "▓" },
                        {"▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓" },
                        {" ", "▓", "▓", "▓", "▓", " ", " ", " ", "▓", "▓", "▓", "▓", " " },
                        {" ", " ", " ", "▓", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " " },
                        {" ", " ", "▓", "▓", "▓", "▓", " ", "▓", "▓", "▓", "▓", " ", " " },
                        {" ", "▓", "▓", "▓", "▓", " ", " ", " ", "▓", "▓", "▓", "▓", " " },
                        };
            }
        }
        public class Stone
        {
            public static string[,] stone1 =
            {
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {" ", " ", " ", " ", "▓", "▓", "▓", " ", " ", " ", " ", " ", " " },
                    {" ", " ", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " ", " " },
                    {" ", " ", "▓", "▓", "▓", "▓", "▓", "▓", "▓", " ", " ", " ", " " },
                    {" ", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", " ", " " },
                    {"▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", " ", " " },
                    {"▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓" }
                };
        }
        public static class Clear
        {
            public static string[,] clear =
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
            public static string[,] wall2 =
            {
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    {"░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░", "░" },
                    };
        }
        public static class Trees
        {
            public static string[,] tree11 =
            {
                    {" ", " ", " ", " ", " ", " ", " ", "█", "█", "█", "█", "█", "█" },
                    {" ", " ", " ", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {" ", " ", "█", "█", "█", "█", "█", "█", " ", " ", "█", "█", "█" },
                    {" ", "█", "█", "█", " ", " ", " ", " ", "█", "█", " ", "█", "█" },
                    {"█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", " ", "█" },
                    {"█", "█", " ", "█", "█", "█", "█", " ", " ", " ", "█", "█", "█" },
                    {"█", "█", "█", "█", " ", " ", " ", "█", "█", "█", " ", " ", "█" },
                    {" ", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {" ", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                    };
            public static string[,] tree12 =
            {
                    {"█", "█", "█", "█", "█", "█", " ", " ", " ", " ", " ", " ", " " },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", " ", " ", " ", " " },
                    {"█", "█", "█", " ", " ", "█", "█", "█", "█", "█", "█", " ", " " },
                    {"█", "█", " ", "█", "█", " ", " ", " ", " ", "█", "█", "█", " " },
                    {"█", " ", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█" },
                    {"█", "█", "█", " ", " ", " ", "█", "█", "█", "█", " ", "█", "█" },
                    {"█", " ", " ", "█", "█", "█", " ", " ", " ", "█", "█", "█", "█" },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", " " },
                    {"█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", " " },
                    };
            public static string[,] tree21 =
            {
                    {" ", " ", " ", " ", "█", "█", " ", " ", "█", "█", " ", "█", "█" },
                    {" ", " ", " ", " ", " ", "█", "█", "█", " ", "█", "█", " ", "█" },
                    {" ", " ", " ", " ", " ", " ", " ", "█", "█", " ", "█", "█", "█" },
                    {" ", " ", " ", " ", " ", " ", " ", " ", "█", "█", " ", "█", "█" },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", "█", "█", "█", "█" },
                    {" ", " ", " ", " ", " ", " ", " ", " ", " ", "█", "█", "█", "█" },
                    {" ", " ", " ", " ", " ", "█", "█", "█", "█", "█", "█", "█", "█" },
                    {" ", " ", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█" },
                    {" ", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█", "█", "█" },
                    };
            public static string[,] tree22 =
            {
                    {"█", "█", " ", "█", "█", " ", " ", "█", "█", " ", " ", " ", " " },
                    {"█", " ", "█", "█", " ", "█", "█", "█", " ", " ", " ", " ", " " },
                    {"█", "█", "█", " ", "█", "█", " ", " ", " ", " ", " ", " ", " " },
                    {"█", "█", " ", "█", "█", " ", " ", " ", " ", " ", " ", " ", " " },
                    {"█", "█", "█", "█", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {"█", "█", "█", "█", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                    {"█", "█", "█", "█", "█", "█", "█", "█", " ", " ", " ", " ", " " },
                    {"█", " ", "█", "█", " ", "█", "█", "█", "█", "█", "█", " ", " " },
                    {"█", " ", "█", "█", " ", "█", " ", "█", "█", " ", "█", "█", " " },
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

    public class Engine
    {
        public static void Moving(SaveGameStats saveGameStats)
        {
            Info ObjectForPropertiesAct = new Info();
            Textures.Player player = new Textures.Player();
            Player1 playerInfo = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
            Animations animations = new Animations();
            while (playerInfo.CanMove && !SaveGameStats.InDialogue)
            {
                ConsoleKey consoleKey;

                consoleKey = Console.ReadKey(true).Key;
                SaveGameStats.playerNextX = SaveGameStats.playerActualX;
                SaveGameStats.playerNextY = SaveGameStats.playerActualY;
                Thread.Sleep(10);
                Properties.SetMatrix(SaveGameStats.playerActualX / 13, SaveGameStats.playerActualY / 9);
                switch (consoleKey)
                {
                    case ConsoleKey.W:
                        SaveGameStats.playerNextY -= (int)(playerInfo.speed / 6);
                        break;
                    case ConsoleKey.S:
                        SaveGameStats.playerNextY += (int)(playerInfo.speed / 6);
                        break;
                    case ConsoleKey.D:
                        SaveGameStats.dirOfMove = "right";
                        SaveGameStats.playerNextX += (int)(playerInfo.speed / 3);
                        break;
                    case ConsoleKey.A:
                        SaveGameStats.dirOfMove = "left";
                        SaveGameStats.playerNextX -= (int)(playerInfo.speed / 3);
                        break;
                    case ConsoleKey.H:
                        saveGameStats.Save($"save{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}");
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                }
                //playerInfo.matrix_X = (int)(SaveGameStats.playerActualX / 13);
                //playerInfo.matrix_Y = (int)(SaveGameStats.playerActualY / 9);
                if (Properties.matrix2[playerInfo.Y_Matrix(SaveGameStats.playerNextY), playerInfo.X_Matrix(SaveGameStats.playerNextX)].IsPassable)
                {
                    Properties.ResetMatrix((int)(SaveGameStats.playerActualX / 13), (int)(SaveGameStats.playerActualY / 9));
                    Drawing2nd(Textures.Clear.clear, SaveGameStats.playerActualX, SaveGameStats.playerActualY, ConsoleColor.Red);
                    SaveGameStats.playerActualX = SaveGameStats.playerNextX;
                    SaveGameStats.playerActualY = SaveGameStats.playerNextY;
                    SaveGameStats.SaveCollection["playerActualX"] = SaveGameStats.playerNextX;
                    SaveGameStats.SaveCollection["playerActualY"] = SaveGameStats.playerNextY;
                    Properties.SetMatrix((int)(SaveGameStats.playerActualX / 13), (int)(SaveGameStats.playerActualY / 9));
                    animations.AnimatedMoveDraw(player.arrayOfModelsOfPlayer, SaveGameStats.playerActualX, SaveGameStats.playerActualY, playerInfo.IsMoving(), 10f, SaveGameStats.dirOfMove, ConsoleColor.DarkGreen);
                }
                else
                {
                    ObjectForPropertiesAct.PropertiesActivation1(Properties.matrix2[(int)(SaveGameStats.playerNextY / Textures.Player.movingModelOfPlayerL1.GetLength(0)), (int)(SaveGameStats.playerNextX / Textures.Player.movingModelOfPlayerL1.GetLength(1))]);
                }
            }

        }
        public static void RunField(Render render, int num)
        {
            Properties.matrix2 = Properties.BuildMatrix(render.FieldCollection[SaveGameStats.numberOfField]);
            Render.Draw(render.FieldCollection[SaveGameStats.numberOfField]);
        }
        public void StartScreen()
        {
            Console.SetBufferSize(1900, 600);
            Console.SetWindowSize(1900, 500);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            DialogWindow.DialogEngine.DialogueText("welcome to", 280, 53, 0, ConsoleColor.DarkGreen);
            DialogWindow.DialogEngine.DialogueText("lost soul!", 280, 60, 0, ConsoleColor.DarkGreen);
            DialogWindow.DialogEngine.DialogueText("1)start game", 180, 85, 0, ConsoleColor.Green);
            DialogWindow.DialogEngine.DialogueText("2)load game", 280, 85, 0, ConsoleColor.DarkYellow);
            DialogWindow.DialogEngine.DialogueText("3)exit", 385, 85, 0, ConsoleColor.DarkRed);

            Console.SetCursorPosition(427, 85);
            Console.Write("(BAD IDEA)");
            Console.CursorVisible = false;
            ConsoleKey consoleKey = Console.ReadKey(true).Key;
            while (consoleKey != ConsoleKey.D1 && consoleKey != ConsoleKey.D2 && consoleKey != ConsoleKey.D3)
            {
                consoleKey = Console.ReadKey(true).Key;
            }
            if (consoleKey == ConsoleKey.D1)
            {
                RunGame();

            }
            else if (consoleKey == ConsoleKey.D2)
            {
                Console.Clear();
                SaveGameStats saveGameStats = new SaveGameStats();
                saveGameStats.SavesWindow();
                int choose = (int)Console.ReadKey().Key;
                saveGameStats.Load(saveGameStats.listOfFiles[choose - 48]);
                //SavesWindow();

            }
            else if (consoleKey == ConsoleKey.D3)
            {
                return;
            }
        }
        public void RunGame()
        {
            Render render = new Render();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetBufferSize(1900, 600);
            Console.SetWindowSize(1900, 500);
            Console.Clear();
            SaveGameStats saveGameStats = new SaveGameStats();

            Player1 info = new Player1((int)SaveGameStats.SaveCollection["healthPoints"]);
            Task.Run(() =>
            {
                RunField(render, SaveGameStats.numberOfField);
            });

            Task.Run(() =>
            {

                Thread.Sleep(2500);
                Info info = new Info();
                HUD.Show_HUD(HUD.HUD_Visual.field_HUD);

            });
            while (true)
            {
                Thread.Sleep(2500);
                Moving(saveGameStats);
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
                    if ((array == Textures.Trees.tree21 || array == Textures.Trees.tree22) && i > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(array[i, j]);
                    }
                    else
                    {
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(array[i, j]);
                    }

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

    }

    internal class Program
    {
        static void Main(string[] args)
        {

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
            Engine engine = new Engine();
            Console.CursorVisible = false;
            engine.StartScreen();

        }
    }
}