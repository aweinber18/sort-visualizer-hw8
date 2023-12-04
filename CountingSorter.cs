using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class CountingSorter<T> : Sorter<T> where T : IComparable<T>
{
    public void Sort(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length <= 1)
        {
            return; // Array is already sorted
        }

        // Find the maximum and minimum values in the array
        T max = array[0];
        T min = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(max) > 0)
            {
                max = array[i];
            }
            else if (array[i].CompareTo(min) < 0)
            {
                min = array[i];
            }
        }

        // Create a counting array to store the count of each element
        int range = Convert.ToInt32(max) - Convert.ToInt32(min) + 1;
        int[] countArray = new int[range];

        // Count the occurrences of each element in the array
        for (int i = 0; i < array.Length; i++)
        {
            countArray[Convert.ToInt32(array[i]) - Convert.ToInt32(min)]++;
        }

        // Update the array with the sorted values
        int index = 0;
        for (int i = 0; i < range; i++)
        {
            while (countArray[i] > 0)
            {
                array[index] = (T)Convert.ChangeType(i + Convert.ToInt32(min), typeof(T));
                index++;
                countArray[i]--;
            }
        }
    }
}