using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationTask
{
    public class AccountDetails : AccountRegistration
    {
        Random random = new Random();
        //get account number


        public int AccountNumber()
        {

            string convert;
            int randNum;
            int final = 0;
            do
            {
                randNum = Math.Abs(random.Next() * 10);
                convert = randNum.ToString();

            } while (convert.Length < 10);
            if (convert.Length == 10)
            {
                final = randNum;
            }
            return final;
        }

        public int AccountBalance(int amount)
        {
            int balance = 0;

            balance = balance + amount;
            return balance;
        }
    }

}

