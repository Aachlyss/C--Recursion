using System;


namespace Recursion
{

    using System;

    class KnightTour
    {
        static int N;
        static int[][] board;
        static int moveCount = 0;
        static int[][] moves = {
        new int[] { 2, 1 },
        new int[] { 1, 2 },
        new int[] { -1, 2 },
        new int[] { -2, 1 },
        new int[] { -2, -1 },
        new int[] { -1, -2 },
        new int[] { 1, -2 },
        new int[] { 2, -1 }
    };

        static bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < N && y >= 0 && y < N && board[x][y] == -1;
        }

        static void PrintBoard()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool KnightTourRecursive(int x, int y)
        {
            board[x][y] = moveCount++;

            if (moveCount == N * N)
            {
                PrintBoard();
                board[x][y] = -1;
                moveCount--;
                return true;
            }

            for (int moveIndex = 0; moveIndex < 8; moveIndex++)
            {
                int nextX = x + moves[moveIndex][0];
                int nextY = y + moves[moveIndex][1];

                if (IsValidMove(nextX, nextY))
                {
                    if (KnightTourRecursive(nextX, nextY))
                    {
                        board[x][y] = -1;
                        moveCount--;
                        return true;
                    }
                }
            }

            board[x][y] = -1;
            moveCount--;
            return false;
        }

        static void Main()
        {
            N = int.Parse(Console.ReadLine()); // Change N to the desired board size
            board = new int[N][];
            for (int i = 0; i < N; i++)
            {
                board[i] = new int[N];
                for (int j = 0; j < N; j++)
                {
                    board[i][j] = -1;
                }
            }

            KnightTourRecursive(0, 0);
        }
    }

}