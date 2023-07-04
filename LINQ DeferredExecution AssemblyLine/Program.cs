using System;
using System.Collections;
using System.Collections.Generic;

// ref link: https://www.youtube.com/watch?v=3P9nDHJMWqI&list=PL90AF0EFFEF782D27&index=13
// Deferred Execution - exist because of Yield statement

static class MainClass
{
    static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gauntlet)
    {
        Console.WriteLine("Where");
        foreach (T item in items)
            if (gauntlet(item))
                yield return item;
    }
    static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
    {
        Console.WriteLine("Select");
        foreach (T item in items)
            yield return transform(item);
    }
    static void Main()
    {
        int[] stuff = { 4, 13, 8, 1, 9 };
        IEnumerable<string> result = 
            stuff
            .Where(i => i < 10)
            .Where(i => 4 < i)
            .Select(i => i * 3)
            .Where(i => i % 2 == 0) // even
            .Select(i => i + "Jamie");
        IEnumerable<string> rator = result.GetEnumerator();
        while(rator.MoveNext())
            Console.WriteLine(rator.Current);

    }
}