
using NumberSortingWebApp.Library.Database.Object;
using System.Data.SqlClient;

namespace NumberSortingWebApp.Library.Database.Sql
{
    public class SortedNumberConnection : DatabaseConnection
    {
        private readonly string tableName = "SortedNumbers";

        public List<SortedNumbersRow> GetAll()
        {
            var list = new List<SortedNumbersRow>();

            SqlCommand sqlCommand = new SqlCommand(String.Format(GET, tableName));
            list = QueryList(sqlCommand);

            list.ForEach(row => Console.WriteLine(row.ToString()));

            return list;
        }

        public SortedNumbersRow GetById(long id)
        {
            var sortedNumbersRow = new SortedNumbersRow();

            SqlCommand sqlCommand = new SqlCommand(String.Format(GET_BY_ID, tableName, id));
            sortedNumbersRow = QuerySingle(sqlCommand);

            Console.WriteLine(sortedNumbersRow.ToString());

            return sortedNumbersRow;
        }

        public long Insert(SortedNumbersRow sortedNumbersRow)
        {
            SqlCommand sqlCommand = new SqlCommand(String.Format(INSERT, tableName));

            sqlCommand.Parameters.AddWithValue("@sorted_array", sortedNumbersRow.SortedArray);
            sqlCommand.Parameters.AddWithValue("@sort_direction", sortedNumbersRow.SortDirection);
            sqlCommand.Parameters.AddWithValue("@is_sorted", sortedNumbersRow.IsSorted);

            var id = NonQuery(sqlCommand);

            return id;
        }

        public long Update(SortedNumbersRow sortedNumbersRow)
        {
            SqlCommand sqlCommand = new SqlCommand(String.Format(UPDATE, tableName));

            sqlCommand.Parameters.AddWithValue("@sorted_array", sortedNumbersRow.SortedArray);
            sqlCommand.Parameters.AddWithValue("@sort_direction", sortedNumbersRow.SortDirection);
            sqlCommand.Parameters.AddWithValue("@time_taken", sortedNumbersRow.TimeTaken);
            sqlCommand.Parameters.AddWithValue("@is_sorted", sortedNumbersRow.IsSorted);
            sqlCommand.Parameters.AddWithValue("@id", sortedNumbersRow.Id);

            var id = NonQuery(sqlCommand);

            return id;
        }
    }
}
