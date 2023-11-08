using NumberSortingWebApp.Library.Algorithm.Sorting;

namespace NumberSortingWebApp.Library.Database.Object
{
    public class SortedNumbersRow
    {
        public long Id { get; set; }

        public string SortedArray { get; set; }

        public SortDirection SortDirection { get; set; }

        public long? TimeTaken { get; set; }

        public bool? IsSorted { get; set; } = false;

        public override string ToString()
        {
            return string.Format("Id: {0}, Sorted Array: {1}, Sort Direction: {2}, Time Taken: {3}, Is Sorted: {4}", 
                Id, SortedArray, SortDirection, TimeTaken, IsSorted);
        }
    }
}
