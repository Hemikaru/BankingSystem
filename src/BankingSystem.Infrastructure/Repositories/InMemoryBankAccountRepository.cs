using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;

namespace BankingSystem.Infrastructure.Repositories;

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<Guid, BankAccount> _accounts = [];

    public void Add(BankAccount account)
    {
        _accounts[account.Id] = account;
    }

    public BankAccount? GetById(Guid id)
    {
        return _accounts.GetValueOrDefault(id);
    }

    public IReadOnlyCollection<BankAccount> GetAll()
    {
        return _accounts.Values;
    }

    public void Update(BankAccount account)
    {
    }

    public void Clear()
    {
        _accounts.Clear();
    }
}