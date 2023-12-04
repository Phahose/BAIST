CREATE TABLE Users
(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    UserPassword NVARCHAR(255) NOT NULL,
    UserRole NVARCHAR(50) NOT NULL
);

CREATE PROCEDURE AddUser
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @UserPassword NVARCHAR(255),
    @UserRole NVARCHAR(50)
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN

    IF @Username IS NULL OR @Email IS NULL OR @UserPassword IS NULL OR @UserRole IS NULL
        RAISERROR('All parameters must have non-null values.', 16, 1);
	ELSE


    INSERT INTO Users (Username, Email, UserPassword, UserRole)
    VALUES (@Username, @Email, @UserPassword, @UserRole);
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Users table.', 16, 1)
	END
		RETURN @ReturnCode
