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
            "Use `new Result<T, E>(E)` instead."
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


    // Unwraps that return //

    public TResult Unwrap<TResult>(Func<T, TResult> okCase, Func<E, TResult> errCase)
    {
        return IsOk switch
        {
            true => okCase(OkObj!),
            false => errCase(ErrObj!),
        };
    }

    public TResult Unwrap<TResult,
        TArg
    >
    (
        Func<T,
            TArg,
            TResult
        > okCase,
        Func<E,
            TArg,
            TResult> errCase,
        TArg arg
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg
            ),
            false => errCase(ErrObj!,
                arg
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2
    >
    (
        Func<T,
            TArg1, TArg2,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2
            ),
            false => errCase(ErrObj!,
                arg1, arg2
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3
    >
    (
        Func<T,
            TArg1, TArg2, TArg3,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
            ),
        };
    }

    public TResult Unwrap<TResult,
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15
    >
    (
        Func<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15,
            TResult
        > okCase,
        Func<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15,
            TResult> errCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        return IsOk switch
        {
            true => okCase(OkObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
            ),
            false => errCase(ErrObj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
            ),
        };
    }


    // Unwraps that does not return //

    public void Unwrap(Action<T> okCase, Action<E> errCase)
    {
        switch (IsOk)
        {
            case true:
                okCase(OkObj!);
                break;

            case false:
                errCase(ErrObj!);
                break;
        }
    }

    public void Unwrap<
        TArg
    >
    (
        Action<T,
            TArg
        > someCase,
        Action<E,
            TArg
        > noneCase,
        TArg arg
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2
    >
    (
        Action<T,
            TArg1, TArg2
        > someCase,
        Action<E,
            TArg1, TArg2
        > noneCase,
        TArg1 arg1, TArg2 arg2
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3
    >
    (
        Action<T,
            TArg1, TArg2, TArg3
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
                );
                break;
        }
    }

    public void Unwrap<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15
    >
    (
        Action<T,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15
        > someCase,
        Action<E,
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        switch (IsOk)
        {
            case true:
                someCase(OkObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
                );
                break;

            case false:
                noneCase(ErrObj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
                );
                break;
        }
    }
}

/// <summary>
/// Converts a throwable method into the `Result` type.
///
/// Useful for porting exceptions into results.
///
/// Use the Default constructor to construct this struct, then initialize it with the `TryCatch` method afterwards.
///
/// Failing to initialize the `FromMaybe` before reading the `Result` inside will throw.
///
/// If you want a total guarantee of no exceptions slipping through, let the `E` type be `Exception`.
/// </summary>
/// <typeparam name="T">Type</typeparam>
/// <typeparam name="E">Error</typeparam>
public readonly record struct FromMaybe<T, E> where E : Exception
{
    // Use the default constructor, then do the actual initialization (Constructors are very limited with generics...)


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

    public static Result<T, E> TryCatch<
        TArg
    >
    (
        Func<
            TArg,
            T> maybe,
        TArg arg
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2
    >
    (
        Func<
            TArg1, TArg2,
            T> maybe,
        TArg1 arg1, TArg2 arg2
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3
    >
    (
        Func<
            TArg1, TArg2, TArg3,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }

    public static Result<T, E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15,
        TArg16
    >
    (
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15, TArg16,
            T> maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16
    )
    {
        try
        {
            return new Result<T, E>(maybe(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16
            ));
        }
        catch (E e)
        {
            return new Result<T, E>(e);
        }
    }
}