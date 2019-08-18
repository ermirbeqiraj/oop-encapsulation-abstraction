using Bank.Logic;
using System;

namespace Bank.Client
{
    class Program
    {
        static void Log(object o) => Console.WriteLine(o.ToString());

        static void Main(string[] args)
        {
            var userAccount = new UserBankAccount(Guid.NewGuid(), 1234, Currency.EUR);

            Log(userAccount);

            userAccount.Deposit(1000);

            Log(userAccount);

            userAccount.Withdraw(100);

            Log(userAccount);

            userAccount.Withdraw(100, Currency.USD);

            Log(userAccount);

            Console.Read();
        }
    }
}
