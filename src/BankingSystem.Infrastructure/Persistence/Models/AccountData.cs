namespace BankingSystem.Infrastructure.Persistence.Models;

public class AccountData
{
    public Guid Id { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string AccountType { get; set; } = string.Empty;
}