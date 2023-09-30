using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame;

class Program
{
    // Main method that prints statements and then calls the appropriate method
    
    static void Main()
    {
        Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får 5 försök.");
        Console.WriteLine("Vill du spela på lätt, medium eller svårt?");
        Console.WriteLine(
            "Skriv 1 för lätt - tal mellan 1 och 5\nSkriv 2 för medium - tal mellan 1 och 20\nSkriv 3 för svår - tal mellan 1 och 50");
        int myRandomNumber = GetLevel();
        Console.WriteLine($"Skriv din första gissning!");

        GuessNumber(myRandomNumber);

      
    }

    /* A method that checks if input is a valid number, if its not then a message is written and user is
     able to try until a valid number is added.*/
    static int InputGuess()
    {
        while (true)
        {
            string? guess = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(guess))
            {
                if (int.TryParse(guess, out int guessNumber) && guessNumber > 0)
                {
                    return guessNumber;
                }
                else
                {
                    Console.WriteLine("Du behöver skriva in en giltig siffra!");
                }
            }
        }
    }

    /* A method that takes the guess and compares it to the random number generated to see if it matches,
     and then prints an appropriate message. The for-loop gives the user 5 attempts and after that 
     the loop breaks and the game is over. If the user gets the number correct the loop breaks 
     and the game is over. */
    static void GuessNumber(int myRandomNumber)
    {
        var maxAttempts = 5;

        for (int i = 1; i <= maxAttempts; i++)
        {
            var guess = InputGuess();

            if (guess == myRandomNumber)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
                break;
            }
            else if (guess < myRandomNumber)
            {
                Console.WriteLine($"Tyvärr du gissade för lågt! Du har gjort {i} försök.");
            }
            else
            {
                Console.WriteLine($"Tyvärr du gissade för högt! Du har gjort {i} försök.");
            }

            if (i == 5)
            {
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                break;

            }
        }
    }

    /* Method that takes input from user, tries to parse it and checks if it's a 1,2 or 3 in a switch-case.
     If it's not 1,2 or 3 it continues to take input until input is correct. When the input is 1,2,or 3 it 
     goes in to a switch-case and generates a random number in between 1 and a number depending on the level.
    */
    static int GetLevel()
    {
        while (true)
        {
            string? level = Console.ReadLine();

            if (int.TryParse(level, out int number))
            {
                Random random = new();
                switch (number)
                {
                    case 1: Console.WriteLine("Du valde nivå 1, gissa ett nummer mellan 1 och 5");
                            return random.Next(1, 5);
                    case 2: Console.WriteLine("Du valde nivå 2, gissa ett nummer mellan 1 och 20");
                            return random.Next(1, 20);
                    case 3: Console.WriteLine("Du valde nivå 3, gissa ett nummer mellan 1 och 50"); 
                            return random.Next(1, 50);
                    default: Console.WriteLine("Du behöver skriva en siffra mellan 1 och 3.");
                             continue;
                }
            }
            else
            {
                Console.WriteLine("Du behöver skriva en siffra mellan 1 och 3.");
            }
        }
    }
}