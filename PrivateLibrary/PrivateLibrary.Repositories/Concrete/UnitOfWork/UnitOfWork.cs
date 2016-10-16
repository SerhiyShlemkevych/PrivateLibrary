using EpamTask.PrivateLibrary.Repositories.Abstract.Repositories;
using EpamTask.PrivateLibrary.Repositories.Abstract.UnitOfWork;
using EpamTask.PrivateLibrary.Repositories.Concrete.Repositories;

namespace EpamTask.PrivateLibrary.Repositories.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly string _connection;

        private IBookRepository _bookRepository;
        private IBookLocationRepository _bookLocationRepository;
        private IMemberRepository _memberRepository;
        private IMembershipRepository _membershipRepository;
        private IBorrowRepository _borrowRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(string connection)
        {
            _connection = connection;
        }
        public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_connection));
        public IBookLocationRepository BookLocationRepository => _bookLocationRepository ?? (_bookLocationRepository = new BookLocationRepository(_connection));
        public IMemberRepository MemberRepository => _memberRepository ?? (_memberRepository = new MemberRepository(_connection));
        public IMembershipRepository MembershipRepository => _membershipRepository ?? (_membershipRepository = new MembershipRepository(_connection));
        public IBorrowRepository BorrowRepository => _borrowRepository ?? (_borrowRepository = new BorrowRepository(_connection));
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_connection));
    }
}
