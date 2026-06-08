namespace BankingSystem.Domain.Entities;

public sealed class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber)
        : base(accountNumber)
    {
    }
}