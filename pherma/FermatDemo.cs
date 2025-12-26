using System;

namespace FermatDemo;

public static class FermatChecker
{
    public static (int a, int b, int c)? FindCounterexample(int max, int n)
    {
        if (max < 1) throw new ArgumentOutOfRangeException(nameof(max));
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n));

        // Для n<=2 “контрпримеров” к ВТФ нет смысла искать — это не ВТФ,
        // но оставим поведение определённым: просто проверяем равенства.
        for (int a = 1; a <= max; a++)
            for (int b = 1; b <= max; b++)
                for (int c = 1; c <= max; c++)
                {
                    long left = Pow(a, n) + Pow(b, n);
                    long right = Pow(c, n);
                    if (left == right)
                        return (a, b, c);
                }

        return null;
    }

    public static long Pow(int x, int n)
    {
        long r = 1;
        for (int i = 0; i < n; i++) r *= x;
        return r;
    }
}

