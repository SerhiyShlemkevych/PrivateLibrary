using System.Collections.Generic;
using System.Configuration;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Entity.Models;
using EpamTask.PrivateLibrary.Repositories.Abstract.UnitOfWork;
using EpamTask.PrivateLibrary.Repositories.Concrete.UnitOfWork;

namespace EpamTask.PrivateLibrary.Global
{
    internal static class Container
    {
        public static IUnitOfWork UnitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
        public static int CurrentUserId;
        public static IEnumerable<BookLocationEntity> BookLocationList { get; set; }
        public static IEnumerable<MembershipEntity> MembershipList { get; set; }
        public static IEnumerable<BookEntity> BookList { get; set; }
        public static IEnumerable<MemberEntity> MemberList { get; set; }
        public static IEnumerable<BorrowModel> BorrowList { get; set; }
        public static TableType CurrentTable { get; set; }
    }
    internal enum TableType
    {
        Book,
        Member,
        BorrowList
    }
}
