namespace EpamTask.PrivateLibrary.Repositories.SqlWrapper.StoredPocedureParametersName
{
    public static class StoredProceduresName
    {
        public const string GetAllBooks = "[dbo].[spGetAllBooks]";
        public const string GetAllLocations = "[dbo].[spGetAllLocations]";
        public const string GetAllMembers = "[dbo].[spGetAllMembers]";
        public const string GetAllMembershipTypes = "[dbo].[spGetAllMembershipTypes]";
        public const string GetAllBorrowed = "[dbo].[spGetBorrowedList]";

        public const string UpdateBook = "[dbo].[spUpdateBook]";
        public const string AddBook = "[dbo].[spAddBook]";
        public const string DeleteBook = "[dbo].[spDeleteBook]";

        public const string UpdateMember = "[dbo].[spUpdateMember]";
        public const string AddMember = "[dbo].[spAddMember]";
        public const string DeleteMember = "[dbo].[spDeleteMember]";
        public const string RenewMembership = "[dbo].[sprenewMembership]";

        public const string LendABook = "[dbo].[spLendABook]";
        public const string ReturnABook = "[dbo].[spReturnABook]";
    }
}
