using System.Reflection.Emit;

namespace uk.co.nfocus.games.dice
{
    internal class Program
    {
        // A function which, provided with the name of a player and a random number generator,
        // generates and sums two numbers between 1 and 6 inclusive and returns this sum.
        static int TakeTurn(string name, Random generator)
        {
            Console.WriteLine($"\n{name}'s Roll: ");
            int roll1 = generator.Next(1, 7);
            int roll2 = generator.Next(1, 7);
            int sum = roll1 + roll2;
            Console.WriteLine($"{name} rolled a {roll1} and a {roll2}");
            Console.WriteLine($"Total is {sum}\n");
            return sum;
        }
        static void Main(string[] args)
        {
            // Request a name from the player, defaulting to "Player" if none provided
            Console.WriteLine("What's your name?");
            string? playerName = Console.ReadLine();
            if (playerName == "" || playerName == null)
            {
                playerName = "Player";
            }

            // A variable to control the while loop.
            // True at the start of the game, the player can set it to false at the end by typing n
            bool wantToPlay = true;

            // Loop of the main game
            while (wantToPlay)
            {
                Random generator = new Random();
                // Call the TakeTurn function for each player to calculate their score
                int sumP1 = TakeTurn(playerName, generator);


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                int sumP2 = TakeTurn("Computer", generator);

                // Compare scores to determine the winner
                if (sumP1 > sumP2)
                {
                    Console.WriteLine("You WIN!");
                }
                else if (sumP1 < sumP2)
                {
                    Console.WriteLine("You LOSE :(");
                }
                else
                {
                    Console.WriteLine("It's a DRAW");
                }

                // Give the player a choice to play again with y or quit with n
                Console.WriteLine("Play again? y or n");
                string response = Console.ReadLine();
                if (response != "")
                {
                    if (response.ToLower() == "n")
                    {
                        wantToPlay = false;
                        Environment.Exit(0);
                    }
                }
            }

        }
    }
}