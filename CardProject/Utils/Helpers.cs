using System;
using System.Collections.Generic;

namespace CardProject.Utils
{
    public static class Helpers
    {
        //Code found here - used the most performant answer: http://stackoverflow.com/questions/1014292/concatenate-integers-in-c-sharp
        internal static int ConcatInt(int a, int b)
        {
            if (b < 10) return 10 * a + b;

            return 100 * a + b;
        }

        //Enum code found here: http://stackoverflow.com/questions/972307/can-you-loop-through-all-enum-values
        internal static IReadOnlyList<T> GetEnumValues<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}