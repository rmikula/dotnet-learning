public class Option<T>
{
    private T? _object;
    public static readonly Option<T> None = new();

    public static Option<T> Some(T value) => new() { _object = value };
    
    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class
    {
        return _object is null ? Option<TResult>.None : Option<TResult>.Some(map(_object));
    }

    public T Reduce(T @default)
    {
        return _object ?? @default;
    }

    public override string ToString()
    {
        return _object is null ? "null" : _object.ToString();
    }
}