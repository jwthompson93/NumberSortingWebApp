using NumberSortingWebApp.Library.Algorithm.Sorting;
using NumberSortingWebApp.Library.Database.Object;
using System.Diagnostics;

namespace NumberSortingWebApp.Library.Process
{
    public class SortArrayProcess : IProcess<int[], SortedNumbersRow>
    {
        private ISort<int> sortingAlgorithm;
        private int sortDirection;

        public SortArrayProcess(ISort<int> sortingAlgorithm, int sortDirection)
        {
            this.sortingAlgorithm = sortingAlgorithm;
            this.sortDirection = sortDirection;
        }

        public SortedNumbersRow Process(int[] array)
        {
            SortedNumbersRow sortedNumbersRow = new SortedNumbersRow();

            Stopwatch sw = Stopwatch.StartNew();

            sortedNumbersRow.SortedArray = String.Join(',', 
                sortingAlgorithm.Sort(array, sortDirection));

            sw.Stop();

            sortedNumbersRow.SortDirection = sortDirection;
            sortedNumbersRow.TimeTaken = sw.ElapsedMilliseconds;

            return sortedNumbersRow;
        }
    }
}
