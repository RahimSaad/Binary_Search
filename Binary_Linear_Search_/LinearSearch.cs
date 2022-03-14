using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Binary_Linear_Search_
{
    static class LinearSearch
    {
        /*
         * Complexity ->> O(n) : n = number of element in the list
         * T must implements IComparable<T> so that the user can determine which field the comparsion will be about
         * Iterate using Loops
         * arr: is the generic list to search in
         * key: is the desired element
         * idx: the index at which the key was found , if not found it outs -1
         * return: a boolean indicate whether the desired item was found or not
         */
        public static bool doLinearSearch<T>(T[] arr, T key, out int idx) where T : IComparable<T>
        {
            idx = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (key.CompareTo(arr[i]) == 0)
                {
                    idx = i;
                    return true;
                }
            }
            return false;
        }
    }
}
