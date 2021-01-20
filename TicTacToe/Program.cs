using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {

        private static int[] player_O = new int[9]; // Coordinates occupied by the player O

        private static int[] player_X = new int[9]; // Coordinates occupied by the player X
        
        private static int input;

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
            for (int turn = 0; turn < 9; turn++) 
            {
                if (turn % 2 == 1) // Making sure that players are switching turns 
                {
                    Console.Write("Circle's Turn: ");
                    input = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.Write("X's Turn: ");
                    input = int.Parse(Console.ReadLine());
                }
            }
        }

        static void PlayersTurn(int[] player, int number)
        {

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

        private static bool PlayerHasWon(int[] player)
        {
            // Checks if a player as won
            if (HasWonHorizontally(player) ||
                HasWonVertically(player) ||
                HasWonDiagonally(player))
            {
                return true;
            }

            else return false;
        }

        private static bool HasWonHorizontally(int[] player)
        {
            // Checks if a player won horizontally
            if (IsCoordinatesOccupiedByPlayer(player, 1, 2, 3) || 
                IsCoordinatesOccupiedByPlayer(player, 4, 5, 6) ||
                IsCoordinatesOccupiedByPlayer(player, 7, 8, 9))
            {
                return true;
            }

            else return false;
        }

        private static bool HasWonVertically(int[] player)
        {
            // Checks if a player won vertically
            if (IsCoordinatesOccupiedByPlayer(player, 1, 4, 7) ||
                IsCoordinatesOccupiedByPlayer(player, 2, 5, 8) ||
                IsCoordinatesOccupiedByPlayer(player, 3, 6, 9))
            {
                return true;
            }

            else return false;
        }

        private static bool HasWonDiagonally(int[] player)
        {
            // Checks if a player won diagonally
            if (IsCoordinatesOccupiedByPlayer(player, 1, 5, 9) ||
                IsCoordinatesOccupiedByPlayer(player, 3, 5, 7))
            {
                return true;
            }

            else return false;
        }
    }
}
