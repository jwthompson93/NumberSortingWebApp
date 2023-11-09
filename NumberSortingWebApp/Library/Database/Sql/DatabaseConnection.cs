using NumberSortingWebApp.Library.Algorithm.Sorting;
using NumberSortingWebApp.Library.Database.Object;
using System.Configuration;
using System.Data.SqlClient;

namespace NumberSortingWebApp.Library.Database.Sql
{
    public abstract class DatabaseConnection
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        protected readonly string GET = "select * from {0}";
        protected readonly string GET_BY_ID = "select * from {0} where id = {1}";
        protected readonly string INSERT = "insert into {0} (sorted_array, sort_direction) " +
                                            "output INSERTED.[id]" + 
                                            "values (@sorted_array, @sort_direction)";
        protected readonly string UPDATE = "update {0} " +
                                            "SET sorted_array = @sorted_array, time_taken = @time_taken" + 
                                            "output INSERTED.[id] " +
                                            "where id = @id";

        protected List<SortedNumbersRow> QueryList(SqlCommand sqlCommand)
        {
            var list = new List<SortedNumbersRow>();

            using (var _connection = new SqlConnection(_connectionString)) { 
                _connection.Open();

                sqlCommand.Connection = _connection;
                var dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    SortedNumbersRow sortedNumbersRow = new SortedNumbersRow();

                    sortedNumbersRow.Id = dataReader.GetInt64(0);
                    sortedNumbersRow.SortedArray = dataReader.GetString(1);
                    sortedNumbersRow.SortDirection = dataReader.GetInt16(2);
                    sortedNumbersRow.TimeTaken = dataReader.GetInt64(3);

                    list.Add(sortedNumbersRow);
                }
            }

            return list;
        }

        protected SortedNumbersRow QuerySingle(SqlCommand sqlCommand)
        {
            var sortedNumbersRow = new SortedNumbersRow();

            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();

                sqlCommand.Connection = _connection;
                var dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    sortedNumbersRow.Id = dataReader.GetInt64(0);
                    sortedNumbersRow.SortedArray = dataReader.GetString(1);
                    sortedNumbersRow.SortDirection = dataReader.GetInt16(2);
                    sortedNumbersRow.TimeTaken = dataReader.GetInt64(3);
                }
            }

            return sortedNumbersRow;
        }

        protected long NonQuery(SqlCommand sqlCommand)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();

                sqlCommand.Connection = _connection;
                long id = (long)sqlCommand.ExecuteScalar();

                return id;
            }
        }
    }
}
