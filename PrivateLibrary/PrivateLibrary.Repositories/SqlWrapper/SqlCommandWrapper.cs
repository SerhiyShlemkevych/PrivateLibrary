using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EpamTask.PrivateLibrary.Repositories.SqlWrapper
{
    public class SqlCommandWrapper
    {

        private readonly string _connectionString;
        public SqlCommandWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object ExecuteReader<T>(string spName, Func<SqlDataReader, T> callback = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(spName, connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.CommandTimeout = 0;

                    var reader = command.ExecuteReader();
                    object result;

                    using (reader)
                    {
                        var list = new List<T>();
                        while (reader.Read())
                        {
                            if (callback == null) continue;
                            var item = callback(reader);
                            if (!Equals(item, default(T)))
                            {
                                list.Add(item);
                            }
                        }
                        result = list;
                    }
                    return result;
                }
            }
        }

        public int ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Connection = connection;
                            command.Parameters.AddRange(parameters);
                            command.CommandText = procedureName;
                            command.Transaction = transaction;
                            command.CommandTimeout = 0;
                            var result = command.ExecuteNonQuery();
                            transaction.Commit();
                            return result;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }          
            }
        }
    }
}
