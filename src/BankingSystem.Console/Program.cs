using BankingSystem.Application.DTOs;
using BankingSystem.Application.Services;
using BankingSystem.Infrastructure.Repositories;

var repository = new InMemoryBankAccountRepository();
var service = new AccountService(repository);

try
{
    Console.WriteLine("=== Banking System ===");

    Console.Write("Enter account number: ");
    var accountNumber = Console.ReadLine()!;

    var account = service.CreateAccount(
        new CreateAccountRequest(accountNumber));

    Console.WriteLine();
    Console.WriteLine("Account created successfully.");
    Console.WriteLine($"Id: {account.Id}");
    Console.WriteLine($"Account Number: {account.AccountNumber}");

    Console.WriteLine();

    Console.Write("Deposit amount: ");
    var amount = decimal.Parse(Console.ReadLine()!);

    service.Deposit(account.Id, amount);

    var balance = service.GetBalance(account.Id);

    Console.WriteLine();
    Console.WriteLine($"Current balance: {balance}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}