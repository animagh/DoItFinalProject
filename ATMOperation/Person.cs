using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public class Person
    {
        public string Name { get; set; }
      
        private decimal pin;
        public decimal IdentityNumber
        {
            get { return pin; }
            set
            {
                if (value.ToString().Length == 11)
                {
                    pin = value;
                } 
            }
        }

        private decimal phoneNumber;
        public decimal PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.ToString().Length == 9)
                {
                    phoneNumber = value;
                }
            }
        }


        private string mail;
        
        public string Email
        {
            get { return mail; }
            set
            {
                if (value.Contains("@"))
                {
                    mail = value;
                }
            }
        }
    }
}
