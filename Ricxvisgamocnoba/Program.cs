// See https://aka.ms/new-console-template for more information


// N2 რიცხვის გამომცნობი თამაში

Console.WriteLine("Hello. This is a game about guessing number");
Console.WriteLine("Please write your name:");
string name = Console.ReadLine();
Console.WriteLine("Lets start the Game! In this game there are different difficulty levels:");
Console.WriteLine("1. Easy (1-25)");
Console.WriteLine("2. Medium (1-50)");
Console.WriteLine("3. Hard (1-100)");
Console.WriteLine("Please enter your choice 1, 2 or 3");

int maxNumber=0;
int attempts = 10;
int choice;

while (true)
{
    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
    {
        switch (choice)
        {
            case 1:
                maxNumber = 25;
                break;
            case 2:
                maxNumber = 50;
                break;
            case 3:
                maxNumber = 100;
                break;
        }

        break;
    }
   else
    {
        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
    }

}


Random random = new Random();
int targetNumber = random.Next(1, maxNumber + 1);

Console.WriteLine($"Guess the number between 1 and {maxNumber}. You have {attempts} attempts.");

for (int i = 1; i <= attempts; i++)
{
    Console.Write($"Attempt {i}: Enter your guess: ");
    if (int.TryParse(Console.ReadLine(), out int guess))
    {
        if (guess > maxNumber)
        {
            Console.WriteLine($"Guess must be between 1 and {maxNumber}");
        }
        if (guess == targetNumber)
        {
            Console.WriteLine("Congratulations! You guessed the correct number!");
            return;
        }
        else if (guess < targetNumber)
        {
            Console.WriteLine("The number you need to guess is higher than that.");
        }
        else
        {
            Console.WriteLine("The number you need to guess is lower than that.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

Console.WriteLine($"Sorry, you've run out of attempts. The correct number was {targetNumber}.");

