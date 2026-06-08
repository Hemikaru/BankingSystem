using BankingSystem.Application.DTOs;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;
using BankingSystem.Application.Factories;

namespace BankingSystem.Application.Services;

public class AccountService
{
    private readonly IBankAccountRepository _repository;
    private readonly AccountFactory _accountFactory;

    public AccountService(
        IBankAccountRepository repository,
        AccountFactory accountFactory)
    {
        _repository = repository;
        _accountFactory = accountFactory;
    }

    public CreateAccountResponse CreateAccount(
        CreateAccountRequest request)
    {
        var account = _accountFactory.Create(
            request.AccountType,
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

    public void Transfer(
        Guid fromAccountId,
        Guid toAccountId,
        decimal amount)
    {
        if (fromAccountId == toAccountId)
            throw new InvalidOperationException(
                "Cannot transfer to the same account.");

        var sourceAccount =
            _repository.GetById(fromAccountId);

        var targetAccount =
            _repository.GetById(toAccountId);

        if (sourceAccount is null)
            throw new InvalidOperationException(
                "Source account not found.");

        if (targetAccount is null)
            throw new InvalidOperationException(
                "Target account not found.");

        sourceAccount.Withdraw(amount);

        targetAccount.Deposit(amount);

        _repository.Update(sourceAccount);
        _repository.Update(targetAccount);
    }

    public void Withdraw(
        Guid accountId,
        decimal amount)
    {
        var account =
            _repository.GetById(accountId);

        if (account is null)
            throw new InvalidOperationException(
                "Account not found.");

        account.Withdraw(amount);

        _repository.Update(account);
    }
}