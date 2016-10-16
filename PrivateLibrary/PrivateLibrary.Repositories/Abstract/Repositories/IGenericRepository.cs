using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    namespace Test.Repository.Abstract
    {
        public interface IGenericRepository<TEntity> where TEntity : class, new()
        {
            IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> parser);
        }
    }
}
