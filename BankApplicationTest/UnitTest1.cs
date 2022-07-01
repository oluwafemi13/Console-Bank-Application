using BankApplicationTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace TestProject
{
    [TestClass]
    public class AccountRegistrationTestClass
    {
        [TestMethod]
        public void FirstNameUserInputReturnTypeString()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.FirstName();

            //Assert
            Assert.ReferenceEquals(result, Equals(""));
        }

        [TestMethod]
        public void LastNameUserInputReturnTypeString()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.LastName();

            //Assert
            Assert.ReferenceEquals(result, typeof(char[]));

        }

        [TestMethod]
        public void CustomerIdReturnTypeInteger()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.CustomerId();

            //Assert
            Assert.ReferenceEquals(result, typeof(int));
        }

        [TestMethod]
        public void AccountTypeSelectOneReturnCurrent()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.CustomerId();
            string input = "1";

            //Assert
            Assert.ReferenceEquals(input, Equals("current"));
        }

        [TestMethod]
        public void AccountTypeSelectTwoReturnSavings()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.CustomerId();
            string input = "2";

            //Assert
            Assert.ReferenceEquals(input, Equals("savings"));
        }

        [TestMethod]
        public void AccountTypeSelectThreeReturnFixedDeposit()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.CustomerId();
            string input = "3";

            //Assert
            Assert.ReferenceEquals(input, Equals("FixedDeposit"));
        }

        [TestMethod]
        public void AccountTypeSelectFourReturnCoperate()
        {
            //Arrange
            AccountRegistration registration = new AccountRegistration();

            //Act
            var result = registration.CustomerId();
            string input = "4";

            //Assert
            Assert.ReferenceEquals(input, Equals("Corporate"));
        }


    }

  
        [TestClass]
        public class AccountServicesTestClass
        {

            [TestMethod]
            public void DepositIntoAccountInputZeroReturnInvalid()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.DepositIntoAccount(0);
                string output = "please input a valid amount".ToLower();

                Assert.ReferenceEquals(result, Equals(output));



            }
            [TestMethod]
            public void DepositIntoAccountInputOneReturnSuccessful()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.DepositIntoAccount(1);
                string output = "Deposit Successful";

                //Assert
                Assert.ReferenceEquals(result, Equals(output));


            }
            [TestMethod]
            public void DepositIntoAccountInputNegativeReturnInvalid()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.DepositIntoAccount(-1);
                string output = "please input a valid amount".ToLower();

                //Assert
                Assert.ReferenceEquals(result, Equals(output));


            }
            [TestMethod]
            public void DepositIntoAccountInputReturnTypeOfInt()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.DepositIntoAccount(1);


                //Assert
                Assert.ReferenceEquals(result, GetType());


            }
            [TestMethod]
            public void MakeADepositReturnInvalid()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.MakeADepositUponOpenAccount();
                int input = 0;
                string output = "please input a valid amount".ToLower();

                Assert.ReferenceEquals(input, Equals(output));
            }

            [TestMethod]
            public void MakeADepositPositiveInput()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.MakeADepositUponOpenAccount();
                int input = 1;
                string output = "Deposit Successful";

                Assert.ReferenceEquals(result, Equals(output));
            }

            [TestMethod]
            public void MakeADepositNegativeInput()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                var result = services.MakeADepositUponOpenAccount();
                int input = -1;
                string output = "please input a valid amount";

                Assert.ReferenceEquals(input, Equals(output));
            }

            [TestMethod]
            public void MakeADepositReturnType()
            {
                //Arrange
                AccountServices services = new AccountServices();

                //Act
                int result = services.MakeADepositUponOpenAccount();


                //Assert
                Assert.AreEqual(result, typeof(int));
            }
        }
    }


