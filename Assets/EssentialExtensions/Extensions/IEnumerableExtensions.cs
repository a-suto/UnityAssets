using System;
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.Shuffle(new Random());

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
    {
        var shuffledItems = source.ToArray();
        var n = shuffledItems.Length;

        while (1 < n)
        {
            n--;
            var k = random.Next(n + 1);
            var tmp = shuffledItems[k];
            shuffledItems[k] = shuffledItems[n];
            shuffledItems[n] = tmp;
        }

        return shuffledItems;
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var obj in source)
        {
            action(obj);
        }

        return source;
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        var index = 0;

        foreach (var obj in source)
        {
            action(obj, index++);
        }

        return source;
    }

    public static bool IsEmpty<T>(this IEnumerable<T> source) => (source.Any() == false);
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => (source == null) || source.IsEmpty();

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return _Repeat(source);
    }

    private static IEnumerable<T> _Repeat<T>(this IEnumerable<T> source)
    {
        using (var enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext() == false) yield break;
            yield return enumerator.Current;

            while (enumerator.MoveNext()) yield return enumerator.Current;
        }

        while (true)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext()) yield return enumerator.Current;
            }
        }
    }
}
