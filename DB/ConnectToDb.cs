using System.Data;
using Microsoft.Data.SqlClient;

namespace MarketsAPI.DB
{
    public class ConnectToDb
    {
        private string? ConnectionString { get; set; }
        public ConnectToDb(string? _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public DataSet? ReadFromSql(string query, bool isStoredProc, string tableName, SqlParameter[]? parameters = null)
        {
            DataSet dataSet = new DataSet();

            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    if (isStoredProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;

                    if(parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        dataSet.Load(reader, LoadOption.PreserveChanges, tableName);
                    }
                }
            }

            return dataSet;
        }

        public DataTable InsertToSql(string query, bool isStoredProc, SqlParameter[]? parameters = null)
        {
            DataTable table = new DataTable();
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (isStoredProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    IDataReader reader = command.ExecuteReader();
                    if(reader !=null)
                    {
                        table.Load(reader, LoadOption.PreserveChanges);
                    }
                    else
                    {
                        throw new Exception("No data returned from the database.");
                    }
                }
            }
            return table;
        }

        public int? InsertSql(string query, bool isStoredProc, SqlParameter[]? parameters = null)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (isStoredProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
