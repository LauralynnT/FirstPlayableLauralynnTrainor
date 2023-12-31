﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;

namespace FirstPlayableLauralynnTrainor
{
    internal class Program
    {
        static Encoding asciiEncoder = Encoding.GetEncoding("IBM437");
        static string borderHorizontal = ($"{asciiEncoder.GetString(new byte[1] { 205 })}");
        static string borderVertical = ($"{asciiEncoder.GetString(new byte[1] { 186 })}");
        static string borderTL = ($"{asciiEncoder.GetString(new byte[1] { 214 })}");
        static string borderTR = ($"{asciiEncoder.GetString(new byte[1] { 184 })}");
        static string borderBL = ($"{asciiEncoder.GetString(new byte[1] { 212 })}");
        static string borderBR = ($"{asciiEncoder.GetString(new byte[1] { 189 })}");
        static string topHalf = ($"{asciiEncoder.GetString(new byte[1] { 223 })}");
        static string botHalf = ($"{asciiEncoder.GetString(new byte[1] { 220 })}");
        static string roadLine = ($"{asciiEncoder.GetString(new byte[1] { 179 })}");
        static string flower = ($"{asciiEncoder.GetString(new byte[1] { 145 })}");
        static string grass = ($"{asciiEncoder.GetString(new byte[1] { 176 })}");
        static string solid = ($"{asciiEncoder.GetString(new byte[1] { 221 })}");
        static char health = Convert.ToChar(3);
        static string tile = @"Map.txt";
        static string[] map;
        

