using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces;

public interface IBankAccountRepository
{
    void Add(BankAccount account);

    BankAccount? GetById(Guid id);

    IReadOnlyCollection<BankAccount> GetAll();

    void Update(BankAccount account);
    
    void Clear();
}