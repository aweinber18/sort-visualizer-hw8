using Sorting_Visualization;
using System;

public class InsertionSorter<T> : Sorter<T> where T : IComparable<T>
{
    private SortVisualizer sortVisualizer;

    public InsertionSorter(SortVisualizer sv)
    {
        sortVisualizer = sv;
    }
    public void Sort(T[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{				
			var temp = array[i];
			var j = i;
			while (j - 1 > 0 && array[j].CompareTo(array[j-1]) < 0)
			{
				array[j] = array[j-1];
				j--;
			}
			array[j] = temp;

			sortVisualizer.ResetRTB();
			foreach (var item in array) Console.Write(item + ", ");
            Thread.Sleep(1000);
        }
    }
}
