using System.Runtime.CompilerServices;

namespace OptionResult;

internal sealed class ParameterlessConstructedResultException : Exception
{
    internal ParameterlessConstructedResultException(string message)
        : base(message)
    {
    }
}

/// <summary>
/// Either `Ok` which have an "ok" value or `Err` which have an "error" value.
///
/// Note: Using the Default constructor, i.e. `new Result()` with no parameters, is forbidden and will throw.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Error</typeparam>
public readonly record struct Result<T, E>
{
    // Keep the fields public, they're readonly anyways.
    public bool IsOk { get; }
    public T? OkObj { get; }
    public E? ErrObj { get; }


    // Constructors //

    // Disallow default constructor
    [Obsolete(message: "Default constructor is forbidden on `Result` struct.")]
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

    internal Result(bool isOk, T? t, E? e)
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
    /// Converts the `Result` into an `Option`.
    /// </summary>
    public Option<T> IntoOption()
    {
        return new Option<T>(IsOk, OkObj);
    }
    

    // Match //

    public void Match(in Action<T> okCase, in Action<E> errCase)
    {
        if (IsOk)
        {
            okCase(OkObj!);
            return;
        }

        errCase(ErrObj!);
    }
    
    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R Match<R>(in Func<T, R> okCase, in Func<E, R> errCase)
    {
        return IsOk ? okCase(OkObj!) : errCase(ErrObj!);
    }
    
    
    // Type Conversion //

    /// <summary>
    /// Returns one type where both `T` and `E` can be converted to that type.
    /// </summary>
    /// <typeparam name="R">Return Type (both `T` and `E`, since they are the same)</typeparam>
    /// <returns>Return type (a type which `T` and `E` can cast to)</returns>
    public R Return<R>()
        where R : T, E
    {
        return IsOk ? (R)OkObj! : (R)ErrObj!;
    }
    
    
    // Porting methods

    /// <summary>
    /// Converts a throwable method into the `Result` type.
    /// 
    /// Useful for porting exceptions into `Result`s.
    /// 
    /// If you want a total guarantee of no exceptions slipping through, let the `E` type be type `Exception`.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <typeparam name="E1">Exception</typeparam>
    public static Result<T, E1> TryCatch<E1>(in Func<T> maybe) 
        where E1 : Exception
    {
        try
        {
            return new Result<T, E1>(maybe());
        }
        catch (E1 e)
        {
            return new Result<T, E1>(e);
        }
    }

    /// <summary>
    /// Just like a `TryCatch()`, but also converts the returning nullable value type into a non-nullable `Option`
    /// encapsulated within the `Ok` variant of the `Result`.
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T1">Type (same as `T`)</typeparam>
    /// <typeparam name="E1">Exception (same as `E`)</typeparam>
    public static Result<Option<T1>, E1> TryCatchFromNullable<T1, E1>(in Func<T1?> maybe)
        where T1 : struct
        where E1 : Exception
    {
        try
        {
            var nullable = maybe();
            var option = nullable switch
            {
                not null => new Option<T1>(nullable.Value),
                null => new Option<T1>()
            };
            return new Result<Option<T1>, E1>(option);
        }
        catch (E1 e)
        {
            return new Result<Option<T1>, E1>(e);
        }
    }
    
    /// <summary>
    /// Just like a `TryCatch()`, but also converts the returning nullable reference type into a non-nullable `Option`
    /// encapsulated within the `Ok` variant of the `Result`.
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T1">Type (same as `T`)</typeparam>
    /// <typeparam name="E1">Exception (same as `E`)</typeparam>
    public static Result<Option<T1>, E1> TryCatchFromNullable<T1, E1>(in Func<T1?> maybe)
        where T1 : class
        where E1 : Exception
    {
        try
        {
            var nullable = maybe();
            var option = nullable switch
            {
                not null => new Option<T1>(nullable),
                null => new Option<T1>()
            };
            return new Result<Option<T1>, E1>(option);
        }
        catch (E1 e)
        {
            return new Result<Option<T1>, E1>(e);
        }
    }
}
