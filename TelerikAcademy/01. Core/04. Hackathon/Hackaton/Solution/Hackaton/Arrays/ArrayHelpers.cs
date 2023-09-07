using System;

namespace Hackaton
{
    public class ArrayHelpers
    {
        /// <summary>
        /// Adds the int element at the start of the array source.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="element">The element to add</param>
        /// <returns>A new array that has all the elements from the original array and the added element at head position.</returns>
        /// <author>Kiril Stanoev</author>
        public static int[] AddFirst(int[] source, int element)
        {
            var newArray = new int[source.Length + 1];

            CopyFrom(source, 0, newArray, 1, source.Length);
            newArray[0] = element;
            return newArray;
        }

        /// <summary>
        /// Adds the int <c>element</c> to the end of the array <c>source</c>.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="element">The element to add</param>
        /// <returns>A new array that has all the elements from the original array and the added <c>element</c> at the end.</returns>
        public static int[] AddLast(int[] source, int element)
        {
            var newLength = source.Length + 1;
            var newArray = new int[newLength];

            Copy(source, newArray, newLength);

            newArray[newArray.Length - 1] = element;
            return newArray;
        }

        /// <summary>
        /// Adds all <c>elements</c> to the end of <c>source</c>.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="elements">The array of elements to add</param>
        /// <returns>A new array, the original array with all elements at the end.</returns>
        public static int[] AppendAll(int[] source, int[] elements)
        {
            var newElementsCount = elements.Length;
            if (newElementsCount == 0)
                return source;

            var newArray = new int[source.Length + newElementsCount];

            Copy(source, newArray, source.Length);

            for (int i = source.Length, j = 0; i < newArray.Length; i++, j++)
            {
                newArray[i] = elements[j];
            }
            return newArray;
        }

        /// <summary>
        /// Inserts <c>element</c> at given <c>index</c> in <c>source</c> array.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="index">The index to insert at</param>
        /// <param name="element">The element to insert</param>
        /// <returns>A new array with the <c>element</c> in it.</returns>
        public static int[] InsertAt(int[] source, int index, int element)
        {
            if (index == 0)
                return AddFirst(source, element);
            if (index == source.Length)
                return AddLast(source, element);

            var newArray = new int[source.Length  + 1];

            CopyFrom(source, 0, newArray, 0, index);

            newArray[index] = element;

            var newStartPosition = source.Length - index - 1;
            CopyFrom(source, newStartPosition, newArray, index + 1, source.Length  - 1);

            return newArray;
        }

        /// <summary>
        /// Checks if source contains element.
        /// </summary>
        /// <param name="source">The array to check in</param>
        /// <param name="element">The element to check ford</param>
        /// <returns><c>true</c> if <c>source</c> contains <c>element</c>, otherwise <c>false</c>.</returns>
        public static bool Contains(int[] source, int element)
        {
            return FirstIndexOf(source, element) != -1;
        }

        /// <summary>
        /// Copies <c>count</c> elements from <c>sourceArray</c> into <c>destinationArray</c>.
        /// </summary>
        /// <param name="sourceArray">The array to copy from</param>
        /// <param name="destinationArray">The array to copy to</param>
        /// <param name="count">The number of elements to copy</param>
        public static void Copy(int[] sourceArray, int[] destinationArray, int count)
        {
            var minLength = Math.Min(sourceArray.Length, count);

            for (int i = 0; i < minLength; i++)
            {
                destinationArray[i] = sourceArray[i];
            }
        }

        /// <summary>
        /// Copies elements from <c>sourceArray</c>, starting from <c>sourceStartIndex</c> 
        /// into <c>destinationArray</c>, starting from <c>destStartIndex</c>, taking <c>count</c> elements.
        /// </summary>
        /// <param name="sourceArray">The array to copy from</param>
        /// <param name="sourceStartIndex">The starting index in sourceArray</param>
        /// <param name="destinationArray">The array to copy to</param>
        /// <param name="destStartIndex">The starting index in destinationArray</param>
        /// <param name="count">The number of elements to copy</param>
        public static void CopyFrom(int[] sourceArray, int sourceStartIndex, int[] destinationArray, int destStartIndex, int count)
        {
            if (sourceArray.Length == 0)
                return;
            if (count > sourceArray.Length)
                return;

            var minLength = Math.Min(sourceArray.Length, count) + destStartIndex;

            for (int i = destStartIndex, j = sourceStartIndex; i < minLength; i++, j++)
            {
                destinationArray[i] = sourceArray[j];
            }
        }

        /// <summary>
        /// Fills <c>source</c> with <c>element</c>.
        /// </summary>
        /// <param name="source">The array to fill</param>
        /// <param name="element">The element to fill with</param>
        public static void Fill(int[] source, int element)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = element;
            }
        }

        /// <summary>
        /// Finds the first index of <c>target</c> within <c>source</c>.
        /// </summary>
        /// <param name="source">The array to check in</param>
        /// <param name="target ">The element to check for</param>
        /// <returns>The first index of <c>target</c> within <c>source</c>, otherwise, -1.</returns>
        public static int FirstIndexOf(int[] source, int target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds the last index of <c>target</c> within <c>source</c>.
        /// </summary>
        /// <param name="source">The array to check in</param>
        /// <param name="target ">The element to check for</param>
        /// <returns>The last index of <c>target</c> within <c>source</c>, otherwise, -1.</returns>
        public static int LastIndexOf(int[] source, int target)
        {
            var lastIndex = -1;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                    lastIndex = i;
            }

            return lastIndex;
        }

        /// <summary>
        /// Checks if index is a valid index in source.
        /// </summary>
        /// <param name="source">The array to check against</param>
        /// <param name="index">The index to check for</param>
        /// <returns>true if index is valid, otherwise, false.</returns>
        public static bool IsValidIndex(int[] source, int index)
        {
            return index >= 0 && index < source.Length;
        }

        /// <summary>
        /// Removes all occurrences of element within шге source array.
        /// </summary>
        /// <param name="source">The array to remove from</param>
        /// <param name="element">The element to check for</param>
        /// <returns>A new array with all occurences of element removed.</returns>
        public static int[] RemoveAllOccurrences(int[] source, int element)
        {
            var i = 0;

            for (var j = 0; j < source.Length; j++)
            {
                if (source[j] != element)
                {
                    source[i] = source[j];
                    i++;
                }
            }

            return Section(source, 0, i - 1);
        }

        /// <summary>
        /// Reverses <c>arrayToReverse</c>.
        /// </summary>
        /// <param name="arrayToReverse ">The array to fill</param>
        public static void Reverse(int[] arrayToReverse)
        {
            for (int i = 0; i < arrayToReverse.Length / 2; i++)
            {
                int temp = arrayToReverse[i];
                arrayToReverse[i] = arrayToReverse[arrayToReverse.Length - i - 1];
                arrayToReverse[arrayToReverse.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Returns a new array, from source, starting from startIndex and until endIndex.
        /// </summary>
        /// <param name="source">The array to create the new array from</param>
        /// <param name="startIndex ">The starting index</param>
        /// <param name="endIndex">The end index</param>
        /// <returns>A new array with all occurences of element removed.</returns>
        public static int[] Section(int[] source, int startIndex, int endIndex)
        {
            if (source.Length == 0)
                return source;
            if (startIndex > source.Length)
                return source;
            if (endIndex > source.Length)
                endIndex = source.Length - 1;

            var newArrayLength = endIndex - startIndex + 1;
            var newArray = new int[newArrayLength];

            CopyFrom(source, startIndex, newArray, 0, newArrayLength);

            return newArray;
        }
    }
}
