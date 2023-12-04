using Sorting_Visualization;
using System;
using System.Collections.Generic;

public class QuickSorter<T> : Sorter<T> where T : IComparable<T>
{
    private SortVisualizer sortVisualizer;
	public QuickSorter(SortVisualizer sv)
	{
        sortVisualizer = sv;
	}

    public void Sort(T[] array)
    {
        Partition(array, 0, array.Length - 1);
    }

    private void Partition(T[] array, int low, int high)
    {
        int i = low;
        int j = high;
        T pivot = array[high];
        while (array[i].CompareTo(pivot) < 0 && i <= j)
            i++;
        while (array[j].CompareTo(pivot) > 0 && i <= j)
            j--;
        if (i != high)
            Swap(array, i, high);
        Partition(array, 0, high / 2);
        Partition(array, high / 2, high);
    }
    private void Swap(T[] list, int a, int b)
    {
        T temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
}
