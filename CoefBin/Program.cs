ulong CoefBinomialOpti(int n, int k)
{
    if (n >= 0 && k >= 0)
	{
        if (k < n)
            return factorialPQ(k + 1, n) / factorial(n - k);
        else if (k == n)
            return 1;
        else
            return 0;
    }
    else
        return 0;
}

ulong CoefBinomial(int n, int k)
{
    if (n >= 0 && k >= 0 && k <= n)
        return factorial(n) / (factorial(k) * factorial(n - k));
    else
        return 0;
}

ulong factorial(int x)
{
    ulong result = 1;
    while (x > 1)
    {
        result *= (ulong)x;
        x--;
    }

    return result;
}

ulong factorialPQ(int p, int q)
{
    if (p > q || p == 0)
        throw new Exception();

    ulong result = (ulong)p;
    while (q > p)
	{
        result *= (ulong)q;
        q--;
	}

    return result;
}

Console.WriteLine("Enter n");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("Enter k");
int k = int.Parse(Console.ReadLine());

Console.WriteLine(CoefBinomial(n, k));