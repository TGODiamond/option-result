using System.Runtime.CompilerServices;

namespace OptionResult;

// Up to 13 slower than a null check on author's computer with the integer type.

// PanicException
[Serializable]
internal sealed class OptionPanicException : Exception
{
    internal OptionPanicException(string message) : base(message)
    {
    }
}

/// <summary>
/// Either `Some` which have a value or `None` which doesn't have a value.<br /><br />
///
/// Setting `T` as a nullable, aka. using the `?` operator, must never be used, especially where T is a value type.<br /><br />
///  
/// `Option` is an alternative to nulls.<br /><br />
///
/// If performance is ultra-critical, like in loops with many, many iterations, avoid calling any methods that use
/// delegates in their parameter(s), such as `Match`.
/// </summary>
/// <typeparam name="T">Type</typeparam>
[Serializable]
public readonly record struct Option<T>
{
    // Keep the fields public, they're readonly anyways.
    public bool IsSome { get; }
    public bool IsNone => !IsSome;
    public T? Obj { get; }

    // Constructors //

    /// <summary>
    /// Constructs a `Option` set to `None`, aka. an empty `Option`.
    /// </summary>
    public Option()
    {
        IsSome = false;
    }

    /// <summary>
    /// Constructs a `Option` set to `Some`, aka. an `Option` that contains a value.
    /// </summary>
    public Option(in T value)
    {
        Obj = value;
        IsSome = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Option(bool isSome, in T? t)
    {
        IsSome = isSome;
        Obj = t;
    }

    // Explicit constructors //

    /// <summary>
    /// Explicit construction of a `Option` with the `Some` variant.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Some(T value)
    {
        return new Option<T>(value);
    }

    /// <summary>
    /// Explicit construction of a `Option` with the `None` variant.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> None()
    {
        return new Option<T>();
    }

    // Convert to `Result`

    /// <summary>
    /// Converts the `Option` into a `Result, given a new `Err` type.
    /// </summary>
    /// <typeparam name="E">Error type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Result<T, E> IntoResult<E>(in E error)
    {
        return new Result<T, E>(IsSome, Obj, error);
    }

    // Match //

    /// <summary>
    /// Non-returning `Match`. The `someCase` action gets run if this `Result` is `Some`, returning the contained `Ok`
    /// value to that action.<br /><br />
    ///
    /// Else, noneCase gets run, returning the contained `Err` value.
    /// </summary>
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

    /// <summary>
    /// `Match` that returns `R`. The `someCase` function gets run if this `Result` is `Some`, returning the contained
    /// `Ok` value to that function.<br /><br />
    ///
    /// Else, noneCase gets run, returning the contained `Err` value.<br /><br />
    ///
    /// Both functions must return the same type, `R`.
    /// </summary>
    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R Match<R>(in Func<T, R> someCase, in Func<R> noneCase)
    {
        return IsSome ? someCase(Obj!) : noneCase();
    }

    // Alternatives //

    /// <summary>
    /// If the `Result` is `Some`, then this method returns the contained value inside the `Option`.
    /// Else, then this method returns the value in the parameter.<br /><br />
    ///
    /// The parameter's type must be the same as the contained value's type.<br /><br />
    ///
    /// This method can surely be used in performance critical situations.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T SomeOrElse(in T alt)
    {
        return IsSome ? Obj! : alt;
    }

    /// <summary>
    /// Just like the `SomeOrElse()` method, but the parameter is lazily evaluated.
    /// This method only runs given method inside the parameter if the `Option` is `None`.<br /><br />
    ///
    /// Note: Just because the function in the parameter is lazily evaluated doesn't mean this method is performant.<br /><br />
    ///
    /// For critical performance, use the `SomeOrElse` method instead. Only if the code in the delegate itself does
    /// something expensive should this method be used in performance critical situations.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T SomeOrElseRun(in Func<T> altFunc)
    {
        return IsSome ? Obj! : altFunc();
    }

    // IfSomeOrElse and co. //

    /// <summary>
    /// Returns back the first parameter, `someCase`, if the `Option` is `Some`.
    /// Else, the second parameter, `noneCase`, is returned back.<br /><br />
    ///
    /// Both parameters must be of one, shared type.<br /><br />
    /// 
    /// Use this method if you don't need to read the contained value.<br /><br />
    ///
    /// This method can surely be used in performance critical situations.
    /// </summary>
    /// <typeparam name="R">Return Type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R IfSomeOrElse<R>(in R someCase, in R noneCase)
    {
        return IsSome ? someCase : noneCase;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public R RunIfSomeOrElse<R>(in Func<T, R> someCase, in R noneCase)
    {
        return IsSome ? someCase(Obj!) : noneCase;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RunIfSome(in Action<T> someCase)
    {
        if (IsSome) someCase(Obj!);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RunIfNone(in Action noneCase)
    {
        if (!IsSome) noneCase();
    }

    // Unwraps //

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Unwrap()
    {
        if (IsSome) return Obj!;
        throw new ResultPanicException("Unwrap on a non-ok `Result`!");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Expect(in string failMessage)
    {
        if (IsSome) return Obj!;
        throw new ResultPanicException(failMessage);
    }

    // Porting methods //

    /// <summary>
    /// Just like a `FromMaybe`, but for methods that return `void`.<br /><br />
    ///
    /// Use the Default constructor to construct this struct, then initialize it with the `TryCatch` method afterwards.<br /><br />
    ///
    /// Returns `Some(E)` if the method passed threw with exception `E`.<br /><br />
    ///
    /// Returns `None` if no exception was caught.
    /// </summary>
    /// <typeparam name="E">Exception</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T1> FromNullable<T1>(in T1? nullableValue) where T1 : struct
    {
        return nullableValue is not null ? new Option<T1>(nullableValue.Value) : new Option<T1>();
    }

    /// <summary>
    /// Converts a nullable reference type into a non-nullable `Option`.
    /// </summary>
    /// <typeparam name="T1">Type (same as `T`)</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T1> FromNullable<T1>(in T1? nullableValue) where T1 : class
    {
        return nullableValue is not null ? new Option<T1>(nullableValue) : new Option<T1>();
    }

    /// <summary>
    /// A more clear way to represent `Option.Obj`.
    /// </summary>
    /// <returns>Nullable Type</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? ToNullable()
    {
        return Obj;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void NoneOrThrowSome<TException>() where TException : Exception, T
    {
        if (IsSome) throw (TException)Obj!;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T SomeOrThrowException<TException>(TException exception) where TException : Exception
    {
        return IsSome ? Obj! : throw exception;
    }
}