using System;
using System.Data.SqlClient;
using System.Globalization;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;

namespace EpamTask.PrivateLibrary.Parser.Member
{
    public class MembershipParser
    {
        private static MembershipParser _instance;
        private MembershipParser()
        {

        }

        public static MembershipParser Instance => _instance ?? (_instance = new MembershipParser());

        public MembershipEntity MakeMembershipResult(SqlDataReader reader)
        {
            var model = new MembershipEntity();
            if (reader.ColumnExists(MemberShipParameters.Id))
            {
                model.ID = reader[MemberShipParameters.Id] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberShipParameters.Id], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberShipParameters.Name))
            {
                model.Name = reader[MemberShipParameters.Name] is DBNull
                ? string.Empty
                : reader[MemberShipParameters.Name].ToString();
            }

            if (reader.ColumnExists(MemberShipParameters.MaxbookAmount))
            {
                model.MaxbookAmount = reader[MemberShipParameters.MaxbookAmount] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberShipParameters.MaxbookAmount], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberShipParameters.MonthPlan))
            {
                model.MonthPlan = reader[MemberShipParameters.MonthPlan] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberShipParameters.MonthPlan], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberShipParameters.PricePerMonth))
            {
                model.PricePerMonth = reader[MemberShipParameters.PricePerMonth] is DBNull
                ? 0
                : Convert.ToDecimal(reader[MemberShipParameters.PricePerMonth], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberShipParameters.OverdueDayLimit))
            {
                model.OverdueDayLimit = reader[MemberShipParameters.OverdueDayLimit] is DBNull
                ? 0
                : Convert.ToInt32(reader[MemberShipParameters.OverdueDayLimit], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(MemberShipParameters.OverdueFees))
            {
                model.OverdueFees = reader[MemberShipParameters.OverdueFees] is DBNull
                ? 0
                : Convert.ToDecimal(reader[MemberShipParameters.OverdueFees], CultureInfo.CurrentCulture);
            }

            return model;
        }
    }
}
