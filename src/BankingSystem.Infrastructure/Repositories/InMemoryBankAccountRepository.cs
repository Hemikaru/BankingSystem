using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Repositories;

namespace BankingSystem.Infrastructure.Repositories;

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    private readonly List<BankAccount> _accounts = [];

    public void Add(BankAccount account)
    {
        _accounts.Add(account);
    }

    public BankAccount? GetById(Guid id)
    {
        return _accounts.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<BankAccount> GetAll()
    {
        return _accounts;
    }

    public void Update(BankAccount account)
    {
    }
}