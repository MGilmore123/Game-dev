 using System;
using System.Threading;

namespace MarioConsoleGame
{
    class Program
    {
        static int playerPositionX = 5;
        static int playerPositionY = 10;
        static int screenHeight = 20;
        static int screenWidth = 50;
        static bool isJumping = false;
        static int jumpHeight = 0;
        static int score = 0;

        static char[,] screen = new char[screenHeight, screenWidth];
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            InitializeScreen();

            while (true)
            {
                ClearScreen();
                HandleInput();
                UpdateScreen();
                RenderScreen();

                Thread.Sleep(100); // Controls the game speed
            }
        }

        static void InitializeScreen()
        {
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    screen[y, x] = ' ';
                }
            }
            DrawObstacles();
        }

        static void ClearScreen()
        {
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    screen[y, x] = ' ';
                }
            }
        }

        static void DrawObstacles()
        {
            for (int i = 0; i < screenWidth; i += 10)
            {
                for (int j = screenHeight - 3; j < screenHeight; j++)
                {
                    screen[j, i] = '#';
                }
            }
        }

        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        playerPositionX = Math.Max(0, playerPositionX - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        playerPositionX = Math.Min(screenWidth - 1, playerPositionX + 1);
                        break;
                    case ConsoleKey.Spacebar:
                        if (!isJumping)
                        {
                            isJumping = true;
                            jumpHeight = 3;
                        }
                        break;
                }
            }
        }

        static void UpdateScreen()
        {
            if (isJumping)
            {
                if (jumpHeight > 0)
                {
                    playerPositionY--;
                    jumpHeight--;
                }
                else
                {
                    isJumping = false;
                }
            }
            else
            {
                if (playerPositionY < screenHeight - 1 && screen[playerPositionY + 1, playerPositionX] == ' ')
                {
                    playerPositionY++;
                }
            }

            if (screen[playerPositionY, playerPositionX] == '#')
            {
                Console.Clear();
                Console.WriteLine($"Game Over! Your score: {score}");
                Environment.Exit(0);
            }

            screen[playerPositionY, playerPositionX] = 'M';
            score++;
        }

        static void RenderScreen()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Console.Write(screen[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nScore: {score}");
        }
    }
}
wd