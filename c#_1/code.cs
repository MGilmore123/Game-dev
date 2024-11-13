1using System;
using System.Collections.Generic;

namespace GuessTheNumberGame
{
    class Program
    {
        // Access Level - Private variable
        private static int secretNumber;

        // Access Level - Public variable
        public static List<int> guesses = new List<int>();

        static void Main(string[] args)
        {
            // Creating Variables With Data Types
            int maxAttempts = 5; // Integer variable for attempts
            bool isGuessed = false; // Boolean to check if number is guessed

            // Initializing secret number
            SetSecretNumber();

            Console.WriteLine("Welcome to Guess the Number Game!");
            Console.WriteLine("You have 5 attempts to guess the correct number (between 1 and 10).");

            // Demonstrate the use of loops
            for (int i = 1; i <= maxAttempts; i++)
            {
                Console.Write("Attempt " + i + ": Enter your guess: ");
                int playerGuess = int.Parse(Console.ReadLine());
                
                // Store each guess
                guesses.Add(playerGuess);

                // Create A Conditional Statement
                if (CheckGuess(playerGuess))
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                    isGuessed = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect guess. Try again!");
                }
            }

            if (!isGuessed)
            {
                Console.WriteLine("Game over! The secret number was: " + secretNumber);
            }

            Console.WriteLine("Your guesses were: ");
            DisplayGuesses();
        }

        // Create a Function
        static void SetSecretNumber()
        {
            Random rand = new Random();
            secretNumber = rand.Next(1, 11); // Random number between 1 and 10
        }

        // Function to check the guess
        static bool CheckGuess(int guess)
        {
            return guess == secretNumber;
        }

        // Arrays/Lists - Display list of guesses
        static void DisplayGuesses()
        {
            foreach (int guess in guesses)
            {
                Console.Write(guess + " ");
            }
            Console.WriteLine();
        }
    }
}
\


