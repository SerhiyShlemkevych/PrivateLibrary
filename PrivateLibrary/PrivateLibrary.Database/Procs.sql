USE MN_PrivateLibrary;
GO
--Book
CREATE PROCEDURE spAddBook
	@BookID INT,
	@Name NVARCHAR(100),
	@Author NVARCHAR(50),
	@Gendre NVARCHAR(50),
	@Year INT,
	@ISBN NVARCHAR(100),
	@Amount INT,
	@Floor INT,
	@Shelf NVARCHAR(10)
AS
	DECLARE @LocationID INT = (SELECT BookLocationID FROM Book.BooksLocation
							   WHERE [Floor] = @Floor AND [Shelf] = @Shelf)
	INSERT INTO Book.Books
	VALUES (@Name,@Author,@Gendre,@Year,@ISBN,@Amount,@LocationID)
GO
CREATE PROCEDURE spDeleteBook
	@BookID INT
AS
	DELETE FROM Book.Books
	WHERE Books.BookID = @BookID
GO
CREATE PROCEDURE spUpdateBook
	@BookID INT,
	@Name NVARCHAR(100),
	@Author NVARCHAR(50),
	@Gendre NVARCHAR(50),
	@Year INT,
	@ISBN NVARCHAR(100),
	@Amount INT,
	@Floor INT,
	@Shelf NVARCHAR(10)
AS	
	DECLARE @ID INT = (SELECT TOP 1 BookLocationID FROM Book.BooksLocation
					   WHERE [Floor] = @Floor AND [Shelf] = @Shelf);
	UPDATE Book.Books
	SET [Name] = @Name,
		[Author] = @Author,
		[Gendre] = @Gendre,
		[Year] = @Year,
		[ISBN] = @ISBN,
		[Amount] = @Amount,
		[BookLocationID] = @ID
	WHERE BookID = @BookID;
GO
CREATE PROCEDURE spGetAllBooks
AS
	SELECT [B].[BookID], [B].[Name], [B].[Author], [B].[Gendre], [B].[Year], [B].[ISBN], [B].[Amount], [BL].[Floor], [BL].[Shelf]
	FROM Book.Books B INNER JOIN Book.BooksLocation BL
	ON B.BookLocationID = BL.BookLocationID;
GO

--Booklocation
CREATE PROCEDURE spGetAllLocations
AS
	SELECT [BookLocationID], [Floor], [Shelf]
	FROM Book.BooksLocation;
GO

--Member
CREATE PROCEDURE spGetAllMembers
AS
	SELECT [M].[MemberID], [M].[FirstName], [M].[LastName], [M].[Email], [M].[PhoneNumber], [M].[Gender], [M].[City], 
		   [M].[JoinDate], [M].[SubscriptionStartDate], [M].[CurrentBookAmount], [MT].[Name] AS MembershipName
	FROM Member.Members M INNER JOIN Member.MembershipType MT
	ON M.MembershipTypeID = MT.MembershipID;
GO
CREATE PROCEDURE spAddMember
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(50),
	@Gender NVARCHAR(50),
	@City NVARCHAR(50),
	@MembershipName NVARCHAR(50)
AS
	DECLARE @MembershipTypeID INT;
	SET @MembershipTypeID = (SELECT MembershipID 
				FROM Member.MembershipType
				WHERE Name = @MembershipName);
	INSERT INTO Member.Members
	VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@Gender,@City,GETDATE(),GETDATE(),0,@MembershipTypeID)
GO
CREATE PROCEDURE spRenewMembership
	@MemberID INT,
	@MembershipName NVARCHAR(50)
AS
	DECLARE @MembershipTypeID  INT = (SELECT MembershipID 
								FROM Member.MembershipType
								WHERE Name = @MembershipName);
	UPDATE Member.Members
	SET [SubscriptionStartDate] = GETDATE(),
		[MembershipTypeID] = @MembershipTypeID
	WHERE MemberID = @MemberID;
GO

CREATE PROCEDURE spDeleteMember
	@MemberID INT
AS
	DELETE FROM Member.Members
	WHERE Members.MemberID = @MemberID
GO

CREATE PROCEDURE spUpdateMember
	@MemberID INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(50),
	@Gender NVARCHAR(50),
	@City NVARCHAR(50)
