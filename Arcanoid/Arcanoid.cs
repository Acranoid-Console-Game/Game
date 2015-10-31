using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int ballTop = 10;
        int ballLeft = 8;

        int topDirection = -1;
        int leftDirection = -1;

        while (true)
        {
            if (ballLeft == 0)
            {
                leftDirection = 1;
            }
            if (ballLeft == 79)
            {
                leftDirection = -1;
            }

            if (ballTop == 0)
            {
                topDirection = 1;
            }
            if (ballTop == 22)
            {
                topDirection = -1;
            }

            ballLeft = ballLeft + leftDirection;
            ballTop = ballTop + topDirection;
           
            Console.SetCursorPosition(ballLeft, ballTop);
            Console.Write("@");

            Console.SetCursorPosition(20, 22);
            Console.WriteLine("========");

            Thread.Sleep(100);
            Console.Clear();
        }
    }
}
