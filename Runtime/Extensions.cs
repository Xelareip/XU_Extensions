using System.Collections.Generic;
using System.Linq;
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

        public static T PickRandom<T>(this IReadOnlyList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static int PickRandomWeight(this List<int> list)
        {
            int total = 0;
            foreach (int i in list)
            {
                total += i;
            }

            int rand = Random.Range(0, total);

            for (int i = 0; i < list.Count; ++i)
            {
                rand -= list[i];
				if (rand < 0)
				{
					return i;
				}
            }
			return list.Count - 1;
        }

        public static TV PickRandom<TK, TV>(this Dictionary<TK, TV> dictionary)
        {
            var key = dictionary.Keys.ToList()[Random.Range(0, dictionary.Keys.Count)];
            return dictionary[key];
        }

        public static void SmartDestroy(this GameObject gameObject)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(gameObject);
            }
            else
            {
                Object.DestroyImmediate(gameObject);
            }
        }
    }
}