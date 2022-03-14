using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Linear_Search_
{
    delegate bool binarySearchDelegate<T>(T[] arr, T key, out int idx, ref int numOfTries) where T : IComparable<T>;

    static class BinarySearch
    {
        /*
         * Complexity ->> O(log2(n)) : n = number of element in the list
         * in order to use Binary search the list must be already sorted
         * T must implements IComparable<T> so that the user can determine which field the comparsion will be about
         * Iterate using Loops
         * arr: is the generic list to search in
         * key: is the desired element
         * idx: the index at which the key was found , if not found it outs -1
         * numOfTries: the number of iterations till the key got reached
         * return: a boolean indicate whether the desired item was found or not
         */
        public static bool LoopBinarySearch<T>(T[] arr, T key, out int idx, ref int numOfTries) where T : IComparable<T>
        {
            idx = -1;
            bool found = false;
            int low = 0, high = arr.Length - 1, mid;
            while (!found)
            {
                if (low > high)
                {
                    break;
                }

                mid = (low + high) / 2;  // it is more likely to cause overflow than [low+(high-low)/2]
                
                if (key.CompareTo(arr[mid]) == 0)
                {
                    found = true;
                    idx = mid;
                }
                else if (key.CompareTo(arr[mid]) > 0)
                {
                    low = mid + 1;
                    numOfTries++;
                    continue;
                }
                else if (key.CompareTo(arr[mid]) < 0)
                {
                    high = mid - 1;
                    numOfTries++;
                    continue;
                }
            }
            return found;
        }


        /*
         * Complexity ->> O(log2(n)) : n = number of element in the list
         * in order to use Binary search the list must be already sorted
         * T must implements IComparable<T> so that the user can determine which field the comparsion will be about
         * Iterate using Recusion
         * arr: is the generic list to search in
         * key: is the desired element
         * idx: the index at which the key was found , if not found it outs -1
         * numOfTries: the number of iterations till the key got reached
         * return: a boolean indicate whether the desired item was found or not
         */
        public static bool RecursiveBinarySearch<T>(T[] arr, T key, out int idx, ref int numOfTries) where T : IComparable<T>
        {
            return RecursiveBinarySearch(arr, key, 0, arr.Length, out idx, ref numOfTries);
        }

        // a private overload for the previous method with additional low and high params
        private static bool RecursiveBinarySearch<T>(T[] arr, T key, int low, int high, out int idx, ref int numOfTries) where T : IComparable<T>
        {
            numOfTries++;
            idx = -1;
            int mid = (low + high) / 2;
            if (low > high)
            {
                return false;
            }
            else
            {
                if (key.CompareTo(arr[mid]) > 0)
                {
                    return RecursiveBinarySearch(arr, key, mid + 1, high, out idx, ref numOfTries);
                }
                else if (key.CompareTo(arr[mid]) < 0)
                {
                    return RecursiveBinarySearch(arr, key, low, mid - 1, out idx, ref numOfTries);
                }
                else
                {
                    idx = mid;
                    return true;
                }
            }
        }

        /*
         * arr: is the generic list to search in
         * key: is the desired element
         * idx: the index at which the key was found , if not found it outs -1
         * numOfTries: the number of iterations till the key got reached
         * ptr: is an instance of delegate that refers to a method that will do the search 
         * return: a boolean indicate whether the desired item was found or not
         */
        public static bool doBinarySearch<T>(T[] arr, T key, out int idx, ref int numOfTries, binarySearchDelegate<T> ptr)
            where T : IComparable<T>
        {
            return ptr(arr, key, out idx, ref numOfTries);
        }

    }
}
