using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Models;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class BorrowRepository : GenericRepository<BorrowModel>, IBorrowRepository
    {
        public BorrowRepository(string connection) : base(connection)
        {

        }

        public IEnumerable<BorrowModel> GetAll(Func<SqlDataReader, BorrowModel> parser)
        {
            return ExecuteReader(StoredProceduresName.GetAllBorrowed, parser);
        }

        public int Lend(int memberId, int bookId, int employeeId)
        {
            var parameters = new[]
            {
                new SqlParameter(BorrowParameters.MemberId,memberId),
                new SqlParameter(BorrowParameters.BookId,bookId),
                new SqlParameter(BorrowParameters.LendedBy,employeeId)
            };        
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.LendABook, parameters);
        }

        public int Return(int memberId, int bookId)
        {
            var parameters = new[]
{
                new SqlParameter(BorrowParameters.MemberId,memberId),
                new SqlParameter(BorrowParameters.BookId,bookId)
            };
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.ReturnABook, parameters);
        }
    }
}
