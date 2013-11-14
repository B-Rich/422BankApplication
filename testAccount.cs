using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace _422BankApplicationSharp
{

    [TestFixture]
    public class testAccount
    {


        //the following test checks to see if creating accouts works along with it's setters and getters
        [Test]
        public void testAccountCreation([Values(-10.00,0.00,3.00, 300.00, 3000.00)] double bal, [Values(1,12,123,1234,12345)] int aNum, [Values("young","alex")] string name, [Values("1-1-13","may 4th 2009", "1-2-30000", "11/12/13", "this is not a date")] string date)
        {
            Account test = new Account(bal, aNum, name, date);
            Assert.AreEqual(test.MAccountNumber, aNum);
            Assert.AreEqual(test.MBalance, bal);
            Assert.AreEqual(test.MDateCreated, date);
            Assert.AreEqual(test.MName, name);
        }

        [Test]
        public void testAccountCopy([Values(-10.00, 0.00, 3.00, 300.00, 3000.00)] double bal, [Values(1, 12, 123, 1234, 12345)] int aNum, [Values("young", "alex")] string name, [Values("1-1-13", "may 4th 2009", "1-2-30000", "11/12/13", "this is not a date")] string date)
        {
            Account test1 = new Account(bal, aNum, name, date);
            Account test2 = new Account(test1);
            Assert.AreEqual(test1.MAccountNumber, test2.MAccountNumber);
            Assert.AreEqual(test1.MBalance, test2.MBalance);
            Assert.AreEqual(test1.MDateCreated, test2.MDateCreated);
            Assert.AreEqual(test1.MName, test2.MName);

        }

        //public double credit (double newAmount)
        [Test]
        public void testCredit([Values(-100.00, 0.00, 100.00)] double bal, [Range(-10.00, 10.00, 3.50)] double cred) //by tree fitty
        {
            Account test = new Account(bal, 0, "test", "11/12/13");
            double originalbal = test.MBalance;
            test.credit(cred);
            Assert.AreEqual(test.MBalance, originalbal + cred);
        }

        //public double debit(double newAmount) a successfull withdrawl
        [Test]
        public void testDebitSuccess([Values (3.50, 3.51, 350.00, 100.00)] double bal, [Values (0, 3.50)] double debit)
        {
            Account test = new Account(bal, 0, "test", "11/13/13");
            double originalBal = test.MBalance;
            test.debit(debit);
            Assert.AreEqual(test.MBalance, originalBal - debit);
        }

        //public double debit(double newAmount)
        [Test]
        public void testDebitFail([Values(1.00, 0.00, 5.00)] double bal, [Range(0, 100.00, 5.01)] double debit)
        {
            Account test = new Account(bal, 0, "test", "11/13/13");
            double originalBal = test.MBalance;
            test.debit(debit);
            Assert.AreEqual(test.MBalance, originalBal);
        }
    }
}