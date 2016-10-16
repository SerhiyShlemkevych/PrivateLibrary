using System.Data.SqlClient;
using EpamTask.PrivateLibrary.Entity.User;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using System.Data;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>,IUserRepository
    {
        public UserRepository(string connection) : base(connection)
        {

        }
        public UserEntity GetUserByLogin(string login, string password)
        {
            using (var con = new SqlConnection(Connection))
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[spGetUserByLogin]";
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    var employeeId = command.ExecuteScalar();
                    return employeeId == null ? null : new UserEntity() {ID = (int)employeeId};
                }
            }
        }
    }
}
