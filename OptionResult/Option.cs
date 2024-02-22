using System.Runtime.CompilerServices;

namespace OptionResult;

// Up to 13 slower than a null check on author's computer with the integer type.

/// <summary>
/// Either `Some` which have a value or `None` which doesn't have a value.
/// </summary>
/// <typeparam name="T">Type</typeparam>
public readonly record struct Option<T>
{
    // Keep the fields public, they're readonly anyways.
    public bool IsSome { get; }
    public T? Obj { get; }

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

    internal Option(bool isSome, T? t)
    {
        IsSome = isSome;
        Obj = t;
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

    // Convert to `Result`

    /// <summary>
    /// Converts the `Option` into a `Result`.
    /// </summary>
    public Result<T, E> IntoResult<E>(E error)
    {
        return new Result<T, E>(IsSome, Obj, error);
    }

    // Match //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Match(in Action<T> someCase, in Action noneCase)
    {
        if (IsSome)
        {
            someCase(Obj!);
            return;
        }

        noneCase();
    }

    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R Match<R>(in Func<T, R> someCase, in Func<R> noneCase)
    {
        return IsSome ? someCase(Obj!) : noneCase();
    }

    // Alternatives //

    /// <summary>
    /// If `Some`, then this method returns the contained value inside the `Option`.
    /// If `None`, then the method returns the value in the parameter.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T SomeOr(in T alt)
    {
        return IsSome ? Obj! : alt;
    }

    /// <summary>
    /// Just like the `SomeOr()` method, but the parameter is lazily evaluated.
    /// This method only runs given method inside the parameter if the `Option` is `None`.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T SomeOrElse(in Func<T> altFunc)
    {
        return IsSome ? Obj! : altFunc();
    }

    // Porting methods //

    /// <summary>
    /// Just like a `FromMaybe`, but for methods that return `void`.
    ///
    /// Use the Default constructor to construct this struct, then initialize it with the `TryCatch` method afterwards.
    ///
    /// Returns `Some(E)` if the method passed threw with exception `E`.
    ///
    /// Returns `None` if no exception was caught.
    /// </summary>
    /// <typeparam name="E">Exception</typeparam>
    public static Option<E> TryCatch<E>(in Action maybe) where E : Exception
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

    /// <summary>
    /// Converts a nullable value type into a non-nullable `Option`.
    /// </summary>
    /// <typeparam name="T1">Type (same as `T`)</typeparam>
    public static Option<T1> FromNullable<T1>(T1? nullableValue) where T1 : struct
    {
        return nullableValue is not null ? new Option<T1>(nullableValue.Value) : new Option<T1>();
    }

    /// <summary>
    /// Converts a nullable reference type into a non-nullable `Option`.
    /// </summary>
    /// <typeparam name="T1">Type (same as `T`)</typeparam>
    public static Option<T1> FromNullable<T1>(T1? nullableValue) where T1 : class
    {
        return nullableValue is not null ? new Option<T1>(nullableValue) : new Option<T1>();
    }
}