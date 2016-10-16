--CLOSE ALL CONNECTION TO DROP DATABASE!
USE MN_PrivateLibrary
DROP TABLE [MN_PrivateLibrary].Book.BorrowedBooks
DROP TABLE [MN_PrivateLibrary].Book.Books
DROP TABLE [MN_PrivateLibrary].Book.BooksLocation
DROP TABLE [MN_PrivateLibrary].Member.Members
DROP TABLE [MN_PrivateLibrary].Member.MembershipType
DROP TABLE [MN_PrivateLibrary].Employee.Users
DROP TABLE [MN_PrivateLibrary].Employee.Employees
GO
DROP SCHEMA [Member]
DROP SCHEMA [Employee]
DROP SCHEMA [Book]
GO
DROP DATABASE MN_PrivateLibrary
GO