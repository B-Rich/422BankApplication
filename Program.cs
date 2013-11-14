using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422BankApplicationSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generic main function that instantiates a new bank manager and then calls run bank application
            BankManager bankapp = new BankManager();
            bankapp.runBankApplication();
        }
    }
}
