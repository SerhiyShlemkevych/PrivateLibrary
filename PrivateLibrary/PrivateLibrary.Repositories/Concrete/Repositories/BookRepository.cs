using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        public BookRepository(string connection) : base(connection)
        {

        }

        public IEnumerable<BookEntity> GetAll(Func<SqlDataReader, BookEntity> parser)
        {
            return ExecuteReader(StoredProceduresName.GetAllBooks, parser);
        }

        public int Delete(int bookId)
        {
            var id = new SqlParameter(BookParameters.Id, bookId);
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.DeleteBook, id);
        }

        public int Update(BookEntity book)
        {
            var parameters = ParseBookIntoParameters(book);
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.UpdateBook, parameters);
        }

        public int Add(BookEntity book)
        {
            var parameters = ParseBookIntoParameters(book);
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.AddBook, parameters);
        }

        private SqlParameter[] ParseBookIntoParameters(BookEntity book)
        {
            var parameters = new[]
            {
                new SqlParameter(BookParameters.Id,book.ID),
                new SqlParameter(BookParameters.Name,book.Name),
                new SqlParameter(BookParameters.Author,book.Author),
                new SqlParameter(BookParameters.Gendre,book.Gendre),
                new SqlParameter(BookParameters.Year,book.Year),
                new SqlParameter(BookParameters.ISBN,book.ISBN),
                new SqlParameter(BookParameters.Amount,book.Amount),
                new SqlParameter(BookParameters.Floor,book.Floor),
                new SqlParameter(BookParameters.Shelf,book.Shelf),
            };
            return parameters;
        }
    }
}
