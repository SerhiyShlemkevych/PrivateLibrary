using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IMembershipRepository : IGenericRepository<MembershipEntity>
    {
        IEnumerable<MembershipEntity> GetAll(Func<SqlDataReader, MembershipEntity> parser);
    }
}
