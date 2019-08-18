using Bank.Logic.Interfaces;

namespace Bank.Logic.Implementations
{
    public class ConvertionRates : IConvertionRates
    {
        public decimal Convert(decimal amountToConvert, Currency amountToConvertCurrency, Currency baseCurrency)
        {
            var rates = 1.12m; // suppose we got this from some remote storage
            return amountToConvert * rates;
        }
    }
}
