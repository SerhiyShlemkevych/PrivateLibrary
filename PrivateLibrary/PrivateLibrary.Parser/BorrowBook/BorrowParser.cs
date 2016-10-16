using System;
using System.Data.SqlClient;
using System.Globalization;
using EpamTask.PrivateLibrary.Entity.Models;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;

namespace EpamTask.PrivateLibrary.Parser.BorrowBook
{
    public class BorrowParser
    {
        private static BorrowParser _instance;
        private BorrowParser()
        {

        }

        public static BorrowParser Instance => _instance ?? (_instance = new BorrowParser());

        public BorrowModel MakeBorrowResult(SqlDataReader reader)
        {
            var model = new BorrowModel();
            if (reader.ColumnExists(BorrowParameters.MemberId))
            {
                model.MemberID = reader[BorrowParameters.MemberId] is DBNull
                ? 0
                : Convert.ToInt32(reader[BorrowParameters.MemberId], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BorrowParameters.Member))
            {
                model.Member = reader[BorrowParameters.Member] is DBNull
                ? string.Empty
                : reader[BorrowParameters.Member].ToString();
            }

            if (reader.ColumnExists(BorrowParameters.BookId))
            {
                model.BookID = reader[BorrowParameters.BookId] is DBNull
                ? 0
                : Convert.ToInt32(reader[BorrowParameters.BookId], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BorrowParameters.Title))
            {
                model.Title = reader[BorrowParameters.Title] is DBNull
                ? string.Empty
                : reader[BorrowParameters.Title].ToString();
            }

            if (reader.ColumnExists(BorrowParameters.LendDate))
            {
                model.LendDate = reader[BorrowParameters.LendDate] is DBNull
                ? string.Empty
                : reader[BorrowParameters.LendDate].ToString().Substring(0, 10);
            }

            if (reader.ColumnExists(BorrowParameters.LendedBy))
            {
                model.LendedBy = reader[BorrowParameters.LendedBy] is DBNull
                ? string.Empty
                : reader[BorrowParameters.LendedBy].ToString();
            }

            return model;
        }
    }
}
