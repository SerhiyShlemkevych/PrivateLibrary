using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IBookLocationRepository : IGenericRepository<BookLocationEntity>
    {
        // Review IP: Consider moving this to base class as long as you have this method almost in all classes
        IEnumerable<BookLocationEntity> GetAll(Func<SqlDataReader, BookLocationEntity> parser);
    }
}
