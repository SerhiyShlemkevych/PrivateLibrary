using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Models;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IBorrowRepository : IGenericRepository<BorrowModel>
    {
       IEnumerable<BorrowModel> GetAll(Func<SqlDataReader, BorrowModel> parser);

       int Lend(int memberId, int bookId, int employeeId);

       int Return(int memberId, int bookId);
    }
}
