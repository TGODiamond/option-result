﻿using System.Diagnostics.CodeAnalysis;
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
/// Note: Using the Default constructor, i.e. `new Result()` with no parameters, is forbidden and will throw.<br /><br />
/// Note: Using the `default` keyword to initialize this `Result` struct is forbidden.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Error</typeparam>
[Serializable]
public record struct Result<T, E>
{
    /// <summary>
    /// This bool exist to check if the `default` keyword was used to initialize the `Result`.
    /// </summary>
    private bool IsNotDefaultInit { get; }

    public bool IsOk { private set; get; }
    public bool IsErr => !IsOk;
    public T? OkObj { private set; get; }
    public E? ErrObj { private set; get; }

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

    // Setters //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetOk(in T okObj)
    {
        OkObj = okObj;
        IsOk = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetErr(in E errObj)
    {
        ErrObj = errObj;
        IsOk = false;
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

    // IfOkOrElse and co. //

    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R IfOkOrElse<R>(in R okCase, in R errCase)
    {
        return IsOk ? okCase : errCase;
    }

    // OutIfOk and co //

    /// <summary>
    /// Outs the contained `ok` value contained inside if the `Result` is `Ok`.
    /// </summary>
    /// <returns>Boolean to be used in an if-statement.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool OutIfOk([NotNullWhen(true)] out T? okObj)
    {
        if (IsOk)
        {
            okObj = OkObj;
#pragma warning disable CS8762 // Parameter must have a non-null value when exiting in some condition.
            return true;
#pragma warning restore CS8762 // Parameter must have a non-null value when exiting in some condition.
        }

        okObj = default;
        return false;
    }

    /// <summary>
    /// Outs the contained `err` value contained inside if the `Result` is `Err`.
    /// </summary>
    /// <returns>Boolean to be used in an if-statement.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool OutIfErr([NotNullWhen(true)] out E? errObj)
    {
        if (IsErr)
        {
            errObj = ErrObj;
#pragma warning disable CS8762 // Parameter must have a non-null value when exiting in some condition.
            return true;
#pragma warning restore CS8762 // Parameter must have a non-null value when exiting in some condition.
        }

        errObj = default;
        return false;
    }

    /// <summary>
    /// Outs the contained `ok` value contained inside if the `Result` is `Ok`.<br />
    /// Else, outs the `err` value.
    /// </summary>
    /// <returns>Boolean to be used in an if-statement.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool OutIfOkElseErr([NotNullWhen(true)] out T? okObj, [NotNullWhen(false)] out E? errObj)
    {
        if (IsOk)
        {
            okObj = OkObj!;
            errObj = default;
            return true;
        }

        okObj = default;
        errObj = ErrObj!;
        return false;
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
        if (IsErr) return GetErrObj();
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
        if (IsErr) return GetErrObj();
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