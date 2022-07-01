using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApplicationTask
{
    public class AccountRegistration
    {
        Random random = new Random();

        //customers firstname
        public string FirstName()
        {
            Console.WriteLine("please Enter your first name");
            string firstName = Console.ReadLine();
            return firstName;
            /*get { return _FirstName; }
            set { _FirstName = value; }*/
        }

        //customers last name
        public string LastName()
        {
            Console.WriteLine("please Enter your Last name");
            string lastName = Console.ReadLine();
            return lastName;

            /*get { return _LastName; }
            set { _LastName = value; }*/
        }

        public int CustomerId()
        {
            int rand = random.Next() * 1000;
            return rand;

            /*get { return _CustomerId; }
            set { _CustomerId = random.Next(10,10000); }*/
        }

        public string AccountType()
        {
            //this method is going to check if the user already has an account with the same account type
            Console.WriteLine("please select the account type\n" +
                "<<<1>>> Current Account\n" +
                "<<<2>>> Savings Account\n" +
                "<<<3>>> Fixed Deposit Account\n" +
                "<<<4>>> Corporate account.");
            var input = Console.ReadLine();

            // var convert = int.Parse(input);

            switch (input)
            {
                case "1":
                    return "current";
                case "2":
                    return "savings";
                case "3":
                    return "FixedDeposit ";
                case "4":
                    return "Corporate";
                default:
                    return "Wrong Input";
            }


        }


    }
}

