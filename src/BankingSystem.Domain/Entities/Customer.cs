namespace BankingSystem.Domain.Entities;

public class Customer
{
    public Guid Id { get; }
    public string FullName { get; }

    public Customer(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Customer name is required.");

        Id = Guid.NewGuid();
        FullName = fullName;
    }
}