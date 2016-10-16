using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        public GenericRepository(string connection)
        {
            Connection = connection;
            SqlWrapper = new SqlCommandWrapper(connection);
        }

        protected string Connection{ get; }
        public SqlCommandWrapper SqlWrapper { get; }


        public IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> parser)
        {
            var result = SqlWrapper.ExecuteReader(spName, parser);
            return (IEnumerable<TEntity>)result;
        }
    }
}
