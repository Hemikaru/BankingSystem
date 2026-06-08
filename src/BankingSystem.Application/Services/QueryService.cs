using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;

namespace BankingSystem.Application.Services;

public class QueryService
{
    private readonly IBankAccountRepository _repository;

    public QueryService(
        IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<BankAccount> GetAccountsWithPositiveBalance()
    {
        return _repository
            .GetAll()
            .Where(x => x.Balance > 0);
    }

    public IEnumerable<BankAccount> GetAccountsOrderedByBalance()
    {
        return _repository
            .GetAll()
            .OrderByDescending(x => x.Balance);
    }

    public decimal GetTotalBalance()
    {
        return _repository
            .GetAll()
            .Sum(x => x.Balance);
    }

    public BankAccount? GetRichestAccount()
    {
        return _repository
            .GetAll()
            .OrderByDescending(x => x.Balance)
            .FirstOrDefault();
    }
}