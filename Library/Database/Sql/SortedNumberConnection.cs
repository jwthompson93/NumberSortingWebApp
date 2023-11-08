
using NumberSortingWebApp.Library.Database.Object;
using System.Data.SqlClient;

namespace NumberSortingWebApp.Library.Database.Sql
{
    public class SortedNumberConnection : DatabaseConnection
    {
        public List<SortedNumbersRow> GetAll()
        {
            var list = new List<SortedNumbersRow>();

            SqlCommand sqlCommand = new SqlCommand(String.Format(GET, "sorted_numbers"));
            list = QueryList(sqlCommand);

            list.ForEach(row => Console.WriteLine(row.ToString()));

            return list;
        }

        public SortedNumbersRow GetById(long id)
        {
            var sortedNumbersRow = new SortedNumbersRow();

            SqlCommand sqlCommand = new SqlCommand(String.Format(GET_BY_ID, "sorted_numbers", id));
            sortedNumbersRow = QuerySingle(sqlCommand);

            Console.WriteLine(sortedNumbersRow.ToString());

            return sortedNumbersRow;
        }

        public Boolean Insert(SortedNumbersRow sortedNumbersRow)
        {
            SqlCommand sqlCommand = new SqlCommand(String.Format(INSERT, "sorted_numbers"));

            sqlCommand.Parameters.AddWithValue("@sorted_array", sortedNumbersRow.sorted_array);
            sqlCommand.Parameters.AddWithValue("@sort_direction", sortedNumbersRow.sort_direction);
            sqlCommand.Parameters.AddWithValue("@time_taken", sortedNumbersRow.time_taken);
            sqlCommand.Parameters.AddWithValue("@is_sorted", sortedNumbersRow.is_sorted);

            var rowsAffected = NonQuery(sqlCommand);

            return rowsAffected;
        }

        public Boolean Update(SortedNumbersRow sortedNumbersRow)
        {
            SqlCommand sqlCommand = new SqlCommand(String.Format(UPDATE, "sorted_numbers"));

            sqlCommand.Parameters.AddWithValue("@sorted_array", sortedNumbersRow.sorted_array);
            sqlCommand.Parameters.AddWithValue("@sort_direction", sortedNumbersRow.sort_direction);
            sqlCommand.Parameters.AddWithValue("@time_taken", sortedNumbersRow.time_taken);
            sqlCommand.Parameters.AddWithValue("@is_sorted", sortedNumbersRow.is_sorted);
            sqlCommand.Parameters.AddWithValue("@id", sortedNumbersRow.id);

            var rowsAffected = NonQuery(sqlCommand);

            return rowsAffected;
        }
    }
}
