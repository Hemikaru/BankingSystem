using BankingSystem.Domain.Entities;

namespace BankingSystem.Tests;

public class BankAccountTests
{
    [Fact]
    public void NewAccount_ShouldHaveZeroBalance()
    {
        var account = new CheckingAccount("ACC-001");

        Assert.Equal(0, account.Balance);
    }

    [Fact]
    public void Deposit_ShouldIncreaseBalance()
    {
        var account = new CheckingAccount("ACC-001");

        account.Deposit(100);

        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void Deposit_WithNegativeAmount_ShouldThrow()
    {
        var account = new CheckingAccount("ACC-001");

        Assert.Throws<ArgumentException>(
            () => account.Deposit(-100));
    }

    [Fact]
    public void Deposit_WithZeroAmount_ShouldThrow()
    {
        var account = new CheckingAccount("ACC-001");

        Assert.Throws<ArgumentException>(
            () => account.Deposit(0));
    }

    [Fact]
    public void Constructor_WithEmptyAccountNumber_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(
            () => new CheckingAccount(""));
    }
}