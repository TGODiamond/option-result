namespace OptionResult;

internal sealed class ParameterlessConstructedResultException : Exception
{
    internal ParameterlessConstructedResultException(string message)
        : base(message)
    {
    }
}

/// <summary>
/// Either `Ok` or `Err`.
///
/// Note: Using the Default constructor is forbidden and will throw.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Error</typeparam>
public readonly record struct Result<T, E>
{
    public readonly bool IsOk;

    public readonly T? OkObj;
    public readonly E? ErrObj;


    // Constructors //

    // Disallow default constructor
    public Result()
    {
        throw new ParameterlessConstructedResultException(
            "Constructing a `Result` without any parameters is forbidden. (Default constructor forbidden) " +
            "Use `new Result<T, E>(E)`, to return an Error."
        );
    }


    public Result(T okObj)
    {
        OkObj = okObj;
        IsOk = true;
    }

    public Result(E errObj)
    {
        ErrObj = errObj;
        IsOk = false;
    }

    internal Result(T? t, E? e, bool isOk)
    {
        IsOk = isOk;
        OkObj = t;
        ErrObj = e;
    }


    // Explicit constructors //

    /// <summary>
    /// Explicit construction of a `Result` with the `Ok` variant.
    /// </summary>
    public static Result<T, E> Ok(T t)
    {
        return new Result<T, E>(t);
    }

    /// <summary>
    /// Explicit construction of a `Result` with the `Err` variant.
    /// </summary>
    public static Result<T, E> Err(E e)
    {
        return new Result<T, E>(e);
    }

    
    // Convert to `Option`
    
    /// <summary>
    /// Converts the `Result` to an `Option`.
    /// </summary>
    public Option<T> ToOption()
    {
        return new Option<T>(OkObj, IsOk);
    }
    

    // Unwraps //

    public void Unwrap(Action<T> okCase, Action<E> errCase)
    {
        if (IsOk)
        {
            okCase(OkObj!);
            return;
        }

        errCase(ErrObj!);
    }

    public R Unwrap<R>(Func<T, R> okCase,
        Func<E, R> errCase)
    {
        return IsOk
            ? okCase(OkObj!)
            : errCase(ErrObj!);
    }
}

/// <summary>
/// Converts a throwable method into the `Result` type.
///
/// Useful for porting exceptions into `Result`s.
///
/// Use the Default constructor to construct this struct, then initialize it with the `TryCatch` method afterwards.
///
/// Failing to initialize the `FromMaybe` before reading the `Result` inside will throw.
///
/// If you want a total guarantee of no exceptions slipping through, let the `E` type be `Exception`.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Exception</typeparam>
public static class FromMaybe<T, E> where E : Exception
{
    // `TryCatch` methods which uses `Func` //

    public static Result<T, E> TryCatch(Func<T> maybe)
    {
        try
        {
            return new Result<T, E>(maybe());
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }
}