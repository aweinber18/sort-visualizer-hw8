using System;

public interface Sorter<T> where T : IComparable<T>
{
	void Sort(T[] array);
}
