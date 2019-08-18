namespace Bank.Logic.Interfaces
{
    public interface IConvertionRates
    {
        decimal Convert(decimal amountToConvert, Currency amountToConvertCurrency, Currency baseCurrency);
    }
}
