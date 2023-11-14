using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstPlayableLauralynnTrainor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayMap(2);
            Console.ReadKey(true);
        }
        static void DisplayMap(int s)
        {
            //DisplayBorderTop(s);
            for (int x = 0; x < map.GetLength(0); x++)
            {

                for (int p = 0; p < s; p++)
                {
                    //Console.Write(borderVertical);
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        for (int z = 0; z < s; z++)
                        {
                            if (map[x, y] == '`')
                            {
                                ColorChange(ConsoleColor.Black, ConsoleColor.White);
                                Console.Write("`");
                            }
                            else if (map[x, y] == '~')
                            {
                                ColorChange(ConsoleColor.White, ConsoleColor.Black);
                                Console.Write("~");
                            }
                            else if (map[x, y] == '>')
                            {
                                ColorChange(ConsoleColor.Gray, ConsoleColor.Black);
                                Console.Write(">");
                            }
                            else if (map[x, y] == '!')
                            {
                                ColorChange(ConsoleColor.DarkGray, ConsoleColor.White);
                                Console.Write("!");
                            }
                            else if (map[x, y] == '?')
                            {
                                ColorChange(ConsoleColor.DarkYellow, ConsoleColor.Black);
                                Console.Write("?");
                            }
                        }
                    }
                    ColorChange(ConsoleColor.Black, ConsoleColor.White);
                    //Console.Write(borderVertical);
                    Console.Write("\n");
                }

            }
            //DisplayBorderBottom(s);
            Console.WriteLine("DisplayMap(" + s + ")");
            //DisplayLegend();
        }
        static void ColorChange(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        static char[,] map = new char[,] // dimensions defined by following data:
    {
            {'`','~','`','~','`','~','`','~','`','~','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?'},
            {'~','`','~','`','~','`','~','`','~','`','!','!','?','?','?','?','?','?','?','?','?','?','?','!','?','?','?','?','?','?'},
            {'`','~','`','~','`','~','`','~','`','~','>','?','?','?','?','?','?','?','?','?','?','?','?','>','?','?','?','?','?','?'},
            {'!','!','!','!','!','!','!','!','~','`','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','!','!','!','!','!'},
            {'?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','~','`','~','`','~'},
            {'?','?','?','?','?','?','!','!','~','`','!','!','?','?','?','?','?','!','?','?','?','?','?','!','!','`','~','`','~','`'},
            {'?','?','?','?','?','?','!','!','`','~','!','!','?','?','?','?','?','!','!','!','!','!','!','!','!','~','`','~','`','~'},
            {'!','!','!','!','!','!','!','!','~','`','!','!','!','!','!','!','!','!','~','`','~','`','~','`','~','`','~','`','~','`'},
            {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
            {'~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`'},
            {'`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~'},
            {'~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`','~','`'},
           };
    }
    /*legend
    ` = black
    ~ = white
    ! = darkgray
    ? = darkyellow
    > = gray
    */
}
