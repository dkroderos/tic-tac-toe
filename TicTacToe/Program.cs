using System;

namespace TicTacToe
{
    class Program
    {

        private static int[] player_O = new int[9]; // Coordinates occupied by the player O

        private static int[] player_X = new int[9]; // Coordinates occupied by the player X


        // Tic Tac Toe Drawing
        private static char[,] ticTacToe = {
            { ' ', '|', ' ', '|', ' ' },
            { '-', '-', '-', '-', '-' },
            { ' ', '|', ' ', '|', ' ' },
            { '-', '-', '-', '-', '-' },
            { ' ', '|', ' ', '|', ' ' }
        }; 

        static void Main(string[] args)
        {
            int turn = 0;

        }

        private static void PrintTicTacToe(char[,] ticTacToe)
        {
            // Prints the Tic Tac Toe
            for (int i = 0; i < ticTacToe.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToe.GetLength(1); j++)
                {
                    Console.Write(ticTacToe[i, j]);
                }
            }
            Console.WriteLine();
        }

        private static bool IsCoordinatesOccupiedByPlayer(int[] playerCoords, params int[] sequence)
        {
            // Checks if a player has created a line
            int currentIndex = 0;

            foreach (int coordinate in playerCoords)
            {
                if (currentIndex == sequence.Length) return true;
                if (sequence[currentIndex] == coordinate) currentIndex++;
            }

            return currentIndex == sequence.Length;
        }
    }
}
