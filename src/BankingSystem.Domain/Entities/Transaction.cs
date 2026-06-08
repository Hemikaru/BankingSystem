using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities;

public class Transaction
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; }
    public DateTime CreatedAt { get; }

    public Transaction(
        decimal amount,
        TransactionType type)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Id = Guid.NewGuid();
        Amount = amount;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
}