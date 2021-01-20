using System;

namespace TicTacToe
{
    class Program
    {

        private static int[] playerCircle = new int[9];

        private static int[] playerX = new int[9];

        private static char[,] ticTacToe = 
        {
            { ' ', '|', ' ', '|', ' ' },
            { '-', '-', '-', '-', '-' },
            { ' ', '|', ' ', '|', ' ' },
            { '-', '-', '-', '-', '-' },
            { ' ', '|', ' ', '|', ' ' }
        };

        static void Main(string[] args)
        {
            
        }

        private static void PrintTicTacToe(char[,] ticTacToe)
        {
            for (int i = 0; i < ticTacToe.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToe.GetLength(1); j++)
                {
                    Console.Write(ticTacToe[i, j]);
                }
            }
        }
    }
}