AS	
	UPDATE Member.Members
	SET [FirstName] = @FirstName,
		[LastName] = @LastName,
		[Email] = @Email,
		[PhoneNumber] = @PhoneNumber,
		[Gender] = @Gender,
		[City] = @City
	WHERE MemberID = @MemberID;
GO
--Membership
CREATE PROCEDURE spGetAllMembershipTypes
AS
	SELECT [MembershipID],[Name],[MaxBookAmount],[MonthPlan],[PricePerMonth],[OverdueDayLimit],[OverdueFees]
	FROM Member.MembershipType;
GO

--User
CREATE PROCEDURE spGetUserByLogin
	@Login NVARCHAR(50),
	@Password NVARCHAR(50)
AS
	SELECT EmployeeID
	FROM Employee.Users
	WHERE [Login] = @Login and [Password] = @Password and [Disabled] <> 1;
GO
CREATE FUNCTION dbo.MD5PasswordHash(@Password VARCHAR(250))
RETURNS VARCHAR(250)
AS 
	BEGIN
	SET @Password = LOWER((SELECT CONVERT(NVARCHAR(32),HashBytes('MD5', @Password),2)));
	RETURN @Password;
	END
GO
--Borrowed
CREATE PROCEDURE spGetBorrowedList
AS
SELECT BB.[MemberID], (M.[FirstName] + ' ' + M.[LastName]) AS Member, BB.[BookID], B.[Name] AS Title, BB.[LendDate], (E.[FirstName] + ' ' + E.[LastName]) AS LendedBy
	FROM [Book].[BorrowedBooks] BB 
		INNER JOIN [Member].[Members] M ON [BB].[MemberID] = [M].[MemberID] 
			INNER JOIN [Book].[Books] B ON [BB].[BookID] = [B].[BookID]
				INNER JOIN [Employee].[Employees] E	ON [BB].[LendedBy] = E.[EmployeeID]
GO
CREATE PROCEDURE spLendABook
		@MemberID INT,
		@BookID	INT,
		@LendedBy INT
AS
DECLARE @MaxBookAmount INT;
DECLARE @CurrentBookAmount INT;
DECLARE @OverdueLimit INT;
	SELECT @CurrentBookAmount = M.CurrentBookAmount, @MaxBookAmount = MT.MaxBookAmount, 
		   @OverdueLimit = MT.OverdueDayLimit	
	FROM Member.Members M INNER JOIN Member.MembershipType MT
	ON M.MembershipTypeID = MT.MembershipID
	WHERE MemberID = @MemberID;
DECLARE @BorrowedBooks INT = (SELECT BookID
							  FROM Book.BorrowedBooks
							  WHERE MemberID = @MemberID AND (DATEADD(dd,@OverdueLimit,LendDate) <= GETDATE()));
IF((@CurrentBookAmount >= @MaxBookAmount) OR @BorrowedBooks >= 1)
BEGIN
	RETURN -1;
END
DECLARE @TranName NVARCHAR(20) = 'Lend'
BEGIN TRY
	BEGIN TRANSACTION @TranName

		UPDATE Member.Members
			SET CurrentBookAmount += 1
			WHERE MemberID = @MemberID;
		UPDATE Book.Books
			SET Amount -= 1
			WHERE BookID = @BookID;	
				
		INSERT INTO Book.BorrowedBooks
		VALUES (@MemberID,@BookID,GETDATE(),@LendedBy);
	COMMIT TRANSACTION @TranName
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION @TranName
	RETURN -1
END CATCH
GO
CREATE PROCEDURE spReturnABook
		@MemberID INT,
		@BookID	INT
AS
DECLARE @TranName NVARCHAR(20) = 'Return'
BEGIN TRY
	BEGIN TRANSACTION @TranName

		UPDATE Member.Members
			SET CurrentBookAmount -= 1
			WHERE MemberID = @MemberID;
		UPDATE Book.Books
			SET Amount += 1
			WHERE BookID = @BookID;
		
		DELETE TOP(1)
		FROM Book.BorrowedBooks
		WHERE MemberID = @MemberID AND BookID = @BookID;

	COMMIT TRANSACTION @TranName
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION @TranName
	RETURN -1
END CATCH
GO


