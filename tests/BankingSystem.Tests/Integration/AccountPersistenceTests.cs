using BankingSystem.Application.DTOs;
using BankingSystem.Application.Factories;
using BankingSystem.Application.Services;
using BankingSystem.Domain.Enums;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Repositories;

namespace BankingSystem.Tests.Integration;

public class AccountPersistenceTests
{
    [Fact]
    public async Task SaveAndLoad_ShouldPreserveBalance()
    {
        var tempFile = Path.GetTempFileName();

        var repository =
            new InMemoryBankAccountRepository();

        var factory = new AccountFactory();

        var service =
            new AccountService(
                repository,
                factory);

        var dataStore =
            new JsonAccountDataStore(tempFile);

        var persistence =
            new AccountPersistenceService(
                repository,
                dataStore,
                factory);

        var account =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    AccountType.Checking));

        service.Deposit(account.Id, 250);

        await persistence.SaveAsync();

        repository.Clear();

        await persistence.LoadAsync();

        Assert.Equal(
            250,
            repository.GetAll().First().Balance);

        File.Delete(tempFile);
    }

    [Fact]
    public async Task ReloadedAccount_ShouldAllowDeposit()
    {
        var tempFile = Path.GetTempFileName();

        var repository =
            new InMemoryBankAccountRepository();

        var factory = new AccountFactory();

        var service =
            new AccountService(
                repository,
                factory);

        var persistence =
            new AccountPersistenceService(
                repository,
                new JsonAccountDataStore(tempFile),
                factory);

        var account =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    AccountType.Checking));

        service.Deposit(account.Id, 100);

        await persistence.SaveAsync();

        repository.Clear();

        await persistence.LoadAsync();

        var loaded =
            repository.GetAll().First();

        service.Deposit(
            loaded.Id,
            50);

        Assert.Equal(
            150,
            loaded.Balance);

        File.Delete(tempFile);
    }

    [Fact]
    public async Task MultipleSaveLoadCycles_ShouldPreserveData()
    {
        var tempFile = Path.GetTempFileName();

        var repository =
            new InMemoryBankAccountRepository();

        var factory = new AccountFactory();

        var service =
            new AccountService(
                repository,
                factory);

        var persistence =
            new AccountPersistenceService(
                repository,
                new JsonAccountDataStore(tempFile),
                factory);

        var account =
            service.CreateAccount(
                new CreateAccountRequest(
                    "ACC-001",
                    AccountType.Checking));

        service.Deposit(account.Id, 300);

        await persistence.SaveAsync();

        repository.Clear();

        await persistence.LoadAsync();

        await persistence.SaveAsync();

        repository.Clear();

        await persistence.LoadAsync();

        Assert.Single(repository.GetAll());

        File.Delete(tempFile);
    }

    [Fact]
    public async Task ReloadedAccount_ShouldAllowTransfer()
    {
        var tempFile = Path.GetTempFileName();

        var repository =
            new InMemoryBankAccountRepository();

        var factory = new AccountFactory();

        var service =
            new AccountService(
                repository,
                factory);

        var persistence =
            new AccountPersistenceService(
                repository,
                new JsonAccountDataStore(tempFile),
                factory);

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

        service.Deposit(first.Id, 500);

        await persistence.SaveAsync();

        repository.Clear();

        await persistence.LoadAsync();

        var accounts =
            repository.GetAll().ToList();

        service.Transfer(
            accounts[0].Id,
            accounts[1].Id,
            100);

        Assert.Equal(
            100,
            accounts[1].Balance);

        File.Delete(tempFile);
    }
}   