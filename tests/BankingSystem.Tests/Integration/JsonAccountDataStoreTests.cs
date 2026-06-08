using BankingSystem.Application.DTOs;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Tests.Integration;

public class JsonAccountDataStoreTests
{
    [Fact]
    public async Task SaveAsync_ShouldCreateFile()
    {
        var tempFile = Path.GetTempFileName();

        var store =
            new JsonAccountDataStore(tempFile);

        var accounts = new List<AccountData>
        {
            new()
            {
                Id = Guid.NewGuid(),
                AccountNumber = "ACC-001",
                Balance = 100,
                AccountType = "CheckingAccount"
            }
        };

        await store.SaveAsync(accounts);

        Assert.True(File.Exists(tempFile));

        File.Delete(tempFile);
    }

    [Fact]
    public async Task LoadAsync_ShouldReturnSavedAccounts()
    {
        var tempFile = Path.GetTempFileName();

        var store =
            new JsonAccountDataStore(tempFile);

        var accounts = new List<AccountData>
        {
            new()
            {
                Id = Guid.NewGuid(),
                AccountNumber = "ACC-001",
                Balance = 500,
                AccountType = "CheckingAccount"
            }
        };

        await store.SaveAsync(accounts);

        var loaded =
            await store.LoadAsync();

        Assert.Single(loaded);

        File.Delete(tempFile);
    }

    [Fact]
    public async Task LoadAsync_WhenFileMissing_ShouldReturnEmptyCollection()
    {
        var tempFile =
            Path.Combine(
                Path.GetTempPath(),
                $"{Guid.NewGuid()}.json");

        var store =
            new JsonAccountDataStore(tempFile);

        var result =
            await store.LoadAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task LoadAsync_WithCorruptedJson_ShouldThrow()
    {
        var tempFile = Path.GetTempFileName();

        await File.WriteAllTextAsync(
            tempFile,
            "{ invalid json");

        var store =
            new JsonAccountDataStore(tempFile);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => store.LoadAsync());

        File.Delete(tempFile);
    }
}