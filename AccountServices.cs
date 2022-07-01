using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationTask
{
    public class AccountServices : AccountDetails
    {


        //this is a deposit into the account upon registration
        public int DepositIntoAccount(int deposit)
        {
            
            while(deposit <= 0)
            {
                Console.WriteLine("please input a valid amount");
            }

            Console.WriteLine("Deposit Successful");


            return deposit;
        }

        public int MakeADepositUponOpenAccount()
        {
            Console.WriteLine("How Much do you wish to Deposit?");
            var deposit = Console.ReadLine();
            int convert = Convert.ToInt32(deposit);
            if (convert <= 0)
            {
                Console.WriteLine("please input a valid amount");
            }
            else
            {
                Console.WriteLine("Deposit Successful");
            }


            return convert;
        }

        public string WithDrawal(int amount)
        {
            string successful = "Withdraw Successful";
            string failed = "Withdraw Failed";
            if (amount <= 0)
            {
                return failed;
            }

            return successful;
        }


        //make interaccount Transfers
        public int Transfer(int amount)
        {
            if (amount > 0)
            {
                return amount;
            }
            else { return 0; }
        }
    }
}
