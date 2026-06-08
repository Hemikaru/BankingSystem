using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities;

public abstract class BankAccount
{
    private readonly List<Transaction> _transactions = [];

    public Guid Id { get; }
    public string AccountNumber { get; }
    public decimal Balance { get; protected set; }

    public IReadOnlyCollection<Transaction> Transactions =>
        _transactions.AsReadOnly();

    protected BankAccount(string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number is required.");

        Id = Guid.NewGuid();
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Balance += amount;

        _transactions.Add(
            new Transaction(
                amount,
                TransactionType.Deposit));
    }
}