using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class MemberRepository : GenericRepository<MemberEntity>, IMemberRepository
    {
        public MemberRepository(string connection) : base(connection)
        {

        }

        public IEnumerable<MemberEntity> GetAll(Func<SqlDataReader, MemberEntity> parser)
        {
            return ExecuteReader(StoredProceduresName.GetAllMembers, parser);
        }

        public int Delete(int memberId)
        {
            var id = new SqlParameter(MemberParameters.Id, memberId);
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.DeleteMember, id);
        }

        public int Update(MemberEntity member)
        {
            var parameters = new[]
            {
                new SqlParameter(MemberParameters.Id,member.ID),
                new SqlParameter(MemberParameters.FirstName,member.FirstName),
                new SqlParameter(MemberParameters.LastName,member.LastName),
                new SqlParameter(MemberParameters.Email,member.Email),
                new SqlParameter(MemberParameters.PhoneNumber,member.PhoneNumber),
                new SqlParameter(MemberParameters.Gender,member.Gender),
                new SqlParameter(MemberParameters.City,member.City)
            };
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.UpdateMember, parameters.ToArray());
        }

        public int Add(MemberEntity member)
        {
            var parameters = new[]
{
                new SqlParameter(MemberParameters.FirstName,member.FirstName),
                new SqlParameter(MemberParameters.LastName,member.LastName),
                new SqlParameter(MemberParameters.Email,member.Email),
                new SqlParameter(MemberParameters.PhoneNumber,member.PhoneNumber),
                new SqlParameter(MemberParameters.Gender,member.Gender),
                new SqlParameter(MemberParameters.City,member.City),
                new SqlParameter(MemberParameters.MembershipName,member.MembershipName)
            };
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.AddMember, parameters);
        }
        public int Renew(int memberId, string membershipName)
        {
            var parameters = new[]
                {
                new SqlParameter(MemberParameters.Id,memberId),
                new SqlParameter(MemberParameters.MembershipName,membershipName)
                };
            return SqlWrapper.ExecuteProcedure(StoredProceduresName.RenewMembership, parameters);
        }
    }
}
