using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    internal class Registration
    {
        private List<User> users;
        private IRepository repository;

        public Registration()
        {
            repository=new UsersJSONRepository();
            Register();
        }
        private void Register()
        {
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your Last Name: ");
            string lastName = Console.ReadLine();


            Console.WriteLine("Enter your Phone Number: ");
            decimal phoneNumber = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter your PersonalNumber");
            decimal pin = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your Type");
            int type = int.Parse(Console.ReadLine());

            users = repository.GetAllUser();
            int Id = users.Count() + 1;
            
           
            bool identityExists = users.SingleOrDefault(u => u.IdentityNumber == pin) != null;

            if(identityExists)
            {
                Console.WriteLine("User with this Personal Number already exists.");
                
            }
            else
            {
                User newUser = new User()
                {
                    Id = Id,
                    Name = name + " " + lastName,
                    IdentityNumber = pin,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Balance = 0,
                    Type = type,
                };
                newUser.Password = newUser.GeneratePassword();




                Console.WriteLine($"Registration successful! Your password is: {newUser.Password}. Please keep it safe.");

                repository.AddNewUser(newUser);
            }

            
                       
            
        }
        
    }
}
