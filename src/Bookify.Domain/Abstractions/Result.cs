using System.Diagnostics.CodeAnalysis;

namespace Bookify.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; set; }
    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default!, default, error);

    public static Result<TValue> Create<TValue>(TValue value) =>
        value != null
            ? Success(value)
            : Failure<TValue>(Error.NullValue);
}

public class Result<TValue>(TValue value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    [NotNull]
    public TValue Value =>
        IsSuccess
            ? value!
            : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}