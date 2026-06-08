using BankingSystem.Application.Factories;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Enums;

namespace BankingSystem.Tests;

public class AccountFactoryTests
{
    private readonly AccountFactory _factory = new();

    [Fact]
    public void Create_CheckingAccount_ShouldReturnCheckingAccount()
    {
        var account = _factory.Create(
            AccountType.Checking,
            "ACC-001");

        Assert.IsType<CheckingAccount>(account);
    }

    [Fact]
    public void Create_SavingsAccount_ShouldReturnSavingsAccount()
    {
        var account = _factory.Create(
            AccountType.Savings,
            "ACC-002");

        Assert.IsType<SavingsAccount>(account);
    }
}