using System.Collections.Generic;

namespace CardProject.Utils
{
    internal static class Extensions
    {
        //Borrowed from here: http://stackoverflow.com/questions/2094239/swap-two-items-in-listt
        //This will let me swap any two items in any list - yay generics!
        internal static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}