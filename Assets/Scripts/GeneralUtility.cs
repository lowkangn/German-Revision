using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public static class GeneralUtility
{
    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static List<T> CopyList<T>(this IList<T> list)
    {
        List<T> copy = new List<T>();

        foreach (T item in list)
        {
            copy.Add(item);
        }
        return copy;
    }
}
