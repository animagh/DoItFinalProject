using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public class User:Person
    {
        private ILogger logger;

        
        public int Id { get; set; }

        private string password;
        public string Password{get; set;}

        public int Type { get; set; }

        private double balance;
        public double Balance
        {
            get { return balance; }
            set
            {
                if (value > 0)
                {
                    balance = value;
                }
            }
        }

        public User()
        {
            logger = new Logger();
            
        }
        public string GeneratePassword()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        public void PerformOperations()
        {
            bool process = true;
            while (process)
            {
                Console.WriteLine("\nATM Operations:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View History");
                Console.WriteLine("5. Logout");
                Console.WriteLine("Please choose operation:");
                //balansis gageba
                var latestOperation = logger.GetLatestOperation(Id);
                
                if (latestOperation != null)
                {
                    Balance = latestOperation.CurrentBalance;

                }
                else
                {
                    Balance = 0;
                }
                
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:

                        Operation checkBalance = new Operation
                        {
                            OperationTime = DateTime.Now,
                            OperationId = Id,
                            OperationName = $"User {Name} - Checked Balance : {DateTime.Now}. Current Balance {balance}",
                            CurrentBalance = Balance,
                            changeAmmount = 0
                        };
                        CheckBalance(checkBalance);
                        break;
                    case 2:
                        Console.WriteLine("Please enter the Amount of money to deposit: ");
                        double MoneyToEnter = double.Parse(Console.ReadLine());
                        Deposit(MoneyToEnter);
                        Operation DepositOperation = new Operation
                        {
                            OperationTime = DateTime.Now,
                            OperationId = Id,
                            OperationName = $"User {Name} - Deposited {MoneyToEnter} Lari : {DateTime.Now} , Current Balance {balance}",
                            CurrentBalance = Balance,
                            changeAmmount = MoneyToEnter

                        };
                        CheckBalance(DepositOperation);
                        
                        break;
                    case 3:
                        Console.WriteLine("Please enter the Amount of money to Withdraw: ");
                        double MoneyToGet = double.Parse(Console.ReadLine());
                        Withdraw(MoneyToGet);
                        Operation WithdrawOperation = new Operation
                        {

                            OperationTime = DateTime.Now,
                            OperationId = Id,
                            OperationName = $"User {Name} - Withdrawed {MoneyToGet} Lari : {DateTime.Now} , Current Balance {balance}",
                            CurrentBalance = Balance,
                            changeAmmount = MoneyToGet


                        };
                        CheckBalance(WithdrawOperation);
                        
                        break;
                    case 4:
                        ViewHistory();
                        break;
                    case 5:
                        process = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        private void Deposit(double balance)
        {

            Balance += balance;
            

        }

        private void Withdraw(double balance)
        {
            try
            {
                if (Balance >= balance)
                {
                    Balance -= balance;
                }
                else
                {
                    throw new Exception("The operation can not be performed due to insufficient funds");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            
            

        }

        private void CheckBalance(Operation operation)
        {
            
            logger.AddNewLog(operation);
            
           var latestOperation = logger.GetLatestOperation(Id);
            Console.WriteLine($"{latestOperation.OperationName}");
        }

        private void ViewHistory()
        {
            var logs = logger.GetAllLoG(Id);
            foreach ( var log in logs )
            {
                Console.WriteLine(log.OperationName);
            }
            
        }
    }
}
