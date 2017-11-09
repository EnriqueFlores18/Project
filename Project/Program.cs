using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Project
{
    class Program
    {
        private struct SpelerInfo
        {
            public String SpelerNaam;
            public char SpelerID;
        };


        static void Main(string[] args)
        {

            bool applicatieActief = true;
            do
            {
                //int keuze = 0;
                //string letterKeuze = Console.ReadKey().KeyChar.ToString();
                try
                {

                    Program.Menu();

                    //keuze = Convert.ToInt32(letterKeuze);
                    ConsoleKey ck = Console.ReadKey().Key;
                    switch (ck)
                    {
                        case ConsoleKey.NumPad1:
                            Console.WriteLine("\bKeuze 1: geselecteerd");
                            Spel1();
                            break;
                        case ConsoleKey.NumPad2:
                            Console.WriteLine("\bKezue 2: geselecteerd");
                            Spel2();

                            break;
                        case ConsoleKey.NumPad3:

                            break;
                        case ConsoleKey.D0:
                            Console.WriteLine("\b ");
                            applicatieActief = false;
                            break;

                        case ConsoleKey.Escape:


                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);

                }
                Thread.Sleep(500);


            } while (applicatieActief);
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine(" |  \\/  |                  ");
            Console.WriteLine(" | \\  / | ___ _ __  _   _  ");
            Console.WriteLine(" | |\\/| |/ _ \\ '_ \\| | | ");
            Console.WriteLine(" | |  | |  __/ | | | |_| |  ");
            Console.WriteLine(" |_|  |_|\\___|_| |_|\\__,_|");



            Console.WriteLine();
            Console.WriteLine("#####################################");
            Console.WriteLine("# Kies uit 1 van de volgende spelen #");
            Console.WriteLine("# Spel 1 = Vier op een rij          #");
            Console.WriteLine("# Spel 2 = Boter kaas en eieren     #");
            Console.WriteLine("# Spel 3 = Snake                    #");
            Console.WriteLine("#####################################");

        }

        public static void Spel1()
        {

            Console.Clear();
            SpelerInfo SpelerEen = new SpelerInfo();
            SpelerInfo SpelerTwee = new SpelerInfo();
            char[,] Bord = new char[9, 10];
            int DropKeuze, win, vol, opnieuw;

            Console.WriteLine("###########################");
            Console.WriteLine("# Vier op een rij Spelen! #");
            Console.WriteLine("###########################");
            Console.WriteLine();
            Console.WriteLine("# Speler een geef je naam: #");
            SpelerEen.SpelerNaam = Console.ReadLine();
            SpelerEen.SpelerID = 'X';
            Console.Clear();
            Console.WriteLine("###########################");
            Console.WriteLine("# Vier op een rij Spelen! #");
            Console.WriteLine("###########################");
            Console.WriteLine();
            Console.WriteLine("# Speler twee geef je naam: #");
            SpelerTwee.SpelerNaam = Console.ReadLine();
            SpelerTwee.SpelerID = 'O';
            Console.Clear();

            vol = 0;
            win = 0;
            opnieuw = 0;
            GeefSpeelbordAan(Bord);
            do
            {
                DropKeuze = SpelerDrop(Bord, SpelerEen);
                CheckOnder(Bord, SpelerEen, DropKeuze);
                GeefSpeelbordAan(Bord);
                win = CheckVoorVierOpeenRij(Bord, SpelerEen);
                if (win == 1)
                {
                    SpelerWint(SpelerEen);
                    opnieuw = restart(Bord);
                    if (opnieuw == 2)
                    {
                        break;
                    }
                }

                DropKeuze = SpelerDrop(Bord, SpelerTwee);
                CheckOnder(Bord, SpelerTwee, DropKeuze);
                GeefSpeelbordAan(Bord);
                win = CheckVoorVierOpeenRij(Bord, SpelerTwee);
                if (win == 1)
                {
                    SpelerWint(SpelerTwee);
                    opnieuw = restart(Bord);
                    if (opnieuw == 2)
                    {
                        break;
                    }
                }
                vol = VolSpeelbord(Bord);
                if (vol == 7)
                {
                    Console.WriteLine("Het bord is vol, Het is een gelijkspel!");
                    opnieuw = restart(Bord);
                }

            } while (opnieuw != 2);
        }
        static int SpelerDrop(char[,] SpeelBord, SpelerInfo HudigeSpeler)
        {
            int DropKeuze;

            Console.WriteLine(HudigeSpeler.SpelerNaam + "'s Beurt ");
            do
            {
                Console.WriteLine("Selecteer een nummer tussen 1 en 7: ");
                DropKeuze = Convert.ToInt32(Console.ReadLine());
            } while (DropKeuze < 1 || DropKeuze > 7);

            while (SpeelBord[1, DropKeuze] == 'X' || SpeelBord[1, DropKeuze] == 'O')
            {
                Console.WriteLine("Dat rij is vol, Voeg AUB een nieuwe rij in: ");
                DropKeuze = Convert.ToInt32(Console.ReadLine());
            }

            return DropKeuze;
        }

        static void CheckOnder(char[,] SpeelBord, SpelerInfo HudigeSpeler, int dropKeuze)
        {
            int length, turn;
            length = 6;
            turn = 0;

            do
            {
                if (SpeelBord[length, dropKeuze] != 'X' && SpeelBord[length, dropKeuze] != 'O')
                {
                    SpeelBord[length, dropKeuze] = HudigeSpeler.SpelerID;
                    turn = 1;
                }
                else
                    --length;
            } while (turn != 1);


        }

        static void GeefSpeelbordAan(char[,] SpeelBord)
        {
            int rows = 6, columns = 7, i, ix;

            for (i = 1; i <= rows; i++)
            {
                Console.Write("|");
                for (ix = 1; ix <= columns; ix++)
                {
                    if (SpeelBord[i, ix] != 'X' && SpeelBord[i, ix] != 'O')
                        SpeelBord[i, ix] = '*';

                    Console.Write(SpeelBord[i, ix]);

                }

                Console.Write("| \n");
            }

        }

        static int CheckVoorVierOpeenRij(char[,] SpeelBord, SpelerInfo HudigeSpeler)
        {
            char XO;
            int win;

            XO = HudigeSpeler.SpelerID;
            win = 0;

            for (int i = 8; i >= 1; --i)
            {

                for (int ix = 9; ix >= 1; --ix)
                {

                    if (SpeelBord[i, ix] == XO &&
                        SpeelBord[i - 1, ix - 1] == XO &&
                        SpeelBord[i - 2, ix - 2] == XO &&
                        SpeelBord[i - 3, ix - 3] == XO)
                    {
                        win = 1;
                    }


                    if (SpeelBord[i, ix] == XO &&
                        SpeelBord[i, ix - 1] == XO &&
                        SpeelBord[i, ix - 2] == XO &&
                        SpeelBord[i, ix - 3] == XO)
                    {
                        win = 1;
                    }

                    if (SpeelBord[i, ix] == XO &&
                        SpeelBord[i - 1, ix] == XO &&
                        SpeelBord[i - 2, ix] == XO &&
                        SpeelBord[i - 3, ix] == XO)
                    {
                        win = 1;
                    }

                    if (SpeelBord[i, ix] == XO &&
                        SpeelBord[i - 1, ix + 1] == XO &&
                        SpeelBord[i - 2, ix + 2] == XO &&
                        SpeelBord[i - 3, ix + 3] == XO)
                    {
                        win = 1;
                    }

                    if (SpeelBord[i, ix] == XO &&
                         SpeelBord[i, ix + 1] == XO &&
                         SpeelBord[i, ix + 2] == XO &&
                         SpeelBord[i, ix + 3] == XO)
                    {
                        win = 1;
                    }
                }

            }

            return win;
        }

        static int VolSpeelbord(char[,] SpeelBord)
        {
            int full;
            full = 0;
            for (int i = 1; i <= 7; ++i)
            {
                if (SpeelBord[1, i] != '*')
                    ++full;
            }

            return full;
        }

        static void SpelerWint(SpelerInfo activePlayer)
        {
            Console.WriteLine(activePlayer.SpelerNaam + " Connected Four, You Win!");
        }

        static int restart(char[,] Speelbord)
        {
            int restart;

            Console.WriteLine("Wil je opnieuw spelen? Ja(1) Nee(2): ");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                for (int i = 1; i <= 6; i++)
                {
                    for (int ix = 1; ix <= 7; ix++)
                    {
                        Speelbord[i, ix] = '*';
                    }
                }
            }
            else
                Console.WriteLine("Tot Ziens!");
            return restart;
        }







        

        public static void Spel2()
        {
            Console.Clear();
            
              string[] positie = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Array 

             void DrawBoard() // Speel board 
            {


                Console.WriteLine("   {0}  $  {1}  $  {2}   ", positie[1], positie[2], positie[3]);
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine("   {0}  $  {1}  $  {2}   ", positie[4], positie[5], positie[6]);
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine("   {0}  $  {1}  $  {2}   ", positie[7], positie[8], positie[9]);


            }

             
            {
                string speler1 = "", speler2 = "";
                int keuzen = 0, turn = 1, score1 = 0, score2 = 0;
                bool winFlag = false, spelen = true, juistenInput = false;

                Console.WriteLine("Welkom dit is Boter Kaas En Eieren");
                Console.WriteLine("Naam van speler 1?");
                speler1 = Console.ReadLine();
                Console.WriteLine("Naam van speler 2?");
                speler2 = Console.ReadLine();
                Console.WriteLine("Okay goed. {0} is O en {1} is X.", speler1, speler2);
                Console.WriteLine("{0} gaat eerst.", speler1);
                Console.ReadLine();
                Console.Clear();

                while (spelen == true)
                {
                    while (winFlag == false) // Game loop 
                    {
                        DrawBoard();
                        Console.WriteLine("");

                        Console.WriteLine("Score: {0} - {1}     {2} - {3}", speler1, score1, speler2, score2);
                        if (turn == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("{0}'s (O) beurt", speler1);
                        }
                        if (turn == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("{0}'s (X) beurt", speler2);
                        }

                        while (juistenInput == false)
                        {
                            Console.WriteLine("Welke positie zou je graag willen?");
                            keuzen = int.Parse(Console.ReadLine());
                            if (keuzen > 0 && keuzen < 10)
                            {
                                juistenInput = true;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        juistenInput = false; // Reset

                        if (turn == 1)
                        {
                            if (positie[keuzen] == "X") // kijken of de plek bezet is
                            {
                                Console.WriteLine("Helaas deze positie is al bezet! ");
                                Console.Write("Probeer het overnieuw.");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                positie[keuzen] = "O";
                            }
                        }
                        if (turn == 2)
                        {
                            if (positie[keuzen] == "O") // kijken of de plek bezet is
                            {
                                Console.WriteLine("Helaas deze plaats is al bezet! ");
                                Console.Write("Probeer het overnieuw.");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                positie[keuzen] = "X";
                            }
                        }

                        winFlag = CheckWin();

                        if (winFlag == false)
                        {
                            if (turn == 1)
                            {
                                turn = 2;
                            }
                            else if (turn == 2)
                            {
                                turn = 1;
                            }
                            Console.Clear();
                        }
                    }

                    Console.Clear();

                    DrawBoard();

                    for (int i = 1; i < 10; i++) // Resets het spel
                    {
                        positie[i] = i.ToString();
                    }

                    if (winFlag == false) // als niemand wint
                    {
                        Console.WriteLine("It's a draw!");
                        Console.WriteLine("Score: {0} - {1}     {2} - {3}", speler1, score1, speler2, score2);
                        Console.WriteLine("");
                        Console.WriteLine("Wat zou je nu graag willen doen?");
                        Console.WriteLine("1. opnieuw spelen");
                        Console.WriteLine("2. spel sluiten");
                        Console.WriteLine("");

                        while (juistenInput == false)
                        {
                            Console.WriteLine("Geef je positie: ");
                            keuzen = int.Parse(Console.ReadLine());

                            if (keuzen > 0 && keuzen < 3)
                            {
                                juistenInput = true;
                            }
                        }

                        juistenInput = false; // Reset 

                        switch (keuzen)
                        {
                            case 1:
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Bedankt voor spelen!");
                                Console.ReadLine();
                                spelen = false;
                                break;
                        }
                    }

                    if (winFlag == true) // als iemand wint
                    {
                        if (turn == 1)
                        {
                            score1++;
                            Console.WriteLine("{0} wint!", speler1);
                            Console.WriteLine("Wat zou je nu graag willen doen?");
                            Console.WriteLine("1. Opnieuw spelen");
                            Console.WriteLine("2. Spel verlaten");

                            while (juistenInput == false)
                            {
                                Console.WriteLine("Geef je positie: ");
                                keuzen = int.Parse(Console.ReadLine());

                                if (keuzen > 0 && keuzen < 3)
                                {
                                    juistenInput = true;
                                }
                            }

                            juistenInput = false; // Reset 

                            switch (keuzen)
                            {
                                case 1:
                                    Console.Clear();
                                    winFlag = false;
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Bedankt voor spelen!");
                                    Console.ReadLine();
                                    spelen = false;
                                    break;
                            }
                        }

                        if (turn == 2)
                        {
                            score2++;
                            Console.WriteLine("{0} wint!", speler2);
                            Console.WriteLine("Wat zou je nu graag willen doen?");
                            Console.WriteLine("1. Opnieuw spelen");
                            Console.WriteLine("2. Spel verlaten");

                            while (juistenInput == false)
                            {
                                Console.WriteLine("Geef je positie: ");
                                keuzen = int.Parse(Console.ReadLine());

                                if (keuzen > 0 && keuzen < 3)
                                {
                                    juistenInput = true;
                                }
                            }

                            juistenInput = false; // Reset 

                            switch (keuzen)
                            {
                                case 1:
                                    Console.Clear();
                                    winFlag = false;
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Bedankt voor spelen!");
                                    Console.ReadLine();
                                    spelen = false;
                                    break;
                            }
                        }
                    }
                }
            }


            

              bool CheckWin() // Win controlen
            {
                if (positie[1] == "O" && positie[2] == "O" && positie[3] == "O") // Horizontaal
                {
                    return true;
                }
                else if (positie[4] == "O" && positie[5] == "O" && positie[6] == "O")
                {
                    return true;
                }
                else if (positie[7] == "O" && positie[8] == "O" && positie[9] == "O")
                {
                    return true;
                }

                else if (positie[1] == "O" && positie[5] == "O" && positie[9] == "O") // Diagonaal 
                {
                    return true;
                }
                else if (positie[7] == "O" && positie[5] == "O" && positie[3] == "O")
                {
                    return true;
                }

                else if (positie[1] == "O" && positie[4] == "O" && positie[7] == "O")// Coloumns 
                {
                    return true;
                }
                else if (positie[2] == "O" && positie[5] == "O" && positie[8] == "O")
                {
                    return true;
                }
                else if (positie[3] == "O" && positie[6] == "O" && positie[9] == "O")
                {
                    return true;
                }

                if (positie[1] == "X" && positie[2] == "X" && positie[3] == "X") // Horizontaal 
                {
                    return true;
                }
                else if (positie[4] == "X" && positie[5] == "X" && positie[6] == "X")
                {
                    return true;
                }
                else if (positie[7] == "X" && positie[8] == "X" && positie[9] == "X")
                {
                    return true;
                }

                else if (positie[1] == "X" && positie[5] == "X" && positie[9] == "X") // Diagonaal 
                {
                    return true;
                }
                else if (positie[7] == "X" && positie[5] == "X" && positie[3] == "X")
                {
                    return true;
                }

                else if (positie[1] == "X" && positie[4] == "X" && positie[7] == "X") // Coloumns 
                {
                    return true;
                }
                else if (positie[2] == "X" && positie[5] == "X" && positie[8] == "X")
                {
                    return true;
                }
                else if (positie[3] == "X" && positie[6] == "X" && positie[9] == "X")
                {
                    return true;
                }
                else //geen winnaar
                {
                    return false;
                }


                public static void spel3()
                {
                    Console.Clear();
                }
            }
        }
    }
}













    






    


