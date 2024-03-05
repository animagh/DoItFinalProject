using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public  class Login

    {
        private List <User> users;
        private IRepository repository;

        public Login()
        {
            repository=new UsersJSONRepository();
        }


        public User Loggin()
        {
            users=repository.GetAllUser();

            Console.Write("Enter your Personal Number: ");
            decimal pin = decimal.Parse(Console.ReadLine());

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();

            User currentUser = users.FirstOrDefault(u => u.IdentityNumber == pin && u.Password == password);

            if (currentUser != null)
            {
                Console.WriteLine($"Welcome, {currentUser.Name}!");
                return currentUser;
                
            }
            else
            {
                Console.WriteLine("Invalid Personal Number or Password. Please try again.");
                return null;
            }
        }

    }
}
