using System;

namespace NumberSortingWebApp.Library.Algorithm.Sorting
{
    public class Quicksort : ISort<int>
    {
        public int[] Sort(int[] array, SortDirection sortDirection)
        {
            return QuickSort(ref array, 0, array.Length - 1, sortDirection);
        }

        private int[] QuickSort(ref int[] array, int low, int high, SortDirection sortDirection)
        {
            if(low < high)
            {
                int pi = Partition(ref array, low, high, sortDirection);
                QuickSort(ref array, low, pi - 1, sortDirection);
                QuickSort(ref array, pi + 1, high, sortDirection);
            }

            return array;
        }

        private int Partition(ref int[] array, int low, int high, SortDirection sortDirection) { 
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++) {
                if (IsSwappable(array[j], pivot, sortDirection))
                {
                    i++;
                    Swap(ref array, i, j);
                }
            }

            Swap(ref array, i + 1, high);
            return i + 1;
        }

        private void Swap(ref int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private bool IsSwappable(int arrayValue, int pivot, SortDirection sortDirection)
        {
            if(sortDirection == SortDirection.Ascending)
            {
                return arrayValue <= pivot;
            }
            else if(sortDirection == SortDirection.Descending)
            {
                return arrayValue >= pivot;
            }

            return false;
        }
    }
}
