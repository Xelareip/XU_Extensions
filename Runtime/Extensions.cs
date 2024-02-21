using System.Collections.Generic;
using UnityEngine;

namespace Xelareip
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static void Randomize<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                int rand = Random.Range(i, list.Count);
                (list[i], list[rand]) = (list[rand], list[i]);
            }
        }

        public static T PickRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}