using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;

namespace EpamTask.PrivateLibrary.Repositories.Abstract.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IBookLocationRepository BookLocationRepository { get; }

        IMemberRepository MemberRepository { get; }
        IMembershipRepository MembershipRepository { get; }

        IBorrowRepository BorrowRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
