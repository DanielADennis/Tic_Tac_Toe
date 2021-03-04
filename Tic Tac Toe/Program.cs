using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        private static string A = " ", B = " ", C = " ", D = " ", E = " ", F = " ", G = " ", H = "", I = " ";
        private static string turn = "O";

        //code 0: not gameover, 1:winner, 2:tie
        private static int gameover = 0;

        //Prints the cuurrent board and checks for a winner
        public static void Print_board()
        {
            Console.Clear();
            string line0 = "      GAME      KEY";
            string line1 = "     _____     _____\n";
            string line2 = "     "+A + "|" + B + "|" + C + "     A|B|C";
            string line3 = "     "+D + "|" + E + "|" + F + "     D|E|F";
            string line4 = "     "+G + "|" + H + "|" + I + "     G|H|I";

            Console.WriteLine(line0);
            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.WriteLine(line4);

            IsGameOver();
        }
        
        //Has the player make a selection
        public static void Take_pick()
        {
            Change_Turn();
            Console.WriteLine("\nIt is now Player " + turn + "'s turn:");
            Console.Write("Make a selection: ");
            string pick = Console.ReadLine().ToUpper();

            if (String.Equals(pick, "A")) { A = turn; }
            else if (String.Equals(pick, "B")) { B = turn; }
            else if (String.Equals(pick, "C")) { C = turn; }
            else if (String.Equals(pick, "D")) { D = turn; }
            else if (String.Equals(pick, "E")) { E = turn; }
            else if (String.Equals(pick, "F")) { F = turn; }
            else if (String.Equals(pick, "G")) { G = turn; }
            else if (String.Equals(pick, "H")) { H = turn; }
            else if (String.Equals(pick, "I")) { I = turn; }
            else
            {
                Console.Write("Incorrect Choice! Make another selection: ");
                pick = Console.ReadLine().ToUpper();
            }

        }
        public static void Change_Turn()
        {
            if (String.Equals(turn,"X")) { turn = "O"; }
            else { turn = "X"; }
        }

        //Starts a new clear game, resets the variables, Tells X to start.
        public static void New_Game()
        {
            gameover = 0;
            A = " "; B = " "; C = " "; D = " "; E = " "; F = " "; G = " "; H = " "; I = " ";
            Console.Clear();
            Print_board();
        }

        //Checks if the game has ended and updates gameover to true, which will end the while loop in the main method.
        public static void IsGameOver()
        {
            //compares 3 strings and returns true if they are all equal (except if they are all blank)
            static bool AreEqual(string a, string b, string c)
            {
                bool not_equal = false;
                if (String.Equals(a, " ") || String.Equals(b, " ") || String.Equals(c, " ")) { return not_equal; }
                else if (String.Equals(a, b)){ return String.Equals(b, c);}
                else { return not_equal; }     
            }

            //Checks for a winning sequence
            if (AreEqual(A,B,C) || AreEqual(D,E,F) || AreEqual(G,H,I) || AreEqual(A,E,I) || AreEqual(G,E,C) || AreEqual(A,D,G) || AreEqual(B,E,H) || AreEqual(C,F,I))
            {
                gameover = 1;
            }

            //checks for a draw
            else if (!String.Equals(A," ") && !String.Equals(B, " ") && !String.Equals(C, " ") && !String.Equals(D, " ") && !String.Equals(E, " ") && !String.Equals(F, " ") && !String.Equals(G, " ") && !String.Equals(H, " ") && !String.Equals(I, " "))
            {
                gameover = 2;
            }
        }



        static void Main(string[] args)
        {
            New_Game();
            while (gameover == 0)
            {
                Take_pick();
                Print_board();
            }

            if (gameover == 1)
            {
                Console.WriteLine("Player " + turn + "is the Winner!");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("It was a Draw.");
                Console.ReadLine();
            }

        }
    }
}
