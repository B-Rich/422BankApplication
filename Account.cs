using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422BankApplicationSharp
{
    class Account
    {
        //constructors
        public Account(double initialBalance = 0.0,
                        int newAccountNumber = 0,
                        string newName = "",
                        string newDateCreated = "")
        {
            this.mBalance = initialBalance;
            this.mAccountNumber = newAccountNumber;
            this.mName = newName;
            this.mDateCreated = newDateCreated;
        }
        public Account (Account copyAccount)
        {
            this.mAccountNumber = copyAccount.mAccountNumber;
            this.mBalance = copyAccount.mBalance;

            this.mDateCreated = copyAccount.mDateCreated;
            this.mName = copyAccount.mName;
        }

        //Getters and setters
        public double MBalance
        {
            get { return mBalance; }
            set { mBalance = value; }
        }
        public int MAccountNumber
        {
            get { return mAccountNumber; }
            set { mAccountNumber = value; }
        }
        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }
        public string MDateCreated
        {
            get { return mDateCreated; }
            set { mDateCreated = value; }
        }

        //Methods

        /// <summary>
        /// Adds money to an account
        /// </summary>
        /// <param name="newAmount">the amount to be added</param>
        /// <returns>The new balance</returns>
        public double credit (double newAmount)
        {
            mBalance += newAmount;
            return mBalance;
        }
        /// <summary>
        /// Attempts to debit an account by newAmount, and gives a warning if not enough money exists
        /// </summary>
        /// <param name="newAmount">The amount to be debited</param>
        /// <returns>The resulting amount</returns>
        public double debit(double newAmount)
        {
            if (newAmount > mBalance)
            {
                Console.WriteLine("Warning cannot withdraw " + newAmount + " exceeds your funds!");
            }
            else
            {
                mBalance -= newAmount;
            }
            return mBalance;
        }

        public void printBalance()
        {
            Console.WriteLine("A#: " + mAccountNumber);
            Console.WriteLine("Name: " + mName);
            Console.WriteLine("Current Balance: " + mBalance);
            Console.WriteLine("Date Created: " +mDateCreated);
        }


        //Private variables
        private double mBalance;

        private int mAccountNumber;

        private string mName;

        private string mDateCreated;

        
    }
}
