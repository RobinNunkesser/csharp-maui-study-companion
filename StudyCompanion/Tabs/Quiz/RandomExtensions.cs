using System;
namespace Italbytz.Extensions;

public static class RandomExtensions
{
    public static void Shuffle<T>(this Random rand, T[] items)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int num = rand.Next(i, items.Length);
            T val = items[i];
            items[i] = items[num];
            items[num] = val;
        }
    }
}

