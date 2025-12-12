using System;
using FermatDemo;

static int GetArgInt(string[] args, string name, int defaultValue)
{
    var prefix = $"--{name}=";
    foreach (var a in args)
        if (a.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(a[prefix.Length..], out var v))
            return v;
    return defaultValue;
}

var max = GetArgInt(args, "max", 25);
var n = GetArgInt(args, "n", 3);

Console.WriteLine($"Fermat demo check: searching for a^n + b^n = c^n with n={n}, 1..{max}");

var result = FermatChecker.FindCounterexample(max, n);

if (result is null)
{
    Console.WriteLine("No solutions found in the given range (demo check only).");
    return 0;
}

var (a, b, c) = result.Value;
Console.WriteLine($"Found equality in range: {a}^{n} + {b}^{n} = {c}^{n}")
return 1; // пусть CI сможет пометить как “неожиданно нашли”
