namespace NumberSortingWebApp.Library.Database.Object
{
    public class SortedNumbersRow
    {
        public long id { get; set; }

        public string sorted_array { get; set; }

        public bool sort_direction { get; set; }

        public long? time_taken { get; set; }

        public bool? is_sorted { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Sorted Array: {1}, Sort Direction: {2}, Time Taken: {3}, Is Sorted: {4}", 
                id, sorted_array, sort_direction, time_taken, is_sorted);
        }
    }
}
