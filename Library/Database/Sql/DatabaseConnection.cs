using NumberSortingWebApp.Library.Database.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NumberSortingWebApp.Library.Database.Sql
{
    public abstract class DatabaseConnection
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=numbersorting_database;Integrated Security=True";

        protected readonly string GET = "select * from {0}";
        protected readonly string GET_BY_ID = "select * from {0} where id = {1}";
        protected readonly string INSERT = "insert into {0} values (@sorted_array, @sort_direction, @time_taken, @is_sorted)";
        protected readonly string UPDATE = "update {0}(sorted_array, sort_direction, time_taken, is_sorted) " +
            "values (@sorted_array, @sort_direction, @time_taken, @is_sorted) where id = @id";

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

                    sortedNumbersRow.id = dataReader.GetInt64(0);
                    sortedNumbersRow.sorted_array = dataReader.GetString(1);
                    sortedNumbersRow.sort_direction = dataReader.GetBoolean(2);
                    sortedNumbersRow.time_taken = dataReader.GetInt64(3);
                    sortedNumbersRow.is_sorted = dataReader.GetBoolean(4);

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
                    sortedNumbersRow.id = dataReader.GetInt64(0);
                    sortedNumbersRow.sorted_array = dataReader.GetString(1);
                    sortedNumbersRow.sort_direction = dataReader.GetBoolean(2);
                    sortedNumbersRow.time_taken = dataReader.GetInt64(3);
                    sortedNumbersRow.is_sorted = dataReader.GetBoolean(4);
                }
            }

            return sortedNumbersRow;
        }

        protected Boolean NonQuery(SqlCommand sqlCommand)
        {

            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();

                sqlCommand.Connection = _connection;
                var rowsAffected = sqlCommand.ExecuteNonQuery();

                if(rowsAffected > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
