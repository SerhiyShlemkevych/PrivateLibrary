using System;
using System.Data.SqlClient;
using System.Globalization;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;

namespace EpamTask.PrivateLibrary.Parser.Member
{
    public class MemberParser
    {
        private static MemberParser _instance;
        private MemberParser()
        {

        }

        public static MemberParser Instance => _instance ?? (_instance = new MemberParser());

        public MemberEntity MakeMemberResult(SqlDataReader reader)
        {
            var model = new MemberEntity();
            if (reader.ColumnExists(MemberParameters.Id))
            {
                model.ID = reader[MemberParameters.Id] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberParameters.Id], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberParameters.FirstName))
            {
                model.FirstName = reader[MemberParameters.FirstName] is DBNull
                ? string.Empty
                : reader[MemberParameters.FirstName].ToString();
            }

            if (reader.ColumnExists(MemberParameters.LastName))
            {
                model.LastName = reader[MemberParameters.LastName] is DBNull
                ? string.Empty
                : reader[MemberParameters.LastName].ToString();
            }

            if (reader.ColumnExists(MemberParameters.Email))
            {
                model.Email = reader[MemberParameters.Email] is DBNull
                ? string.Empty
                : reader[MemberParameters.Email].ToString();
            }

            if (reader.ColumnExists(MemberParameters.PhoneNumber))
            {
                model.PhoneNumber = reader[MemberParameters.PhoneNumber] is DBNull
                ? string.Empty
                : reader[MemberParameters.PhoneNumber].ToString();
            }

            if (reader.ColumnExists(MemberParameters.Gender))
            {
                model.Gender = reader[MemberParameters.Gender] is DBNull
                ? string.Empty
                : reader[MemberParameters.Gender].ToString();
            }

            if (reader.ColumnExists(MemberParameters.City))
            {
                model.City = reader[MemberParameters.City] is DBNull
                ? string.Empty
                : reader[MemberParameters.City].ToString();
            }

            if (reader.ColumnExists(MemberParameters.JoinDate))
            {
                model.JoinDate = reader[MemberParameters.JoinDate] is DBNull
                ? string.Empty
                : reader[MemberParameters.JoinDate].ToString().Substring(0, 10);
            }

            if (reader.ColumnExists(MemberParameters.SubscriptionStartDate))
            {
                model.SubscriptionStartDate = reader[MemberParameters.SubscriptionStartDate] is DBNull
                ? string.Empty
                : reader[MemberParameters.SubscriptionStartDate].ToString().Substring(0, 10);
            }

            if (reader.ColumnExists(MemberParameters.CurrentBooks))
            {
                model.CurrentBooks = reader[MemberParameters.CurrentBooks] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberParameters.CurrentBooks], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberParameters.MembershipName))
            {
                model.MembershipName = reader[MemberParameters.MembershipName] is DBNull
                ? string.Empty
                : reader[MemberParameters.MembershipName].ToString();
            }

            return model;
        }
    }
}
