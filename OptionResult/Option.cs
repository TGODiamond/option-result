namespace OptionResult;

/// <summary>
/// Either `Some` or `None`
/// </summary>
/// <typeparam name="T">Type</typeparam>
public readonly record struct Option<T>
{
    public readonly bool IsSome;
    public readonly T? Obj;


    // Constructors //

    public Option()
    {
        IsSome = false;
    }

    public Option(T value)
    {
        Obj = value;
        IsSome = true;
    }
    
    
    // Explicit constructors //

    /// <summary>
    /// Explicit construction of a `Option` with the `Some` variant.
    /// </summary>
    public static Option<T> Some(T value)
    {
        return new Option<T>(value);
    }
    
    /// <summary>
    /// Explicit construction of a `Option` with the `None` variant.
    /// </summary>
    public static Option<T> None()
    {
        return new Option<T>();
    }

    
    // Unwrap //

    public void Unwrap(Action<T> someCase, Action noneCase)
    {
        if (IsSome)
        {
            someCase(Obj!);
            return;
        }

        noneCase();
    }
    
    public R Unwrap<R>(Func<T, R> someCase, Func<R> noneCase)
    {
        return IsSome ? someCase(Obj!) : noneCase();
    }
}

/// <summary>
/// Just like a `FromMaybe`, but to methods that return `void`.
///
/// Use the Default constructor to construct this struct, then initialize it with the `TryCatch` method afterwards.
///
/// Returns `Some(E)` if the method passed threw with exception `E`.
///
/// Returns `None` if no exception was caught.
/// </summary>
/// <typeparam name="E">Represents the `Exception`</typeparam>
public static class FromMaybeVoid<E> where E : Exception
{
    // `TryCatch` methods which uses `Action` //

    public static Option<E> TryCatch(Action maybe)
    {
        try
        {
            maybe();
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }
}
