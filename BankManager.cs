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
        /// <summary>
        /// Zero argument constructor, defaults number of accounts to 1024
        /// </summary>
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
        /// <summary>
        /// Bankmanager constructor that takes a single argument for the maximum number of accounts
        /// </summary>
        /// <param name="maxNumberAccounts"></param>
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

        /// <summary>
        /// Displays the main menu for the manager class
        /// </summary>
        public void displayMenu()
        {
            Console.WriteLine(" 1. Create Account");
            Console.WriteLine(" 2. Delete Account");
            Console.WriteLine(" 3. Update Account");
            Console.WriteLine(" 4. Display Account");
            Console.WriteLine(" 5. Exit");
        }
        /// <summary>
        /// Gets a menu option from the user and returns it as an integer
        /// </summary>
        /// <returns>Menue option as int</returns>
        public int getMenuOption()
        {
            int option = 0;

            option = Convert.ToChar(Console.ReadLine());
            Console.Clear();

            return option;
        }
        /// <summary>
        /// Creates an account, prompting the user for all relevent information
        /// </summary>
        /// <returns>Returns true on success, false on failure</returns>
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
        /// <summary>
        /// Deletes an account. Uses findAccount to prompt the user for an account number to delete
        /// </summary>
        /// <returns>Returns true on Success, false on failure</returns>
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
        /// <summary>
        /// Allows the user to update an account, with some constraints, they are prompted to either change the account name, debit the 
        /// account, or credit it.
        /// </summary>
        /// <returns>Returns true on success, false on failure</returns>
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
        /// <summary>
        /// Displays the account specified by the user, if it exists
        /// </summary>
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
        /// <summary>
        /// Prompts the user for an account number, and then finds the index of the matching account, if it exists
        /// </summary>
        /// <returns>The index of the specified account on success, the number of elements in the array on failure</returns>
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
        /// <summary>
        /// Runs the bank application as the user does not select quit.
        /// </summary>
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
        
        //The list of accounts
        List<Account> mAccounts; //The arrays have been replaced with dymically sized lists, because why not use the features of C# if we are converting to it.
        //getters and setters for the above
        internal List<Account> MAccounts
        {
            get { return mAccounts; }
            set { mAccounts = value; }
        }

        //A list designating whether open slots exist in the list for new accounts
        List<bool> mAccountsAvailable;

        //Getters and setters for the above
        public List<bool> MAccountsAvailable
        {
            get { return mAccountsAvailable; }
            set { mAccountsAvailable = value; }
        }

        //The maximum number of accounts available.
        int mNumberAccounts;

        public int MNumberAccounts
        {
            get { return mNumberAccounts; }
            set { mNumberAccounts = value; }
        }
    }
}
