namespace BankingSystem.Application.DTOs;

public record CreateAccountResponse(
    Guid Id,
    string AccountNumber,
    decimal Balance
);