using System.Diagnostics.CodeAnalysis;

namespace Optional;

public readonly struct Option<T> : IEquatable<Option<T>> where T : class
{
    private readonly T? _value;
    public static readonly Option<T> None = new();
    // public static Option<T> None() => new();

    private Option(T value)
    {
        _value = value;
    }

    public static Option<T> Some(T value) => new(value)
    {
    };

    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class
    {
        return _value is null ? Option<TResult>.None : Option<TResult>.Some(map(_value));
    }

    public ValueOption<TResult> MapValue<TResult>(Func<T, TResult> map) where TResult : struct =>
        _value is not null ? ValueOption<TResult>.Some(map(_value)) : ValueOption<TResult>.None;


    public Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) where TResult : class
    {
        return _value is null ? Option<TResult>.None : map(_value);
    }

    public T Reduce(T orElse)
    {
        return _value ?? orElse;
    }

    public T Reduce(Func<T> orElse)
    {
        return _value ?? orElse();
    }

    public override int GetHashCode()
    {
        return _value is null ? 0: EqualityComparer<T>.Default.GetHashCode(_value);
    }

    public static bool operator ==(Option<T>? a, Option<T>? b) => a?.Equals(b) ?? b is null;
    public static bool operator !=(Option<T>? a, Option<T>? b) => !(a == b);

    public bool Equals(Option<T> other)
    {
        return EqualityComparer<T?>.Default.Equals(_value, other._value);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Option<T> option && Equals(option);
    }
}