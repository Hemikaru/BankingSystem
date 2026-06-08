using BankingSystem.Application.DTOs;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Repositories;

namespace BankingSystem.Application.Services;

public class AccountService
{
    private readonly IBankAccountRepository _repository;

    public AccountService(
        IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public CreateAccountResponse CreateAccount(
    CreateAccountRequest request)
    {
        var account = new CheckingAccount(
            request.AccountNumber);

        _repository.Add(account);

        return new CreateAccountResponse(
            account.Id,
            account.AccountNumber,
            account.Balance);
    }

    public void Deposit(
        Guid accountId,
        decimal amount)
    {
        var account = _repository.GetById(accountId);

        if (account is null)
            throw new InvalidOperationException("Account not found.");

        account.Deposit(amount);

        _repository.Update(account);
    }

    public decimal GetBalance(Guid accountId)
    {
        var account = _repository.GetById(accountId);

        if (account is null)
            throw new InvalidOperationException("Account not found.");

        return account.Balance;
    }
}