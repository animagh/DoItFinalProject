// N1 კონსოლური კალკულატორი

while (true)
{
    Console.WriteLine("enter number N1:");
    string Userinput1 = Console.ReadLine();
    double number1 = Convert.ToDouble(Userinput1);

    Console.WriteLine("enter number N2:");
    string Userinput2 = Console.ReadLine();
    double number2 = Convert.ToDouble(Userinput2);

    Console.WriteLine("choose the operation: + - * / :");
    char operation = Convert.ToChar(Console.ReadLine());

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

