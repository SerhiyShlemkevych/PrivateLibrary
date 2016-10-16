using System;
using System.Data.SqlClient;
using System.Globalization;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper;
using EpamTask.PrivateLibrary.Repositories.SqlWrapper.EntityParameters;

namespace EpamTask.PrivateLibrary.Parser.Book
{
    public class BookParser
    {
        private static BookParser _instance;
        private BookParser()
        {

        }

        public static BookParser Instance => _instance ?? (_instance = new BookParser());

        public BookEntity MakeBookResult(SqlDataReader reader)
        {
            var model = new BookEntity();
            if (reader.ColumnExists(BookParameters.Id))
            {
                model.ID = reader[BookParameters.Id] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookParameters.Id], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookParameters.Name))
            {
                model.Name = reader[BookParameters.Name] is DBNull
                ? string.Empty
                : reader[BookParameters.Name].ToString();
            }

            if (reader.ColumnExists(BookParameters.Author))
            {
                model.Author = reader[BookParameters.Author] is DBNull
                ? string.Empty
                : reader[BookParameters.Author].ToString();
            }

            if (reader.ColumnExists(BookParameters.Gendre))
            {
                model.Gendre = reader[BookParameters.Gendre] is DBNull
                ? string.Empty
                : reader[BookParameters.Gendre].ToString();
            }

            if (reader.ColumnExists(BookParameters.Year))
            {
                model.Year = reader[BookParameters.Year] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookParameters.Year], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookParameters.ISBN))
            {
                model.ISBN = reader[BookParameters.ISBN] is DBNull
                ? string.Empty
                : reader[BookParameters.ISBN].ToString();
            }

            if (reader.ColumnExists(BookParameters.Amount))
            {
                model.Amount = reader[BookParameters.Amount] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookParameters.Amount], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookParameters.Floor))
            {
                model.Floor = reader[BookParameters.Floor] is DBNull
                ? 0
                : Convert.ToInt32(reader[BookParameters.Floor], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists(BookParameters.Shelf))
            {
                model.Shelf = reader[BookParameters.Shelf] is DBNull
                ? string.Empty
                : reader[BookParameters.Shelf].ToString();
            }

            return model;
        }
    }
}
