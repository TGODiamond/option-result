namespace OptionResult;

/// <summary>
/// Either `Some` or `None`
/// </summary>
/// <typeparam name="T">Type</typeparam>
public readonly struct Option<T>
{
    public readonly bool IsSome;
    public readonly T? Obj;


    // Constructors //

    public Option()
    {
        IsSome = false;
    }

    public Option(T some)
    {
        Obj = some;
        IsSome = true;
    }

    public Option(T? intoOption, out bool isNull)
    {
        switch (intoOption)
        {
            case not null:
                Obj = intoOption;
                IsSome = true;
                isNull = false;

                break;
            case null:
                IsSome = false;
                isNull = true;

                break;
        }
    }


    // General Methods //

    // public bool IsInit()
    // {
    //     return _t switch
    //     {
    //         not null => true,
    //        null => false,
    //     };
    // }


    // Unwraps that return //

    public TResult Unwrap<TResult>(Func<T, TResult> someCase, Func<TResult> noneCase)
    {
        return IsSome switch
        {
            true => someCase(Obj!),
            false => noneCase(),
        };
    }

    public TResult Unwrap<TResult,
        TArg
    >
    (
        Func<T,
            TArg,
            TResult
        > someCase,
        Func<
            TArg,
            TResult> noneCase,
        TArg arg
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4
            ),
            false => noneCase(
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
        > someCase,
        Func<TResult> noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
            ),
            false => noneCase(
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
        > someCase,
        Func<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15,
            TResult
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        return IsSome switch
        {
            true => someCase(Obj!,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
            ),
            false => noneCase(
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
            ),
        };
    }


    // Unwraps that does not return //

    public void Unwrap(Action<T> someCase, Action noneCase)
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!);
                break;

            case false:
                noneCase();
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
        Action<
            TArg
        > noneCase,
        TArg arg
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2
        > noneCase,
        TArg1 arg1, TArg2 arg2
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
                );
                break;

            case false:
                noneCase(
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
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15
        > noneCase,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        switch (IsSome)
        {
            case true:
                someCase(Obj!,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
                );
                break;

            case false:
                noneCase(
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
                );
                break;
        }
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
public readonly struct FromMaybeVoid<E> where E : Exception
{
    // Use the default constructor, then do the actual initialization (Constructors are very limited with generics...)


    // `TryCatch` methods which uses `Action` //

    public Option<E> TryCatch(Action maybe)
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

    public Option<E> TryCatch<
        TArg
    >
    (
        Action<
            TArg
        > maybe,
        TArg arg
    )
    {
        try
        {
            maybe(arg);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2
    >
    (
        Action<
            TArg1, TArg2
        > maybe,
        TArg1 arg1, TArg2 arg2
    )
    {
        try
        {
            maybe(arg1, arg2);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3
    >
    (
        Action<
            TArg1, TArg2, TArg3
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3
    )
    {
        try
        {
            maybe(arg1, arg2, arg3);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }

    public Option<E> TryCatch<
        TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15,
        TArg16
    >
    (
        Action<
            TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14,
            TArg15, TArg16
        > maybe,
        TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9,
        TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16
    )
    {
        try
        {
            maybe(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15,
                arg16);
            return new Option<E>();
        }
        catch (E e)
        {
            return new Option<E>(e);
        }
    }
}