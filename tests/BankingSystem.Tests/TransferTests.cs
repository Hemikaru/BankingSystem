using BankingSystem.Application.DTOs;
using BankingSystem.Application.Factories;
using BankingSystem.Application.Services;
using BankingSystem.Infrastructure.Repositories;

namespace BankingSystem.Tests;

public class TransferTests
{
    [Fact]
    public void Transfer_ShouldMoveMoneyBetweenAccounts()
    {
        var repository =
            new InMemoryBankAccountRepository();

        var service =
            new AccountService(
                repository,
                new AccountFactory());

        var source =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    Domain.Enums.AccountType.Checking));

        var target =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-002",
                    Domain.Enums.AccountType.Checking));

        service.Deposit(source.Id, 100);

        service.Transfer(
            source.Id,
            target.Id,
            40);

        Assert.Equal(
            60,
            service.GetBalance(source.Id));

        Assert.Equal(
            40,
            service.GetBalance(target.Id));
    }

    [Fact]
    public void Transfer_ToSameAccount_ShouldThrow()
    {
        var repository =
            new InMemoryBankAccountRepository();

        var service =
            new AccountService(
                repository,
                new AccountFactory());

        var account =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    Domain.Enums.AccountType.Checking));

        Assert.Throws<InvalidOperationException>(
            () => service.Transfer(
                account.Id,
                account.Id,
                10));
    }

    [Fact]
    public void Transfer_WithInsufficientFunds_ShouldThrow()
    {
        var repository =
            new InMemoryBankAccountRepository();

        var service =
            new AccountService(
                repository,
                new AccountFactory());

        var source =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    Domain.Enums.AccountType.Checking));

        var target =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-002",
                    Domain.Enums.AccountType.Checking));

        Assert.Throws<InvalidOperationException>(
            () => service.Transfer(
                source.Id,
                target.Id,
                100));
    }
}