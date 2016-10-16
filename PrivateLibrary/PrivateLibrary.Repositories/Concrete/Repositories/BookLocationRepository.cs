using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class BookLocationRepository : GenericRepository<BookLocationEntity>, IBookLocationRepository
    {
        public BookLocationRepository(string connection) : base(connection)
        {

        }

        public IEnumerable<BookLocationEntity> GetAll(Func<SqlDataReader, BookLocationEntity> parser)
        {
            return ExecuteReader(StoredProceduresName.GetAllLocations, parser);
        }
    }
}
