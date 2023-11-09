using NumberSortingWebApp.Library.Algorithm.Sorting;
using System.ComponentModel.DataAnnotations;

namespace NumberSortingWebApp.Library.Database.Object
{
    public partial class SortedNumbersRow
    {
        public long Id { get; set; }

        [Required]
        //[RegularExpression("[^\\d+,\\d+$]", ErrorMessage = "Values must be numeric and comma-separated")]
        public string SortedArray { get; set; }

        public int SortDirection { get; set; }

        public long? TimeTaken { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Sorted Array: {1}, Sort Direction: {2}, Time Taken: {3}", 
                Id, SortedArray, SortDirection, TimeTaken);
        }
    }
}
