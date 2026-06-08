using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.DTOs;

public record CreateAccountRequest(
    string AccountNumber,
    AccountType AccountType
);