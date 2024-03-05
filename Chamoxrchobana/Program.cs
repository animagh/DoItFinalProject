// See https://aka.ms/new-console-template for more information


List<string> words = new List<string>
{
    "apple", "banana", "orange", "grape", "kiwi", "strawberry", "pineapple", "blueberry", "peach", "watermelon"
};

Random random = new Random();
string chosenWord = words[random.Next(words.Count)];
char[] guessedLetters = new char[chosenWord.Length];
Array.Fill(guessedLetters, '_');

int attemptsLeft = 6;
List<char> guessedLettersList = new List<char>();

Console.WriteLine("Welcome to the Word Guessing Game");
Console.WriteLine("You need to guess the word. You have 6 attempts to guess a letter in the word.");
Console.WriteLine("Here is the word to guess:");
Console.WriteLine(string.Join(" ", guessedLetters));



while (attemptsLeft > 0)
{
    Console.WriteLine($"\nAttempts left: {attemptsLeft}");
    Console.Write("Enter a letter: ");
    char input = Console.ReadLine().ToLower()[0];

    if (!char.IsLetter(input))
    {
        Console.WriteLine("Invalid input. Please enter a letter.");
        continue;
    }

    char guess = input;

    if (guessedLettersList.Contains(guess))
    {
        Console.WriteLine("Correct. Your letter is in this word. Try another one.");
        continue;
    }

    guessedLettersList.Add(guess);

    if (chosenWord.Contains(guess))
    {
        Console.WriteLine("Correct guess!");
        bool found= false;
        for (int i = 0; i < chosenWord.Length; i++)
        {
            if (chosenWord[i] == guess)
            {
                guessedLetters[i] = guess;
                found = true;
                
            }
        }
        if (found)
        {
            attemptsLeft--;
        }
        Console.WriteLine(string.Join(" ", guessedLetters));

        if (!guessedLetters.Contains('_'))
        {
            Console.WriteLine("Congratulations! You guessed the word correctly!");
            return;
        }
        if (attemptsLeft == 0)
        {
            Console.WriteLine("Enter the gueesed word");
            string UserWord = Console.ReadLine();
            if (UserWord == chosenWord)
            {
                Console.WriteLine("CongraTulation!");
            }
            else
            {
                Console.WriteLine($"Game over! The word was: {chosenWord}");
            }

            return;
        }
    }
    else
    {
        Console.WriteLine("Incorrect guess!");
        attemptsLeft--;

        if (attemptsLeft == 0)
        {
            Console.WriteLine("Enter the gueesed word");
            string UserWord = Console.ReadLine();
            if (UserWord ==chosenWord)
            {
                Console.WriteLine("CongraTulation!");
            }
            else
            {
                Console.WriteLine($"Game over! The word was: {chosenWord}");
            }
            
            return;
        }
    }

}









