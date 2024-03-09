using System.Runtime.CompilerServices;

namespace OptionResult;

// Up to 13 slower than a try/catch on author's computer with the integer type.
// Much, MUCH faster than try/catch which caught an exception.

[Serializable]
internal sealed class ParameterlessConstructedResultException : Exception
{
    internal ParameterlessConstructedResultException(string message) : base(message)
    {
    }
}

[Serializable]
internal sealed class DefaultInitializedResultException : Exception
{
    internal DefaultInitializedResultException(string message) : base(message)
    {
    }
}

// PanicException
[Serializable]
internal sealed class ResultPanicException : Exception
{
    internal ResultPanicException(string message) : base(message)
    {
    }
}

/// <summary>
/// Either `Ok` which have an `ok` value or `Err` which have an "error" value.<br /><br />
/// 
/// Setting `T` as a nullable, aka. using the `?` operator, must never be used, especially where T is a value type.<br /><br />
/// 
/// `Result` is an alternative to exceptions.<br /><br />
///
/// If performance is ultra-critical, like in loops with many, many iterations, avoid calling any methods that use
/// delegates in their parameter(s), such as `Match`.<br /><br />
/// 
/// Note: Using the Default constructor, i.e. `new Result()` with no parameters, is forbidden and will throw.<br /><br />
/// Note: Using the `default` keyword to initialize this `Result` struct is forbidden.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Error</typeparam>
[Serializable]
public readonly record struct Result<T, E>
{
    // Keep the fields public, they're readonly anyways.

    /// <summary>
    /// This bool exist to check if the `default` keyword was used to initialize the `Result`.
    /// </summary>
    private bool IsNotDefaultInit { get; }

    public bool IsOk { get; }
    public bool IsErr => !IsOk;
    public T? OkObj { get; }
    public E? ErrObj { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private E GetErrObj()
    {
        if (!IsNotDefaultInit)
            throw new DefaultInitializedResultException(
                "The keyword `default` has been used to initialize this `Result`, which is forbidden.");

        return ErrObj!;
    }

    // Constructors //

    // Disallow default constructor
    [Obsolete(message: "Default constructor is forbidden on `Result` struct.")]
    public Result()
    {
        throw new ParameterlessConstructedResultException(
            "Constructing a `Result` without any parameters is forbidden. (Default constructor forbidden) " +
            "Use `new Result<T, E>(E)`, to return an Error.");
    }

    public Result(in T okObj)
    {
        OkObj = okObj;
        IsOk = true;

        IsNotDefaultInit = true;
    }

    public Result(in E errObj)
    {
        ErrObj = errObj;
        IsOk = false;

        IsNotDefaultInit = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Result(bool isOk, in T? t, in E? e)
    {
        IsOk = isOk;
        OkObj = t;
        ErrObj = e;

        IsNotDefaultInit = true;
    }

    // Explicit constructors //

    /// <summary>
    /// Explicit construction of a `Result` with the `Ok` variant.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<T, E> Ok(in T t)
    {
        return new Result<T, E>(t);
    }

    /// <summary>
    /// Explicit construction of a `Result` with the `Err` variant.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<T, E> Err(in E e)
    {
        return new Result<T, E>(e);
    }

    // Convert to `Option`

    /// <summary>
    /// Converts the `Result` into an `Option`.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Option<T> IntoOption()
    {
        return new Option<T>(IsOk, OkObj);
    }

    // Match //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Match(in Action<T> okCase, in Action<E> errCase)
    {
        if (IsOk)
        {
            okCase(OkObj!);
            return;
        }

        errCase(GetErrObj());
    }

    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R Match<R>(in Func<T, R> okCase, in Func<E, R> errCase)
    {
        return IsOk ? okCase(OkObj!) : errCase(GetErrObj());
    }

    // Type Conversion //

    /// <summary>
    /// Returns one type where both `T` and `E` can be converted to that type.<br /><br />
    ///
    /// Please use the type that both `T` and `E` is, in the type parameter.<br /><br />
    /// </summary>
    /// <typeparam name="R">Return Type</typeparam>
    /// <returns>Return type (a type which `T` and `E` can cast to)</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R Return<R>() where R : T, E
    {
        return IsOk ? (R)OkObj! : (R)GetErrObj()!;
    }

    // Alternatives //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T OkOrElse(in T alt)
    {
        return IsOk ? OkObj! : alt;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T OkOrElseRun(in Func<T> altFunc)
    {
        return IsOk ? OkObj! : altFunc();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public E ErrOrElse(in E alt)
    {
        return !IsOk ? GetErrObj() : alt;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public E ErrOrElseRun(in Func<T, E> altFunc)
    {
        return !IsOk ? GetErrObj() : altFunc(OkObj!);
    }

    // IfOkOrElse and co. //

    /// <summary>
    /// Even cheaper than a `Match()` that returns.
    /// </summary>
    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R IfOkOrElse<R>(in R okCase, in R errCase)
    {
        return IsOk ? okCase : errCase;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R RunIfOkOrElse<R>(in Func<T, R> okCase, in R errCase)
    {
        return IsOk ? okCase(OkObj!) : errCase;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R RunIfErrOrElse<R>(in Func<E, R> errCase, in R okCase)
    {
        return !IsOk ? errCase(GetErrObj()) : okCase;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RunIfOk(in Action<T> okCase)
    {
        if (IsOk) okCase(OkObj!);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RunIfErr(in Action<E> okCase)
    {
        if (!IsOk) okCase(GetErrObj());
    }

    // Unwraps //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Unwrap()
    {
        if (IsOk) return OkObj!;
        throw new ResultPanicException("Unwrap on a non-ok `Result`!");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public E UnwrapErr()
    {
        if (!IsOk) return GetErrObj();
        throw new ResultPanicException("Unwrap on a non-err `Result`!");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Expect(in string failMessage)
    {
        if (IsOk) return OkObj!;
        throw new ResultPanicException(failMessage);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public E ExpectErr(in string failMessage)
    {
        if (!IsOk) return GetErrObj();
        throw new ResultPanicException(failMessage);
    }

    // Porting methods //

    /// <summary>
    /// Converts a throwable method into the `Result` type.<br /><br />
    /// 
    /// Useful for porting exceptions into `Result`s.<br /><br />
    /// 
    /// If you want a total guarantee of no exceptions slipping through, let the `E` type be type `Exception`.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <typeparam name="E1">Exception</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<T, E1> TryCatch<E1>(in Func<T> maybe) where E1 : Exception
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<Option<T1>, E1> TryCatchFromNullable<T1, E1>(in Func<T1?> maybe)
        where T1 : struct where E1 : Exception
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<Option<T1>, E1> TryCatchFromNullable<T1, E1>(in Func<T1?> maybe)
        where T1 : class where E1 : Exception
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T OkOrThrowErr<TException>() where TException : Exception, E
    {
        return IsOk ? OkObj! : throw (TException)GetErrObj()!;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T OkOrThrowException<TException>(in TException exception) where TException : Exception
    {
        return IsOk ? OkObj! : throw exception;
    }
}