namespace Yannik.LangLearn.Blazor.Extentions
{
    // https://stackoverflow.com/a/5383533/6383213
    public static class ListExtentions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
