using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;

namespace NumberSortingWebApp.Library.Process
{
    public class InsertProcess : IProcess<SortedNumbersRow, bool>
    {
        private SortedNumberConnection _connection;
        public InsertProcess() {
            _connection = new SortedNumberConnection();
        }

        public bool Process(SortedNumbersRow input)
        {
            return _connection.Insert(input) > 0;
        }

        public bool Process(SortedNumbersRow input, int SortDirection)
        {
            throw new NotImplementedException();
        }
    }
}