        static void Main(string[] args)
        {
            map = File.ReadAllLines(tile);
            DisplayMap();
            Console.ReadKey(true);
        }
        static void DisplayMap()
        {
            DisplayBorderTop();
            for (int x = 0; x < map.Length; x++)
            {
                string mapRow = map[x];
                Console.Write(borderVertical);
                for (int y = 0; y < mapRow.Length; y++)
                {
                    if (map[x][y] == '`')
                    {
                        ColorChange(ConsoleColor.Black, ConsoleColor.White);
                        Console.Write(topHalf);
                    }
                    else if (map[x][y] == '~')
                    {
                        ColorChange(ConsoleColor.Black, ConsoleColor.White);
                        Console.Write(botHalf);
                    }
                    else if (map[x][y] == '>')
                    {
                        ColorChange(ConsoleColor.Gray, ConsoleColor.Gray);
                        Console.Write(solid);
                    }
                    else if (map[x][y] == '!')
                    {
                        ColorChange(ConsoleColor.DarkGray, ConsoleColor.DarkGray);
                        Console.Write(solid);
                    }
                    else if (map[x][y] == '?')
                    {
                        ColorChange(ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);
                        Console.Write(solid);
                    }
                    else if (map[x][y] == '^')
                    {
                        ColorChange(ConsoleColor.DarkYellow, ConsoleColor.Red);
                        Console.Write(topHalf);
                    }
                    else if (map[x][y] == '*')
                    {
                        ColorChange(ConsoleColor.DarkGray, ConsoleColor.Red);
                        Console.Write(botHalf);
                    }
                    else if (map[x][y] == '#')
                    {
                        ColorChange(ConsoleColor.DarkGreen, ConsoleColor.Green);
                        Console.Write(grass);
                    }
                    else if (map[x][y] == '<')
                    {
                        ColorChange(ConsoleColor.DarkGray, ConsoleColor.DarkYellow);
                        Console.Write(botHalf);
                    }
                    else if (map[x][y] == '@')
                    {
                        ColorChange(ConsoleColor.Gray, ConsoleColor.Black);
                        Console.Write(topHalf);
                    }
                    else if (map[x][y] == '$')
                    {
                        ColorChange(ConsoleColor.Gray, ConsoleColor.White);
                        Console.Write(topHalf);
                    }
                    else if (map[x][y] == 'r')
                    {
                        ColorChange(ConsoleColor.Black, ConsoleColor.Black);
                        Console.Write(solid);
                    }
                    else if (map[x][y] == 'p')
                    {
                        ColorChange(ConsoleColor.Red, ConsoleColor.Red);
                        Console.Write('p');
                    }
                    else if (map[x][y] == 'b')
                    {
                        ColorChange(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
                        Console.Write('b');
                    }
                    else if (map[x][y] == 'v')
                    {
                        ColorChange(ConsoleColor.Magenta, ConsoleColor.Magenta);
                        Console.Write('v');
                    }
                    else if (map[x][y] == 'l')
                    {
                        ColorChange(ConsoleColor.Blue, ConsoleColor.Blue);
                        Console.Write('l');
                    }
                    else if (map[x][y] == 'i')
                    {
                        ColorChange(ConsoleColor.Black, ConsoleColor.White);
                        Console.Write(roadLine);
                    }
                    else if (map[x][y] == 'f')
                    {
                        ColorChange(ConsoleColor.DarkGreen, ConsoleColor.White);
                        Console.Write(flower);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                ColorChange(ConsoleColor.Black, ConsoleColor.White);
                Console.Write(borderVertical);
                Console.Write("\n");

            }
            DisplayBorderBottom();
            //DisplayLegend();
        }
        
        static void DisplayBorderTop()
        {
            Console.Write(borderTL);
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write(borderHorizontal);
            }
            Console.Write(borderTR);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static void DisplayBorderBottom()
        {
            Console.Write(borderBL);
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write(borderHorizontal);
            }
            Console.Write(borderBR);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static void ColorChange(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        //    static char[,] map = new char[,] // dimensions defined by following data:
        //{
        //        {'`','~','`','~','`','~','`','~','`','~','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?'},
        //        {'`','~','`','~','`','~','`','~','`','~','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?'},
        //        {'`','~','`','~','`','~','`','~','`','~','>','?','?','?','?','?','?','?','?','?','?','?','?','>','?','?','?','?','?','?'},
        //        {'!','!','!','!','!','!','!','!','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','!','!','!','!','!'},
        //        {'?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','~','`','~','`','~'},
        //        {'?','?','?','?','?','?','?','>','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','~','`','~','`','~'},
        //        {'?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','!','!','!','!','!','!','!','~','`','~','`','~'},
        //        {'!','!','!','!','!','!','!','!','`','~','!','!','!','!','!','!','!','!','`','~','`','~','`','~','`','~','`','~','`','~'},
        //        {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
        //        {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
        //        {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
        //        {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
        //       };
        //}
        //    static char[,] map = new char[,] // dimensions defined by following data:
        //    {
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','f','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','f','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','f','#','#','#','#','#','#','#','#','#','#','f','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','!','!','!','!','!','!','!','!','!','#','#','#','#','#','#','#','#','#','#','f','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','?','?','?','?','?','?','?','?','?','?','?','?','?','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','?','?','?','?','!','?','?','?','?','?','?','?','?','?','?','?','?','?','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','!','!','!','!','!','!','!','?','?','?','?','!','?','?','?','?','?','?','!','<','<','*','*','<','<','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','f','#','#','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','f','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?','!','!','#','#','#','#','f','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','>','?','?','?','?','?','?','?','?','?','?','?','?','>','?','?','?','?','?','?','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','!','!','!','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','!','!','!','!','!','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','~','`','~','`','~','!','!','#','#','#','#','#','#','f','#','#','#','#','#','#',},
        //        {'#','#','#','#','f','#','#','#','#','#','#','#','#','!','!','?','?','?','?','?','?','?','>','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','!','!','!','!','!','!','!','~','`','~','`','~','!','!','#','f','#','#','#','#','#','f','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','!','!','!','`','~','!','!','!','!','!','!','!','!','`','~','`','~','`','~','`','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','f','#','#','#','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','f','#','#','#','#','!','!','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','!','!','!','!','!','!','!','!','!','!','!','!','!','!','!','@','$','@','$','!','!','!','!','!','!','!','!','!','!','!','!','!','!','!','#','#','#','#','#','#','#','#','#','#','#','#','#',},
        //        {'#','f','f','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','r','r','r','r','#','#','#','#','#','#','#','r','r','r','r','i','b','b','b','i','p','p','p','i','r','r','r','i','r','r','r','i',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','f','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','r','r','r','r','#','#','#','#','#','#','#','r','r','r','r','i','b','b','b','i','p','p','p','i','r','r','r','i','r','r','r','i',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','r','r','r','r','#','#','#','#','#','#','#','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r','r',},
        //        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','r','r','r','r','#','#','#','#','#','#','#','r','r','r','r','i','l','l','l','i','r','r','r','i','v','v','v','i','r','r','r','i',},
        //           };
        //}

        /*legend
        ` = black
        ~ = white
        ! = darkgray
        ? = darkyellow
        > = gray
        */
    }
}
