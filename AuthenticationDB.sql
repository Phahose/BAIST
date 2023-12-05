Create Database Systems

CREATE TABLE Users
(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    UserPassword NVARCHAR(255) NOT NULL,
    UserRole NVARCHAR(50) NOT NULL,
	Salt NVARCHAR(255) NOT NULL
);

Drop Table Users
CREATE PROCEDURE AddUser
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @UserPassword NVARCHAR(255),
    @UserRole NVARCHAR(50),
	@Salt NVARCHAR(255)
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN

    IF @Username IS NULL OR @Email IS NULL OR @UserPassword IS NULL OR @UserRole IS NULL
        RAISERROR('All parameters must have non-null values.', 16, 1);
	ELSE


    INSERT INTO Users (Username, Email, UserPassword, UserRole, Salt)
    VALUES (@Username, @Email, @UserPassword, @UserRole,@Salt);
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Users table.', 16, 1)
	END
		RETURN @ReturnCode
Drop Procedure AddUser

CREATE PROCEDURE GetUser(@Email NVARCHAR(100))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN

    IF @Email IS NULL
        RAISERROR('Email Cannot BE Null', 16, 1);
	ELSE
	SELECT * FROM Users WHERE Email = @Email
IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Get User - Find error: Users table.', 16, 1)
	END
RETURN @ReturnCode

Exec GetUser 'ekwomnick@gmail.com'
Exec AddUser 'user3','u3@gmail.com','123456','Admin'