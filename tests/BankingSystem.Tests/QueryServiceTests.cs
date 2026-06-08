using BankingSystem.Application.DTOs;
using BankingSystem.Application.Factories;
using BankingSystem.Application.Services;
using BankingSystem.Domain.Enums;
using BankingSystem.Infrastructure.Repositories;

namespace BankingSystem.Tests;

public class QueryServiceTests
{
    [Fact]
    public void GetTotalBalance_ShouldReturnCorrectSum()
    {
        var repository =
            new InMemoryBankAccountRepository();

        var service =
            new AccountService(
                repository,
                new AccountFactory());

        var queryService =
            new QueryService(repository);

        var first =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    AccountType.Checking));

        var second =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-002",
                    AccountType.Checking));

        service.Deposit(first.Id, 100);
        service.Deposit(second.Id, 200);

        Assert.Equal(
            300,
            queryService.GetTotalBalance());
    }

    [Fact]
    public void GetRichestAccount_ShouldReturnCorrectAccount()
    {
        var repository =
            new InMemoryBankAccountRepository();

        var service =
            new AccountService(
                repository,
                new AccountFactory());

        var queryService =
            new QueryService(repository);

        var first =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    AccountType.Checking));

        var second =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-002",
                    AccountType.Checking));

        service.Deposit(first.Id, 100);
        service.Deposit(second.Id, 500);

        var richest =
            queryService.GetRichestAccount();

        Assert.NotNull(richest);

        Assert.Equal(
            "ACC-002",
            richest.AccountNumber);
    }
}