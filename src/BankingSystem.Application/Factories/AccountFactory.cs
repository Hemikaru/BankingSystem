using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Factories;

public class AccountFactory
{
    public BankAccount Create(
        AccountType accountType,
        string accountNumber)
    {
        return accountType switch
        {
            AccountType.Checking =>
                new CheckingAccount(accountNumber),

            AccountType.Savings =>
                new SavingsAccount(accountNumber),

            _ => throw new ArgumentException(
                "Unsupported account type.")
        };
    }
}