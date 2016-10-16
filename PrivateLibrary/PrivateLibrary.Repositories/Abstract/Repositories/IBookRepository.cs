using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IBookRepository : IGenericRepository<BookEntity>
    {
       IEnumerable<BookEntity> GetAll(Func<SqlDataReader, BookEntity> parser);

        int Update(BookEntity book);

        int Add(BookEntity book);

        int Delete(int bookId);
    }
}
