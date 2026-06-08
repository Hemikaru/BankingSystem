using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Enums;
using BankingSystem.Application.DTOs;
using BankingSystem.Application.Factories;

namespace BankingSystem.Application.Services;

public class AccountPersistenceService
{
    private readonly IBankAccountRepository _repository;
    private readonly IDataStore<AccountData> _dataStore;
    private readonly AccountFactory _factory;

    public AccountPersistenceService(
        IBankAccountRepository repository,
        IDataStore<AccountData> dataStore,
        AccountFactory factory)
    {
        _repository = repository;
        _dataStore = dataStore;
        _factory = factory;
    }

    public async Task SaveAsync()
    {
        var data = _repository
            .GetAll()
            .Select(x => new AccountData
            {
                Id = x.Id,
                AccountNumber = x.AccountNumber,
                Balance = x.Balance,
                AccountType = x.GetType().Name
            })
            .ToList();

        await _dataStore.SaveAsync(data);
    }

    public async Task LoadAsync()
    {
        var data =
            await _dataStore.LoadAsync();

        _repository.Clear();

        foreach (var item in data)
        {
            var type =
                item.AccountType == "SavingsAccount"
                ? AccountType.Savings
                : AccountType.Checking;

            var account =
                _factory.Create(
                    type,
                    item.AccountNumber);

            account.RestoreBalance(
                item.Balance);

            _repository.Add(account);
        }
    }
}