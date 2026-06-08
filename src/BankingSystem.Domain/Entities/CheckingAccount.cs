namespace BankingSystem.Domain.Entities;

public sealed class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber)
        : base(accountNumber)
    {
    }
}