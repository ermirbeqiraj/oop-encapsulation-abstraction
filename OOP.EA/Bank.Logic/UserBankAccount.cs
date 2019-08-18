using Bank.Logic.Implementations;
using Bank.Logic.Interfaces;
using System;

namespace Bank.Logic
{
    public class UserBankAccount
    {
        private readonly IConvertionRates _convertionRates;
        
        public UserBankAccount(Guid id, decimal amount, Currency currency)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Please provide a positive amount");

            _convertionRates = new ConvertionRates();

            Id = id;
            Amount = amount;
            AccountCurrency = currency;
        }

        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public Currency AccountCurrency { get; private set; }

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0 || withdrawAmount > Amount)
                throw new ArgumentOutOfRangeException("Please provide a valid amount for withdraw");

            Amount -= withdrawAmount;
        }

        public void Withdraw(decimal withdrawAmount, Currency withdrawCurrency)
        {
            if (withdrawAmount <= 0)
                throw new ArgumentOutOfRangeException("Please provide a valid amount for withdraw");

            var amountInAccountCurrency = withdrawAmount;

            if (withdrawCurrency != AccountCurrency)
            {
                var convertedAmount = _convertionRates.Convert(withdrawAmount, withdrawCurrency, AccountCurrency);
                if (convertedAmount > Amount)
                    throw new ArgumentOutOfRangeException("Please provide a valid withdraw amount");

                amountInAccountCurrency = convertedAmount;
            }

            Amount -= amountInAccountCurrency;
        }

        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
                throw new ArgumentOutOfRangeException("Please provide a valid amount for withdraw");

            Amount += depositAmount;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nAmount:{Amount}\nCurrency:{AccountCurrency}\n\n";
        }
    }
}
