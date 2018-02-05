using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        ConstructHeap(arr);
        HeapSort(arr);
    }

    private static void ConstructHeap(T[] arr)
    {
        for (int i = arr.Length / 2; i >= 0; i--)
        {
            HeapifyDown(arr, i, arr.Length);
        }
    }

    private static void HeapSort(T[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void Swap(T[] arr, int parent, int index)
    {
        T temp = arr[parent];
        arr[parent] = arr[index];
        arr[index] = temp;
    }

    private static void HeapifyDown(T[] arr, int index, int length)
    {
        while (index < length / 2)
        {
            int childIndex = (index * 2) + 1;

            if (childIndex + 1 < length && IsLess(arr, childIndex, childIndex + 1))
            {
                childIndex += 1;
            }

            int compare = arr[index].CompareTo(arr[childIndex]);

            if (compare < 0)
            {
                Swap(arr, childIndex, index);
            }

            index = childIndex;
        }
    }

    private static bool IsLess(T[] arr, int parentIndex, int index)
    {
        int compare = arr[parentIndex].CompareTo(arr[index]);

        if (compare >= 0)
        {
            return false;
        }

        return true;
    }
}
