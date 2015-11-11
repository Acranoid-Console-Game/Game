using System;
using System.Net.Mail;
using System.Threading;

class Program
{
    static void Main()
    {
        Initialize();

        int ballTop = 10;
        int ballLeft = 8;
        int paddleLeft = 30;

        int minLeft = 0;
        int maxLeft = 79;
        int minTop = 0;
        int maxTop = 22;

        int topDirection = -1;
        int leftDirection = -1;

        string paddle = "========";
        
        char[,] bricks = new char[2, maxLeft];
        
        for (int row = 0; row < bricks.GetLength(0); row++)
        {
            for (int col = 0; col < bricks.GetLength(1); col++)
            {
                bricks[row, col] = '#';
            }
        }

        while (true)
        {
            if (ballLeft == minLeft)
            {
                leftDirection = 1;
            }

            if (ballLeft == maxLeft)
            {
                leftDirection = -1;
            }

            if (ballTop == minTop)
            {
                topDirection = 1;
            }

            if (ballTop == maxTop)
            {
                if (ballLeft >= paddleLeft && ballLeft <= paddleLeft + paddle.Length)
                {
                    topDirection = -1;
                }
                else
                {
                    // Game over
                    break;
                }
            }
            
            ballLeft = ballLeft + leftDirection;
            ballTop = ballTop + topDirection;

            if (ballTop < bricks.GetLength(0))
            {
                if (bricks[ballTop, ballLeft] == '#')
                {
                    bricks[ballTop, ballLeft] = ' ';
                }
            }

            // Render bricks
            for (int row = 0; row < bricks.GetLength(0); row++)
            {
                for (int col = 0; col < bricks.GetLength(1); col++)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write(bricks[row, col]);
                }
            }

            // Render ball
            Console.SetCursorPosition(ballLeft, ballTop);
            Console.Write("@");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.LeftArrow)
                {
                    if (paddleLeft > minLeft)
                    {
                        // Move left
                        paddleLeft = paddleLeft - 2;
                    }
                }
                if (pressed.Key == ConsoleKey.RightArrow)
                {
                    if (paddleLeft <= maxLeft - paddle.Length)
                    {
                        // Move right
                        paddleLeft = paddleLeft + 2;
                    }
                }
            }

            // Render paddle
            Console.SetCursorPosition(paddleLeft, maxTop);
            Console.WriteLine(paddle);

            Thread.Sleep(100);
            Console.Clear();
        }

        GameOver();
    }

    static void Initialize()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    static void GameOver()
    {
        Console.WriteLine("---GAME OVER---");
        Console.Read();
    }
}
