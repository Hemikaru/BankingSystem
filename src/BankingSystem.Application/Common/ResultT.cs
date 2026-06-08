namespace BankingSystem.Application.Common;

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(
        T? value,
        bool isSuccess,
        string? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
        => new(value, true, null);

    public static Result<T> Failure(string error)
        => new(default, false, error);
}