using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IBookLocationRepository : IGenericRepository<BookLocationEntity>
    {
       IEnumerable<BookLocationEntity> GetAll(Func<SqlDataReader, BookLocationEntity> parser);
    }
}
