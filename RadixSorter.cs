// See https://aka.ms/new-console-template for more information
using System.Collections;

public class RadixSorter //: Sorter
{
    private ArrayList[] buckets = new ArrayList[10]; //matrix
    private bool firstTime = true;

    private void InitBuckets(ArrayList[] arrayList) {
        for (int i= 0; i<arrayList.Length; i++)
            arrayList[i] = new ArrayList();
    }

    public int[] Sort(int[] nums)
    {
        InitBuckets(buckets);
        SortAll(nums);

        // Create result
        int[] result = new int[nums.Length];
        int i = 0;
        foreach (ArrayList bucket in buckets)
        {
            foreach (int val in bucket)
            {
                result[i++] = val;
            }
        }
        firstTime = true;
        return result;
    }
    private void SortAll(int[] nums)
    {
        int col = 1;
        int len = findIntMaxLength(nums);
        for (int i=0; i<len; i++)
        {
            SortAllByNumericColumn(nums, col);
            col *= 10;
        }
    }
    private void SortAllByNumericColumn(int[] nums, int col)
    {
        var betterSortedBucket = new ArrayList[10];
        InitBuckets(betterSortedBucket);

        if (firstTime) // start by filling the data field
        {
            foreach (int val in nums)
                AddToBucket(betterSortedBucket, val, col);
            firstTime = false;
        }
        else // continue by replacing the data field with new data
        {
            foreach (ArrayList bucket in buckets)
            {
                foreach (int val in bucket)
                {
                    AddToBucket(betterSortedBucket, val, col);
                }
            }
        }
        buckets = betterSortedBucket;
    }
    private void AddToBucket(ArrayList[] arrayLists, int val, int col)
    {
        arrayLists[val % (col * 10) / col].Add(val);
    }
    private int findIntMaxLength(int[] nums)
    {
        int maxLen = 0;
        foreach (int num in nums)
        {
            int len = 0;
            int col = 1;
            while (num >= col)
            {
                col *= 10;
                len++;
            };
            if (len > maxLen)
                maxLen = len;
        }
        return maxLen;
    }
    public 
        //static 
        void Main(string[] args)
    {
        // Test cases for nonnegative integers
        int[] nums1 = { 6891, 2, 23, 54, 955, 325};
        int[] nums2 = { 789, 231, 543, 982, 654, 789, 123, 987, 456, 876 };
        int[] nums3 = { 5678, 9876, 4321, 65, 1234, 5432, 7890, 3456, 6543, 2345 };
        int[] nums4 = { 9876, 54321, 12345, 87654, 2, 0, 78901, 34567, 65432, 46, 87654 };

        RadixSorter s = new RadixSorter();

        int[] results1 = s.Sort(nums1);
        int[] results2 = s.Sort(nums2);
        int[] results3 = s.Sort(nums3);
        int[] results4 = s.Sort(nums4);

        foreach (int val in results1)
            Console.Write(val + ", "); Console.WriteLine();
        foreach (int val in results2)
            Console.Write(val + ", "); Console.WriteLine();
        foreach (int val in results3)
            Console.Write(val + ", "); Console.WriteLine();
        foreach (int val in results4)
            Console.Write(val + ", ");
    }
}