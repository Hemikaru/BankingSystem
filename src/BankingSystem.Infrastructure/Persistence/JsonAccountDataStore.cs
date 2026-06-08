using System.Text.Json;
using BankingSystem.Domain.Interfaces;
using BankingSystem.Application.DTOs;
namespace BankingSystem.Infrastructure.Persistence;

public class JsonAccountDataStore
    : IDataStore<AccountData>
{
    private readonly string _filePath;

    public JsonAccountDataStore(
        string filePath)
    {
        _filePath = filePath;
    }

    public async Task SaveAsync(
        IReadOnlyCollection<AccountData> items,
        CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(
            items,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(
            _filePath,
            json,
            cancellationToken);
    }

    public async Task<IReadOnlyCollection<AccountData>> LoadAsync(
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
            return [];

        try
        {
            var json =
                await File.ReadAllTextAsync(
                    _filePath,
                    cancellationToken);

            var accounts =
                JsonSerializer.Deserialize<List<AccountData>>(json);

            return accounts ?? [];
        }
        catch (JsonException)
        {
            throw new InvalidOperationException(
                "Data file is corrupted.");
        }
    }
}