using System;
using System.Runtime.CompilerServices;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount c1, CurrencyAmount c2) => IsCurrenciesTheSame(c1, c2) ? c1.amount == c2.amount : CurrenciesAreNotTheSame<bool>();
    public static bool operator !=(CurrencyAmount c1, CurrencyAmount c2) => !(c1 == c2);
    public static bool operator <(CurrencyAmount c1, CurrencyAmount c2) => IsCurrenciesTheSame(c1, c2) ? c1.amount < c2.amount: CurrenciesAreNotTheSame<bool>();
    public static bool operator >(CurrencyAmount c1, CurrencyAmount c2) => !(c1 < c2);
    public static decimal operator +(CurrencyAmount c1, CurrencyAmount c2) => IsCurrenciesTheSame(c1,c2) ? c1.amount+c2.amount :CurrenciesAreNotTheSame<decimal>();
    public static decimal operator -(CurrencyAmount c1, CurrencyAmount c2) => IsCurrenciesTheSame(c1,c2) ? c1.amount -c2.amount :CurrenciesAreNotTheSame<decimal>();
    public static decimal operator *(CurrencyAmount c1, CurrencyAmount c2) => IsCurrenciesTheSame(c1,c2) ? c1.amount * c2.amount :CurrenciesAreNotTheSame<decimal>();
    public static decimal operator /(CurrencyAmount c1, CurrencyAmount c2) 
    {
        if(c2.amount != 0)
            return IsCurrenciesTheSame(c1, c2) ? c1.amount / c2.amount : CurrenciesAreNotTheSame<decimal>();
        return 0;
    }
    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount.amount;
    public static explicit operator double(CurrencyAmount currencyAmount) => (double)currencyAmount.amount;

    #region Helper method
    private static bool IsCurrenciesTheSame(CurrencyAmount c1, CurrencyAmount c2) => c1.currency == c2.currency;
    private static T CurrenciesAreNotTheSame<T>() => throw new ArgumentException("Currencies are not the same");
    #endregion
}
