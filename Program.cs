using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BankApplicationTask
{
    public class Program
    {

        //retrieve data from database
        public static string RetrieveData(int AccountNumber)
        {
            
            string AccountBalance = " ";
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=LAPTOP-01CQPF63\SQLEXPRESS;Initial Catalog=ApplicationBank;Integrated Security=True";
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string oString = "Select * from AccountHolder where AccountNumber=@AccountNumber";
                SqlCommand oCmd = new SqlCommand(oString, sqlConnection);
                oCmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                sqlConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        //matchingPerson.firstName = oReader["FirstName"].ToString();
                        //matchingPerson.lastName = oReader["LastName"].ToString();
                         AccountBalance = oReader["AccountBalance"].ToString();
                    }

                    sqlConnection.Close();
                }
            }
            return AccountBalance;
        }

        public static void Main(string[] args)
        {
           /*string account =  RetrieveData(1109482736);*/
            //Console.WriteLine(account);
            AccountDetails accountDetails = new AccountDetails();
            AccountRegistration registration = new AccountRegistration();
            AccountServices services = new AccountServices();
            Table table = new Table();
            

            int deposit = 0;
           
            string firstName = "";
            string lastName = "";
            string accountType = "";
            int accountNumber = 0;
            // string fullname = " ";
            int amount = 0;

            Console.WriteLine("welcome, to GreedyBank, Please press a Digit below to start.");

            Console.WriteLine("1=> Open New Account\n" +

                              "2=> Make a Deposit \n" +

                              "3=> Make a Withdrawal \n" +

                              "4=> Check Account Balance \n" +

                              "5=> Make Internal Transfer \n");

            //Get Customer Choice of Transaction
            var input = Console.ReadLine();
            //convert input to a string
            var convert = int.Parse(input);


            //create a database and a connection string
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=LAPTOP-01CQPF63\SQLEXPRESS;Initial Catalog=ApplicationBank;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();



            Console.WriteLine("connection Established Successfully!");
            //create a CRUD
            if (convert == 1)
            {
                try
                {
                    //firstname
                    firstName = registration.FirstName();
                    //lastname
                    lastName = registration.LastName();
                    //account type
                    accountType = registration.AccountType();
                    //customer ID
                    var id = accountDetails.CustomerId();
                    //Account Number
                    accountNumber = accountDetails.AccountNumber();
                    //Account Balance

                    Console.WriteLine("Account Created Successfully");

                    Console.WriteLine("would you like to make a deposit? Yes/No");
                    string answer = Console.ReadLine();
                    answer = answer.Trim().ToLower();

                    if (answer == "yes")
                    {
                        deposit = services.MakeADepositUponOpenAccount();

                    }
                    else
                    {
                        deposit = 0;
                    }
                    string insertQuery = "INSERT INTO AccountHolder(FirstName, LastName,AccountType,AccountNumber,AccountBalance)VALUES('" + firstName + "','" + lastName + "','" + accountType + "'," + accountNumber + "," + deposit + ")";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Data is Successfully inserted into Table");



                    //FETCH AND DISPLAY DATA FROM THE DATABASE


                    //to display query from database
                    string displayQuery = "SELECT * FROM AccountHolder";
                    //create object of sql command class
                    SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                    //data reader read data from table record by record at a time
                    SqlDataReader dataReader = displayCommand.ExecuteReader();

                    //print the table

                    table.PrintLine();
                    table.PrintRow("FullName", "Account Number", "Account Type", "Account Balance");
                    table.PrintLine();
                    while (dataReader.Read())
                    {
                        table.PrintRow($"{dataReader.GetValue(1).ToString()}", $"{dataReader.GetValue(4).ToString()}", $"{dataReader.GetValue(5).ToString()}", $"{dataReader.GetValue(6).ToString()}");
                        // table.PrintRow("", "", "", "");
                        table.PrintLine();
                    }

                    dataReader.Close();
                    sqlConnection.Close();
                    Console.ReadLine();



                }


                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }








            //DEPOSIT INTO ACCOUNT SERVICE
            //UPDATE DATABASE
            if (convert == 2)
            {
                try
                {

                    Console.WriteLine("please enter your first name");
                    string firstname = Console.ReadLine();

                     Console.WriteLine("please enter your account number");
                     accountNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please enter amount you want to Deposit");
                    amount = Convert.ToInt32(Console.ReadLine());

                    string AccountBalance = RetrieveData(accountNumber);
                    int conversion = Convert.ToInt32(AccountBalance);

                    int finalBalance = amount + conversion;

                    string updateQuery = "UPDATE AccountHolder SET AccountBalance =" + finalBalance + " WHERE AccountNumber = " + accountNumber + "";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Deposit Successful");
                    sqlConnection.Close();

                    
                   
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



            }


            //make a Withdraw
            if (convert == 3)
            {
                int finalBalance = 0;
                try
                {

                    Console.WriteLine("please enter your first name");
                    string firstname = Console.ReadLine();

                    Console.WriteLine("please enter your account number");
                    accountNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please enter amount you want to WithDraw");
                    amount = Convert.ToInt32(Console.ReadLine());

                    string AccountBalance = RetrieveData(accountNumber);
                    int conversion = Convert.ToInt32(AccountBalance);

                    if(amount > conversion || (conversion-amount) <=1000)
                    {
                        Console.WriteLine("Insufficient Balance");
                    }
                    else
                    {
                        finalBalance = conversion - amount;
                        string updateQuery = "UPDATE AccountHolder SET AccountBalance =" + finalBalance + " WHERE AccountNumber = " + accountNumber + "";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                        updateCommand.ExecuteNonQuery();
                        Console.WriteLine("WithDraw Successful");
                        sqlConnection.Close();
                    }     

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



            }

            //check Account Balance
             if(convert == 4)
             {
                 try
                 {
                    
                     Console.WriteLine("Please Enter your Account Number");
                     accountNumber = Console.Read();
                     accountType = registration.AccountType();
                    string Retrieve = RetrieveData(accountNumber);
                    Console.WriteLine(Retrieve);
                     /*//to display query from database
                     string displayQuery = "SELECT * FROM customer WHERE AccountNumber = accountNumber";
                     //create object of sql command class
                     SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                     //data reader read data from table record by record at a time
                     SqlDataReader dataReader = displayCommand.ExecuteReader();

                     //print the table
                     string AccountBalance = dataReader.GetValue(5).ToString();
                     firstName = dataReader.GetValue(1).ToString();
                     lastName = dataReader.GetValue(2).ToString();
                     fullname = firstName + " " + lastName;
                     table.PrintLine();
                     table.PrintRow("FullName", "Account Number", "Account Type", "Account Balance");
                     table.PrintLine();
                     while (dataReader.Read())
                     {
                         table.PrintRow($"{fullname}", $"{dataReader.GetValue(3).ToString()}", $"{dataReader.GetValue(4).ToString()}", $"{dataReader.GetValue(5).ToString()}");
                         // table.PrintRow("", "", "", "");
                         table.PrintLine();
                     }


                     Console.ReadLine();
                     dataReader.Close();
                     sqlConnection.Close();*/
                 }
                 catch (Exception ex)
                 {

                     Console.WriteLine(ex.Message);
                 }
             }



            Console.ReadLine();



        }
    }
}
