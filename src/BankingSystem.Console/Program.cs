using BankingSystem.Application.DTOs;
using BankingSystem.Application.Factories;
using BankingSystem.Application.Services;
using BankingSystem.Domain.Enums;
using BankingSystem.Infrastructure.Repositories;

var repository = new InMemoryBankAccountRepository();

var accountFactory = new AccountFactory();

var accountService = new AccountService(
    repository,
    accountFactory);

var queryService = new QueryService(
    repository);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Banking System ===");
    Console.WriteLine("1. Create account");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Transfer");
    Console.WriteLine("5. Show total balance");
    Console.WriteLine("6. Show richest account");
    Console.WriteLine("0. Exit");

    Console.Write("Choose option: ");

    var option = Console.ReadLine();

    try
    {
        switch (option)
        {
            case "1":
                CreateAccount();
                break;

            case "2":
                Deposit();
                break;

            case "3":
                Withdraw();
                break;

            case "4":
                Transfer();
                break;

            case "5":
                ShowTotalBalance();
                break;

            case "6":
                ShowRichestAccount();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Unknown option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void CreateAccount()
{
    Console.Write("Account number: ");
    var accountNumber = Console.ReadLine()!;

    Console.Write("Type (1 - Checking, 2 - Savings): ");

    var type = Console.ReadLine() == "2"
        ? AccountType.Savings
        : AccountType.Checking;

    var account =
        accountService.CreateAccount(
            new CreateAccountRequest(
                accountNumber,
                type));

    Console.WriteLine($"Created account {account.Id}");
}

void Deposit()
{
    Console.Write("Account id: ");
    var accountId = Guid.Parse(Console.ReadLine()!);

    Console.Write("Amount: ");
    var amount = decimal.Parse(Console.ReadLine()!);

    accountService.Deposit(accountId, amount);

    Console.WriteLine("Deposit successful.");
}

void Withdraw()
{
    Console.Write("Account id: ");
    var accountId = Guid.Parse(Console.ReadLine()!);

    Console.Write("Amount: ");
    var amount = decimal.Parse(Console.ReadLine()!);

    accountService.Withdraw(accountId, amount);

    Console.WriteLine("Withdraw successful.");
}

void Transfer()
{
    Console.Write("From account id: ");
    var fromId = Guid.Parse(Console.ReadLine()!);

    Console.Write("To account id: ");
    var toId = Guid.Parse(Console.ReadLine()!);

    Console.Write("Amount: ");
    var amount = decimal.Parse(Console.ReadLine()!);

    accountService.Transfer(
        fromId,
        toId,
        amount);

    Console.WriteLine("Transfer successful.");
}

void ShowTotalBalance()
{
    Console.WriteLine(
        $"Total balance: {queryService.GetTotalBalance()}");
}

void ShowRichestAccount()
{
    var account =
        queryService.GetRichestAccount();

    if (account is null)
    {
        Console.WriteLine("No accounts found.");
        return;
    }

    Console.WriteLine(
        $"Richest account: {account.AccountNumber} | Balance: {account.Balance}");
}