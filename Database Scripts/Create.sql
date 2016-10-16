IF DB_ID('MN_PrivateLibrary') IS NULL
CREATE DATABASE MN_PrivateLibrary
GO
USE MN_PrivateLibrary
GO
CREATE SCHEMA Member
GO
CREATE SCHEMA Employee
GO
CREATE SCHEMA Book
GO

--since we have a Drop.sql, there is no need to check 'IF OBJECT_ID(***) IS NOT NULL'?

USE MN_PrivateLibrary
CREATE TABLE Book.BooksLocation
(
 [BookLocationID] INT NOT NULL IDENTITY(1,1),
 [Floor] INT NOT NULL DEFAULT 1,
 [Shelf] NVARCHAR(50) NOT NULL DEFAULT 'Storage',
 CONSTRAINT pk_BooksLocation_BookID PRIMARY KEY([BookLocationID]),
 CONSTRAINT chk_BooksLocation_Floor CHECK ([Floor] >= 1),
 CONSTRAINT chk_BooksLocation_Location UNIQUE([Floor], [Shelf])
);
GO

USE MN_PrivateLibrary
CREATE TABLE Book.Books
(
 [BookID] INT NOT NULL IDENTITY(1,1),
 [Name] NVARCHAR(100) NOT NULL,
 [Author] NVARCHAR(50) NOT NULL,
 [Gendre] NVARCHAR(50) NOT NULL,
 [Year] INT NOT NULL,
 [ISBN] NVARCHAR(100) NOT NULL,
 [Amount] INT NOT NULL DEFAULT 0,
 [BookLocationID] INT NOT NULL,
 CONSTRAINT pk_Books_BookID PRIMARY KEY([BookID]),
 CONSTRAINT fk_Books_BookLocationID FOREIGN KEY([BookLocationID])
	REFERENCES Book.BooksLocation([BookLocationID])
	ON DELETE CASCADE
	ON UPDATE CASCADE,
 CONSTRAINT chk_Books_Amount CHECK ([Amount] >= 0),
 CONSTRAINT chk_Books_Year	 CHECK ([Year] >= 0)
);
GO

USE MN_PrivateLibrary
CREATE TABLE Employee.Employees
(
 [EmployeeID] INT NOT NULL IDENTITY(1000,1),
 [FirstName] NVARCHAR(50) NOT NULL,
 [LastName] NVARCHAR(50) NOT NULL, 
 [Gender] NVARCHAR(50) NOT NULL,
 [JobTitle] NVARCHAR(50) NOT NULL, 
 [Salary] MONEY NOT NULL, 
 [HireDate] DATE NOT NULL DEFAULT GETDATE(),
 [Email] NVARCHAR(50) NOT NULL,
 [PhoneNumber] NVARCHAR(50) NOT NULL,
 [City] NVARCHAR(50) NOT NULL,
 [Address] NVARCHAR(100) NOT NULL,
 CONSTRAINT pk_Employees_EmployeeID PRIMARY KEY([EmployeeID])
);
GO

USE MN_PrivateLibrary
CREATE TABLE Member.MembershipType
(
 [MembershipID]  INT NOT NULL IDENTITY(1,1), 
 [Name] VARCHAR(100) UNIQUE NOT NULL,
 [MaxBookAmount] INT NOT NULL,
 [MonthPlan] INT NOT NULL, -- [SubscriptionPlan],[Plan]
 [PricePerMonth] MONEY NOT NULL,
 [OverdueDayLimit] INT NOT NULL,
 [OverdueFees] MONEY NOT NULL,
 CONSTRAINT pk_Membership_MembershipID PRIMARY KEY([MembershipID]),
 CONSTRAINT chk_Membership_MaxBookAmount CHECK ([MaxBookAmount] >= 1),
 CONSTRAINT chk_Membership_MonthPlan	 CHECK ([MonthPlan] >= 1),
 CONSTRAINT chk_Membership_PricePerMonth CHECK ([PricePerMonth] > 0),
 CONSTRAINT chk_Membership_OverdueFees	 CHECK ([OverdueFees] >= 0)
);
GO

USE MN_PrivateLibrary
CREATE TABLE Member.Members 
(
 [MemberID] INT NOT NULL IDENTITY(10000,1),
 [FirstName] NVARCHAR(50) NOT NULL,
 [LastName] NVARCHAR(50) NOT NULL, 
 [Email] NVARCHAR(50) NOT NULL,
 [PhoneNumber] NVARCHAR(50) NOT NULL,
 [Gender] NVARCHAR(50) NOT NULL,
 [City] NVARCHAR(50) NOT NULL,
 [JoinDate] DATE NOT NULL DEFAULT GETDATE(),
 [SubscriptionStartDate] DATE NOT NULL,
 [CurrentBookAmount] INT NOT NULL DEFAULT 0,
 [MembershipTypeID] INT NOT NULL
 CONSTRAINT pk_Member_MemberID PRIMARY KEY([MemberID]),
 CONSTRAINT fk_Member_MembershipTypeID FOREIGN KEY([MembershipTypeID])
	REFERENCES Member.MembershipType([MembershipID])
	ON DELETE CASCADE
	ON UPDATE CASCADE,
 CONSTRAINT chk_Members_CurrentBookAmount CHECK ([CurrentBookAmount] >= 0),
 CONSTRAINT chk_Members_Gender CHECK ([Gender] = 'Female' OR [Gender] = 'Male')
);

USE MN_PrivateLibrary
CREATE TABLE Book.BorrowedBooks
(
 [MemberID] INT NOT NULL,
 [BookID] INT NOT NULL,
 [LendDate] DATE NOT NULL DEFAULT GETDATE(),
 [LendedBy] INT NOT NULL,
 CONSTRAINT fk_Member_MemberID FOREIGN KEY([MemberID])
	REFERENCES Member.Members([MemberID])
	ON DELETE CASCADE
	ON UPDATE CASCADE,
 CONSTRAINT fk_Member_BookID FOREIGN KEY([BookID])
	REFERENCES Book.Books([BookID])
	ON DELETE CASCADE
	ON UPDATE CASCADE,
 CONSTRAINT fk_Member_LendedBy FOREIGN KEY([LendedBy])
	REFERENCES Employee.Employees([EmployeeID])
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
CREATE CLUSTERED INDEX BorrowedIndex
ON Book.BorrowedBooks(MemberID)
GO

USE MN_PrivateLibrary
CREATE TABLE Employee.Users
(
ID INT NOT NULL IDENTITY(1,1),
EmployeeID INT NOT NULL,
[Login] NVARCHAR(50) NOT NULL UNIQUE,
[Password] NVARCHAR(50) NOT NULL,
[Disabled] BIT NOT NULL,
CONSTRAINT PK_Users_ID primary key (ID),
CONSTRAINT fk_Users_EmployeeID FOREIGN KEY([EmployeeID])
	REFERENCES Employee.Employees(EmployeeID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO