using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool applicatieActief = true;
            while (applicatieActief)
            {


                Console.WriteLine(" |  \\/  |                  ");
                Console.WriteLine(" | \\  / | ___ _ __  _   _  ");
                Console.WriteLine(" | |\\/| |/ _ \\ '_ \\| | | ");
                Console.WriteLine(" | |  | |  __/ | | | |_| |  ");
                Console.WriteLine(" |_|  |_|\\___|_| |_|\\__,_|");



                Console.WriteLine();
                Console.WriteLine("#####################################");
                Console.WriteLine("# Kies uit 1 van de volgende spelen #");
                Console.WriteLine("# Spel 1 = Vier op een rij          #");
                Console.WriteLine("# Spel 2 =                          #");
                Console.WriteLine("# Spel 3                            #");
                Console.WriteLine("#####################################");
                int keuze = 0;
                string letterKeuze = Console.ReadKey().KeyChar.ToString();
                try
                {
                    keuze = Convert.ToInt32(letterKeuze);
                    switch (keuze)
                    {
                        case 1:
                            Console.WriteLine("\bKeuze 1: geselecteerd");
                            Spel1();
                            break;
                        case 2:
                            Console.WriteLine("\bKezue 2: geselecteerd");

                            break;
                        case 3:

                            break;
                        case 0:
                            applicatieActief = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(3000);
            }
        }

        private static void Spel1()
        {

            Console.Clear();
            int[,] SpeelBord = new int[7, 7];
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t\t\t\t 1 2 3 4 5 6 7\n");
            Console.ForegroundColor = ConsoleColor.White;
            string tabbing = "\t\t\t\t ";
            for (int r = 0; r < 7; r++)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(tabbing);
                for (int c = 0; c < 7; c++)
                {
                    Console.Write(0);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\n\t\t   Kies de rij waar je je disc wilt hebben : ");
            Console.WriteLine();
            Console.WriteLine("\n\n\t\t     Druk op Esc om terug te gaan naar de Menu :) ");
            Console.ForegroundColor = ConsoleColor.White;
        again:
            switch (Console.ReadKey(true).KeyChar.ToString())
            {
                case "1":
                    Console.Write("1");
                    if (SpeelBord[0, 0] < 7) SpeelBord[0, 0]++;
                    Console.SetCursorPosition(33, 11 - SpeelBord[0, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "2":
                    Console.Write("2");
                    if (SpeelBord[1, 0] < 7) SpeelBord[1, 0]++;
                    Console.SetCursorPosition(35, 11 - SpeelBord[1, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "3":
                    Console.Write("3");
                    if (SpeelBord[2, 0] < 7) SpeelBord[2, 0]++;
                    Console.SetCursorPosition(37, 11 - SpeelBord[2, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "4":
                    Console.Write("4");
                    if (SpeelBord[3, 0] < 7) SpeelBord[3, 0]++;
                    Console.SetCursorPosition(39, 11 - SpeelBord[3, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "5":
                    Console.Write("5");
                    if (SpeelBord[4, 0] < 7) SpeelBord[4, 0]++;
                    Console.SetCursorPosition(41, 11 - SpeelBord[4, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "6":
                    Console.Write("6");
                    if (SpeelBord[5, 0] < 7) SpeelBord[5, 0]++;
                    Console.SetCursorPosition(43, 11 - SpeelBord[5, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "7":
                    Console.Write("7");
                    if (SpeelBord[6, 0] < 7) SpeelBord[6, 0]++;
                    Console.SetCursorPosition(45, 11 - SpeelBord[6, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                default:
                    goto again;
            }

        }
    }
}


    


