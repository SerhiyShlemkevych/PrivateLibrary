using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    namespace Test.Repository.Abstract
    {
        // Review IP: I dont think ExecuteReader should be exposed as public method
        // Review IP: By using SqlDataReader here you are binding this interface for sql implementation
        public interface IGenericRepository<TEntity> where TEntity : class, new()
        {
            IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> parser);
        }
    }
}
