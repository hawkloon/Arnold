using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal static class Utils
    {
        public static T PickRandom<T>(this T[] array)
        {
            var index = Random.Shared.Next(array.Length);
            return array[index];
        }

        public static T PickRandom<T>(this List<T> list)
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Cannot pick a random element from an empty list.");

            var index = Random.Shared.Next(list.Count);
            return list[index];
        }
    }
}
