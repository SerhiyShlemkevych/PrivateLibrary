using System;
using System.Data.SqlClient;
using System.Globalization;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;

namespace EpamTask.PrivateLibrary.Parser.Book
{
    public class BookLocationParser
    {
        private static BookLocationParser _instance;
        private BookLocationParser()
        {

        }

        public static BookLocationParser Instance => _instance ?? (_instance = new BookLocationParser());

        public BookLocationEntity MakeBookLocationResult(SqlDataReader reader)
        {
            var model = new BookLocationEntity();
            if (reader.ColumnExists(BookLocationParameters.Id))
            {
                model.ID = reader[BookLocationParameters.Id] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookLocationParameters.Id], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookLocationParameters.Floor))
            {
                model.Floor = reader[BookLocationParameters.Floor] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookLocationParameters.Floor], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookLocationParameters.Shelf))
            {
                model.Shelf = reader[BookLocationParameters.Shelf] is DBNull
                ? string.Empty
                : reader[BookLocationParameters.Shelf].ToString();
            }

            return model;
        }
    }

}
