namespace preshow;

public static class SlideShow
{
    private static readonly Random rng = new();

    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < 500; i++)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }

    public static void InsertItems<T>(this IList<T> list, T item, int frequency)
    {
        int n = list.Count;
        for (int i = n; i > 0; i-=frequency)
        {
            list.Insert(i, item);
        }
    }
}
