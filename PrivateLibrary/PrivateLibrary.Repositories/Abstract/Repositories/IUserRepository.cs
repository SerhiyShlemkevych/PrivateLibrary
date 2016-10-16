
using System.Collections.Generic;
using EpamTask.PrivateLibrary.Entity.User;
using System.Data.SqlClient;
using System;
using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories.Test.Repository.Abstract;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetUserByLogin(string login, string password);
    }
}
