using System.Diagnostics;
using OptionResult;

var timer0 = new Stopwatch();

timer0.Reset();
timer0.Start();

for (long i = 0; i <= 10_000_000_000 - 1; i++)
{
    int? myNullableInteger = null;

    if (myNullableInteger switch
        {
            not null => true,
            null => false
        })
        throw new Exception("Got wrong string");
}

timer0.Stop();
Console.WriteLine(timer0);

timer0.Reset();
timer0.Start();

for (long i = 0; i <= 10_000_000_000 - 1; i++)
{
    var myOption = new Option<int>();

    bool resultBool = myOption.IfSomeOrElse(true, false);

    if (resultBool) throw new Exception("Got wrong string");
}

timer0.Stop();
Console.WriteLine(timer0);

// Time for error benchmarks!

timer0.Reset();
timer0.Start();

for (long i = 0; i <= 10_000_000_000 - 1; i++)
{
    bool res0;

    try
    {
        res0 = true;
    }
    catch (Exception)
    {
        res0 = false;
    }

    if (res0 != true) throw new Exception();
}

timer0.Stop();
Console.WriteLine(timer0);

timer0.Reset();
timer0.Start();

for (long i = 0; i <= 10_000_000_000 - 1; i++)
{
    var myOptInt = Result<uint, uint>.Ok(2024);

    var res = myOptInt.Return<uint>();

    if (res != 2024) throw new Exception("Got wrong integer");
}

timer0.Stop();
Console.WriteLine(timer0);