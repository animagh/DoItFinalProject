// See https://aka.ms/new-console-template for more information
using ATMOperation;


class Program
{

    static void Main(string[] args)
    { 
        bool process = true;
        while (process)
        {
            Console.WriteLine("Welcome to the ATM Operation. Please Choose Operation.");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Registration");
            Console.WriteLine("3. Exit");            
            

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    Login login = new();
                    User user = login.Loggin();

                    if (user != null)
                    {
                        user.PerformOperations();
                    }
                    
                    break;
                case 2:
                    Registration register=new();
                    break;
                case 3:
                    process = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    










}

















//string customerFilePath = "Customers.json";
//string operationFilePath = "Operation.json";

//List<User> users = LoadUsers(userFilePath);
//List<Operation> operations = LoadOperations(operationFilePath);

//int option;
//do
//{
//    Console.WriteLine("1. Register");
//    Console.WriteLine("2. Login");
//    Console.WriteLine("3. Exit");
//    Console.Write("Enter your option: ");
//    option = int.Parse(Console.ReadLine());

//    switch (option)
//    {
//        case 1:
//            Register(users, userFilePath);
//            break;
//        case 2:
//            User loggedUser = Login(users);
//            if (loggedUser != null)
//            {
//                PerformOperations(loggedUser, operations, operationFilePath);
//            }
//            break;
//        case 3:
//            Console.WriteLine("Exiting...");
//            break;
//        default:
//            Console.WriteLine("Invalid option. Please try again.");
//            break;
//    }
//} while (option != 3);
    

//    static List<User> LoadUsers(string filePath)
//{
//    if (!File.Exists(filePath))
//    {
//        File.WriteAllText(filePath, "[]");
//    }

//    string json = File.ReadAllText(filePath);
//    return JsonConvert.DeserializeObject<List<User>>(json);
//}

//static List<Operation> LoadOperations(string filePath)
//{
//    if (!File.Exists(filePath))
//    {
//        File.WriteAllText(filePath, "[]");
//    }

//    string json = File.ReadAllText(filePath);
//    return JsonConvert.DeserializeObject<List<Operation>>(json);
//}

//static void Register(List<User> users, string filePath)
//{
//    Console.Write("Enter your name: ");
//    string name = Console.ReadLine();

//    Console.Write("Enter your last name: ");
//    string lastName = Console.ReadLine();

//    Console.Write("Enter your personal number: ");
//    string personalNumber = Console.ReadLine();

//    if (users.Exists(u => u.PhoneNumber == personalNumber))
//    {
//        Console.WriteLine("This personal number is already in use.");
//        return;
//    }

//    User newUser = new User
//    {
//        Id = users.Count + 1,
//        Name = name,
//               PhoneNumber = personalNumber,
//        Password = GeneratePassword(),
//        Balance = 0
//    };

//    users.Add(newUser);
//    SaveUsers(users, filePath);

//    Console.WriteLine("Registration successful.");
//}

//static string GeneratePassword()
//{
//    Random random = new Random();
//    return random.Next(1000, 9999).ToString();
//}

//static void SaveUsers(List<User> users, string filePath)
//{
//    string json = JsonConvert.SerializeObject(users, Formatting.Indented);
//    File.WriteAllText(filePath, json);
//}

//static User Login(List<User> users)
//{
//    Console.Write("Enter your personal number: ");
//    string personalNumber = Console.ReadLine();

//    Console.Write("Enter your password: ");
//    string password = Console.ReadLine();

//    User user = users.Find(u => u.PhoneNumber == personalNumber && u.Password == password);

//    if (user != null)
//    {
//        Console.WriteLine($"Welcome, {user.Name}");
//    }
//    else
//    {
//        Console.WriteLine("Invalid personal number or password. Please try again.");
//    }

//    return user;
//}

//static void PerformOperations(User user, List<Operation> operations, string

