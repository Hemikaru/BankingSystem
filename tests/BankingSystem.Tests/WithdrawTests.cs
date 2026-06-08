using BankingSystem.Domain.Entities;

namespace BankingSystem.Tests;

public class WithdrawTests
{
    [Fact]
    public void Withdraw_ShouldDecreaseBalance()
    {
        var account = new CheckingAccount("ACC-001");

        account.Deposit(100);
        account.Withdraw(40);

        Assert.Equal(60, account.Balance);
    }

    [Fact]
    public void Withdraw_WithInsufficientFunds_ShouldThrow()
    {
        var account = new CheckingAccount("ACC-001");

        account.Deposit(50);

        Assert.Throws<InvalidOperationException>(
            () => account.Withdraw(100));
    }

    [Fact]
    public void Withdraw_WithNegativeAmount_ShouldThrow()
    {
        var account = new CheckingAccount("ACC-001");

        Assert.Throws<ArgumentException>(
            () => account.Withdraw(-10));
    }
}