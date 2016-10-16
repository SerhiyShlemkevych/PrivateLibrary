using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class MembershipRepository : GenericRepository<MembershipEntity>, IMembershipRepository
    {
        public MembershipRepository(string connection) : base(connection)
        {

        }

        public IEnumerable<MembershipEntity> GetAll(Func<SqlDataReader, MembershipEntity> parser)
        {
            return ExecuteReader(StoredProceduresName.GetAllMembershipTypes, parser);
        }
    }
}
