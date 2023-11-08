using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;

namespace NumberSortingWebApp.Models
{
    public class ListViewModel
    {
        private SortedNumberConnection _connection;
        public List<SortedNumbersRow> sortedNumberRowList { get; set; }

        public ListViewModel(SortedNumberConnection connection) { 
            _connection = connection;

            sortedNumberRowList = _connection.GetAll();
        }

    }
}
