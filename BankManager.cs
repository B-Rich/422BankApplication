using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace _422BankApplicationSharp
{
    class BankManager
    {
        //constructors
        public BankManager()
        {
            mAccounts = new List<Account>();
            mAccountsAvailable = new List<bool>();
            for (int i = 0; i < 1024; i++)
            {
                mAccountsAvailable.Add(true);
            }
            mNumberAccounts = 1024;

        }

        public BankManager(int maxNumberAccounts)
        {
            mAccounts = new List<Account>();
            mAccountsAvailable = new List<bool>();
            for (int i = 0; i < maxNumberAccounts; i++)
            {
                mAccountsAvailable.Add(true);
            }
            mNumberAccounts = maxNumberAccounts;

        }

        //Methods
        public void displayMenu()
        {
            Console.WriteLine(" 1. Create Account");
            Console.WriteLine(" 2. Delete Account");
            Console.WriteLine(" 3. Update Account");
            Console.WriteLine(" 4. Display Account");
            Console.WriteLine(" 5. Exit");
        }

        public int getMenuOption()
        {
            int option = 0;

            option = Convert.ToChar(Console.ReadLine());
            Console.Clear();

            return option;
        }

        public bool createAccount()
        {
            int accountNumber = 0;
            double balance = 0.0;
            string name;
            string dateCreated;
            bool success = true;

            Console.WriteLine("Enter account number: ");
            string temp = Console.ReadLine();
            accountNumber = Convert.ToInt16(temp);

            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Balance: ");
            temp = Console.ReadLine();
            balance = Convert.ToDouble(temp);

            Console.WriteLine("Enter Date: ");
            dateCreated = Console.ReadLine();

            int counter = 0;
            while ((counter < mNumberAccounts) &&  (mAccountsAvailable.ElementAt(counter) != true))
            {
                //search for an empty spot in the list
                counter ++;
            }
            if (mNumberAccounts<=counter)
            {
                Console.WriteLine("WARNING: Could not create account!");
                success = false;
            }
            else
            {
                try
                {
                    mAccounts.RemoveAt(counter);
                }
                catch { }
                mAccounts.Insert(counter,(new Account(balance,accountNumber,name,dateCreated)));
                mAccountsAvailable.RemoveAt(counter);
                mAccountsAvailable.Insert(counter,false);
            }
            return success;
        }

        public bool deleteAccount()
        {
            bool success = false;
            int accountNumber;
            int counter = 0;

            counter = findAccount();

            if ((counter < mNumberAccounts) && (mAccountsAvailable.ElementAt(counter) == false))
            {
                success = true;
                mAccountsAvailable.RemoveAt(counter);
                mAccountsAvailable.Insert(counter, true);
                Console.WriteLine("Account Deleted!");
            }

            return success;
        }

        public bool updateAccount()
        {
            bool success = false;
            string name = "", dateCreated = "";
            double balance = 0.0, deposit = 0.0;
            int accountNumber = 0, counter = 0, option = 0;

            counter = findAccount();

            if ((counter < mNumberAccounts) && (mAccountsAvailable.ElementAt(counter) == false))
            {
                success = true;

                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Deposit Money");

                option = Convert.ToChar(Console.ReadLine());
                switch (option - 48)
                {
                    case 1: Console.WriteLine("Enter Name: ");
                        name = Console.ReadLine();
                        mAccounts.ElementAt(counter).MName = name;
                        break;
                    case 2: Console.WriteLine("Enter amount to withdraw: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        mAccounts.ElementAt(counter).debit(balance);
                        break;
                    case 3: Console.WriteLine("Enter amount to deposit: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        mAccounts.ElementAt(counter).credit(balance);
                        break;
                    default: Console.WriteLine("ERROR: Invalid option");
                        break;
                
            
                          
                }
            }
            return success;
        }

        public void displayAccount()
        {
            int counter = 0;
            counter = findAccount();
            if ((counter < mNumberAccounts) && (mAccountsAvailable.ElementAt(counter) == false))
            {
                mAccounts.ElementAt(counter).printBalance();
            }
            else
            {
                Console.WriteLine("WARNING: Account does not exist");
            }
        }

        public int findAccount()
        {
            int accountnumber = 0;
            int counter = 0;
            Console.WriteLine("Enter Account Number");
            accountnumber = Convert.ToInt16(Console.ReadLine());

            for (counter = 0; ((counter!=mAccounts.Count)&&(counter < mNumberAccounts) && (mAccounts.ElementAt(counter).MAccountNumber != accountnumber)); counter++)
            {

            }
            return counter;

        }
        public void runBankApplication()
        {
            int option = 0;
            bool status = true, success = true;

            Console.WriteLine("***Welcome to Alex and Young's User Friendly Banking system ***");

            do
            {
                displayMenu();
                option = getMenuOption();
                switch (option - 48)
                {
                    case 1: success = createAccount();
                        if (success == false)
                        {
                            Console.WriteLine("WARNING: Could not create account!");
                        }
                        break;
                    case 2: success = deleteAccount();
                        if (success == false)
                        {
                            Console.WriteLine("WARNING: Could not delete account!");
                        }
                        break;
                    case 3:
                        success = updateAccount();
                        if (success == false)
                        {
                            Console.WriteLine("WARNING: Could not update account!");
                        }
                        break;
                    case 4:
                        displayAccount();
                        break;
                    case 5:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid Choice");
                        break;
                }


                

            } while (status != false);
        }

        //private variables
        List<Account> mAccounts; //The arrays have been replaced with dymically sized lists, because why not use the features of C# if we are converting to it.

        internal List<Account> MAccounts
        {
            get { return mAccounts; }
            set { mAccounts = value; }
        }
        List<bool> mAccountsAvailable;

        public List<bool> MAccountsAvailable
        {
            get { return mAccountsAvailable; }
            set { mAccountsAvailable = value; }
        }
        int mNumberAccounts;

        public int MNumberAccounts
        {
            get { return mNumberAccounts; }
            set { mNumberAccounts = value; }
        }
    }
}
