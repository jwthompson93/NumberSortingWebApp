using NumberSortingWebApp.Library.Alert;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;

namespace NumberSortingWebApp.Models
{
    public class ListViewModel
    {
        private SortedNumberConnection _connection;
        public List<SortedNumbersRow> sortedNumberRowList { get; set; }

        public Alert Alert { get; }

        public ListViewModel(SortedNumberConnection connection, Alert alert) { 
            _connection = connection;

            this.Alert = alert;

            sortedNumberRowList = _connection.GetAll();
        }

    }
}
