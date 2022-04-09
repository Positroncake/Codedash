namespace codedash.Client.Data;

public static class LinqExtensions
{
    public static IEnumerable<R> Collect<R, A, T>(this IEnumerable<T> obj, A initial, Func<A, T, (R, A)> acc)
    {
        A tmp = initial;
        foreach (T i in obj)
        {
            R res;
            (res, tmp) = acc(tmp, i);
            yield return res;
        }
    }
}

public static class ListExtensions
{
    // Thanks to the guy on StackOverflow:
    // https://stackoverflow.com/questions/12231569/is-there-in-c-sharp-a-method-for-listt-like-resize-in-c-for-vectort
    public static void Resize<T>(this List<T> list, int size, T filler)
    {
        int cur = list.Count;
        if(size < cur)
            list.RemoveRange(size, cur - size);
        else if(size > cur)
        {
            if(size > list.Capacity)//this bit is purely an optimisation, to avoid multiple automatic capacity changes.
                list.Capacity = size;
            list.AddRange(Enumerable.Repeat(filler, size - cur));
        }
    }
    public static void Resize<T>(this List<T> list, int sz) where T : new()
    {
        Resize(list, sz, new T());
    }
}