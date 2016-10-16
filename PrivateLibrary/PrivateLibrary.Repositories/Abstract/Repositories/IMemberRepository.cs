using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IMemberRepository : IGenericRepository<MemberEntity>
    {
        IEnumerable<MemberEntity> GetAll(Func<SqlDataReader, MemberEntity> parser);

        int Update(MemberEntity book);

        int Add(MemberEntity book);

        int Delete(int memberId);

        int Renew(int memberId, string membershipType);
    }
}
