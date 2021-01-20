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

        private static  Dictionary<int, char> spaceLocations;

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
            spaceLocations = CreateSpaceLocations();

            for (int turn = 0; turn < 9; turn++) 
            {
                if (turn % 2 == 1) // Making sure that players are switching turns 
                {
                    PrintTicTacToe(ticTacToe);
                    Console.Write("Circle's Turn: ");
                    PlayersTurn(player_O, input, spaceLocations, 'O');
                    if (PlayerHasWon(player_O))
                    {
                        Console.WriteLine("X has won.");
                        return;
                    }
                }
                else
                {
                    PrintTicTacToe(ticTacToe);
                    Console.Write("X's Turn: ");
                    PlayersTurn(player_X, input, spaceLocations, 'X');
                    if (PlayerHasWon(player_X))
                    {
                        Console.WriteLine("X has won.");
                        return;
                    }
                }
            }
        }

        static void PlayersTurn(int[] player, int input, Dictionary<int, char> spaceLocations, char symbol) // Player is making a turn
        {
            input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 9)
            {
                Console.Write("Please enter a number in range 1 - 9: ");
                PlayersTurn(player, input, spaceLocations, symbol);
            }
            if (spaceLocations[input] != ' ')
            {
                Console.Write("The coordinate is already occupied: ");
                PlayersTurn(player, input, spaceLocations, symbol);
            }
            else
            {
                player[input - 1] = input;
                spaceLocations[input] = symbol;
            }
        }

        static Dictionary<int, char> CreateSpaceLocations() // Make a dictionary to easily change the Tic Tac Toe board
        {
            Dictionary<int, char> spaceLocations = new Dictionary<int, char>();
            spaceLocations[1] = ticTacToe[0, 0];
            spaceLocations[2] = ticTacToe[0, 2];
            spaceLocations[3] = ticTacToe[0, 4];
            spaceLocations[4] = ticTacToe[2, 0];
            spaceLocations[5] = ticTacToe[2, 2];
            spaceLocations[6] = ticTacToe[2, 4];
            spaceLocations[7] = ticTacToe[4, 0];
            spaceLocations[8] = ticTacToe[4, 2];
            spaceLocations[9] = ticTacToe[4, 4];

            return spaceLocations;
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
                Console.WriteLine();
            }
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
