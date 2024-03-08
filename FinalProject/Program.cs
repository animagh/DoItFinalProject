// N1 კონსოლური კალკულატორი

while (true)
{
    Console.WriteLine("enter number N1:");
    string Userinput1 = Console.ReadLine();
    double number1;

    Console.WriteLine("enter number N2:");
    string Userinput2 = Console.ReadLine();
    double number2;

    try
    {
        number1 = Convert.ToDouble(Userinput1);
        number2 = Convert.ToDouble(Userinput2);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter valid numbers.");
        continue;
    }

    Console.WriteLine("choose the operation: + - * / :");
    char operation;
    try
    {
        operation = Convert.ToChar(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid operation. Please enter a valid operation character.");
        continue; 
    }

    switch (operation)
    {
        case '+':
            Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
            break;
        case '-':
            Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
            break;
        case '*':
            Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
            break;
        case '/':
            if (number2 == 0)
            {
                Console.WriteLine("Division by zero is impossible.");
            }
            else
            {
                Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
            }
            break;
        default:
            Console.WriteLine("Invalid operation.");
            break;
    }

    Console.WriteLine("Do you want to do another operation? Choose Y (for Yes) or N (for No)");
    char choice = Console.ReadKey().KeyChar;
    if (char.ToUpper(choice) != 'Y')

        break;

}

