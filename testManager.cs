using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;


namespace _422BankApplicationSharp
{
    [TestFixture]
    public class testManager
    {
        [Test]
        public void testMangerCreationEmpty()
        {
            BankManager test = new BankManager();
            Assert.IsInstanceOf(typeof(BankManager), test);
            Assert.AreEqual(test.MNumberAccounts, 1024);

        }
        [Test]
        public void testMangerCreation([Range(0,1024, 32)] int numberOfAccounts)
        {
            BankManager test = new BankManager(numberOfAccounts);
            Assert.IsInstanceOf(typeof(BankManager), test);
            Assert.AreEqual(test.MNumberAccounts, numberOfAccounts);
        }

        //public bool createAccount()
        [Test]
        public void testCreateAccountSuccess([Values(1,2,3,500)] int size)
        {
            BankManager a = new BankManager(size);
            string test = @"1
young
12.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);

            Console.SetIn(sr);
            Console.SetOut(sw);

            Assert.IsTrue(a.createAccount());
        }
        //public bool createAccount()
        [Test]
        public void testCreateAccountFail([Values(1,2)] int size)
        {
            BankManager a = new BankManager(size);
            string test = @"1
young
12.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);
            for (int i = 0; i < size; i++ )
            {
                Console.SetIn(sr);
                Console.SetOut(sw);
                a.createAccount();
                Console.SetIn(sr);
                Console.SetOut(sw);
            }
            Assert.IsFalse(a.createAccount());
        }
        //public bool deleteAccount()
        [Test]
        public void testdeleteAccountSuccess()
        {
            BankManager a = new BankManager(2);
            string test = @"1
young
12.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);

            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();
            test = @"2
young
12.34
11/13/13";
            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();
            test = @"2
";
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.deleteAccount());
            test = @"1
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.deleteAccount());
        }

        //public bool deleteAccount()
        [Test]
        public void testdeleteAccountFail()
        {
            BankManager a = new BankManager(2);
            string test = @"1
young
12.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);

            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();
            test = @"2
young
12.34
11/13/13";
            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();
            test = @"20
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsFalse(a.deleteAccount());
            test = @"10
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsFalse(a.deleteAccount());
        }

        //public bool updateAccount()
        [Test]
        public void testUpdateAccountSuccess()
        {
            BankManager a = new BankManager(1);
            string test = @"1
young
15.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);

            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();

            test = @"1
1
hello";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.updateAccount());
            test = @"1
2
14.00
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.updateAccount());
            test = @"1
3
14.00";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.updateAccount());
        }


        //public bool updateAccount()
        [Test]
        public void testUpdateAccountFail()
        {
            BankManager a = new BankManager(1);
            string test = @"1
young
15.34
11/13/13";
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(test);

            Console.SetIn(sr);
            Console.SetOut(sw);
            a.createAccount();

            test = @"2
1
hello";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsFalse(a.updateAccount());

            
            test = @"21
2
10.00
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsFalse(a.updateAccount());
            test = @"3
3
14.00";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsFalse(a.updateAccount());
            test = @"1
3
100.00
";
            sr = new StringReader(test);
            Console.SetIn(sr);
            Console.SetOut(sw);
            Assert.IsTrue(a.updateAccount());
        }
    }
}