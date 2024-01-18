-- Members Table
CREATE TABLE Members (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Address VARCHAR(255) NOT NULL,
	City VARCHAR(255),
	Province VARCHAR(225),
	Country VARCHAR(225),
    PostalCode VARCHAR(10),
    Phone VARCHAR(20),
    Email VARCHAR(100),
	MemberPassword NVARCHAR(255) NOT NULL,
	Salt NVARCHAR(255) NOT NULL,
    DateOfBirth DATE,
    MembershipType VARCHAR(20),
    Sponsor1ID INT,
    Sponsor2ID INT,
    ApplicationStatus VARCHAR(20),
    DateJoined DATE,
	Prospective INT
);

Drop Column ApplicantName;

--Drop Table Members
CREATE TABLE ClubMemberApplications (
    ApplicationID INT IDENTITY(1,1)PRIMARY KEY,
    ApplicantName VARCHAR(50) NOT NULL,
    Sponsor1Name VARCHAR(100) NOT NULL,
    Sponsor2Name VARCHAR(100) NOT NULL,
    ApplicationStatus VARCHAR(20),
    ApplicationDate DATE,
	ApplicationFormFile VARBINARY(MAX)
);
--ALTER TABLE ClubMemberApplications
--ADD ApplicantName VARCHAR(50) NOT NULL 

-- TeeTimes Table
CREATE TABLE TeeTimes (
    TeeTimeID INT PRIMARY KEY,
    MemberID INT,
    Date DATE,
    TeeTime TIME,
    NumberOfPlayers INT,
    ReservationStatus VARCHAR(20),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
);

-- StandingTeeTimeRequests Table
--CREATE TABLE StandingTeeTimeRequests (
--    RequestID INT IDENTITY(1,1) PRIMARY KEY,
--    MemberID INT,
--    RequestedDayOfWeek VARCHAR(20),
--    RequestedTeeTime TIME,
--    RequestedStartDate DATE,
--    RequestedEndDate DATE,
--    PriorityNumber INT,
--    ApprovedTeeTime TIME,
--    ApprovedBy VARCHAR(50),
--    ApprovedDate DATE,
--    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
--);

-- Employees Table
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Position VARCHAR(50) NOT NULL,
    HireDate DATE NOT NULL
);

-- SpecialEvents Table
--CREATE TABLE SpecialEvents (
--    EventID INT PRIMARY KEY,
--    EventName VARCHAR(100),
--    EventDate DATE,
--    Restrictions VARCHAR(255)
--);

-- Scores Table
CREATE TABLE Scores (
    ScoreID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT,
    Date DATE,
    GolfCourse VARCHAR(100),
    CourseRating DECIMAL(4, 2),
    SlopeRating INT,
    Hole1Score INT,
    Hole2Score INT,
	Hole3Score INT,
	Hole4Score INT,
	Hole5Score INT,
	Hole6Score INT,
	Hole7Score INT,
	Hole8Score INT,
	Hole9Score INT,
	Hole10Score INT,
	Hole11Score INT,
	Hole12Score INT,
	Hole13Score INT,
	Hole14Score INT,
	Hole15Score INT,
	Hole16Score INT,
	Hole17Score INT,
	Hole18Score INT,
    TotalScore INT,
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

-- Memberships Table
CREATE TABLE Memberships (
    MembershipID INT PRIMARY KEY,
    MemberID INT,
    MembershipType VARCHAR(20),
    ShareholderStatus VARCHAR(20),
    MembershipFee DECIMAL(8, 2),
    SharePurchasePrice DECIMAL(8, 2),
    EntranceFee DECIMAL(8, 2),
    PaymentStatus VARCHAR(20),
    PaymentDueDate DATE,
    FoodAndBeverageCharge DECIMAL(8, 2),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

-- Handicaps Table
--CREATE TABLE Handicaps (
--    HandicapID INT PRIMARY KEY,
--    MemberID INT,
--    HandicapIndex DECIMAL(4, 2),
--    Last20Average DECIMAL(4, 2),
--    Best8Average DECIMAL(4, 2),
--    Last20RoundScores TEXT,
--    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
--);

Create Procedure CreateApplication (@FirstName varchar(50), @LastName VARCHAR(50),
									@Address VARCHAR(255),  @City VARCHAR(255),
									@Province VARCHAR(255), @Country VARCHAR(255),
									@PostalCode VARCHAR(10),@Phone VARCHAR(20),
									@Email VARCHAR(100), @MemberPassword NVARCHAR(255),
									@DateOfBirth DATE,   @MembershipType VARCHAR(20),
									@Sponsor1ID INT,     @Sponsor2ID INT,
									@Salt NVARCHAR(225), @ApplicationStatus VARCHAR(20),
									@DateJoined DATE, @ApplicationFile VARBINARY(max))
AS
	IF @FirstName is NULL 
	 RAISERROR ('The FirstName Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @LastName IS NULL 
	 RAISERROR ('The LastName Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @Address IS NULL 
	 RAISERROR ('The Address Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @Phone IS NULL 
	 RAISERROR ('The Phone Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @Email IS NULL 
	 RAISERROR ('The Email Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @MemberPassword IS NULL 
	 RAISERROR ('The MemberPassword Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @Sponsor1ID IS NULL 
	 RAISERROR ('The Sponsor1ID Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @Sponsor2ID IS NULL 
	 RAISERROR ('The Sponsor2ID Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @DateOfBirth IS NULL 
	 RAISERROR ('The DateOfBirth Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @MembershipType IS NULL 
	 RAISERROR ('The MembershipType Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF NOT EXISTS (SELECT * FROM Members WHERE MemberID = @Sponsor1ID AND  MembershipType = 'Shareholder') 
	 RAISERROR ('Sponsor Member 1 is not a Sponsor in Our Club ~ INSERT ERROR',0,1)
	ELSE IF NOT EXISTS (SELECT * FROM Members WHERE MemberID = @Sponsor2ID AND  MembershipType = 'Shareholder')	
     RAISERROR ('Sponsor Member 2 is not a Sponsor in Our Club ~ INSERT ERROR',0,1)
	ELSE
	BEGIN
		INSERT INTO Members (
				FirstName,
				LastName,
				Address,
				City,
				Province,
				Country,
				PostalCode,
				Phone,
				Email,
				MemberPassword,
				Salt,
				DateOfBirth,
				MembershipType,
				Sponsor1ID,
				Sponsor2ID,
				ApplicationStatus,
				DateJoined,
				Prospective)

		VALUES (@FirstName,
				@LastName,
				@Address,
				@City,
				@Province,
				@Country,
				@PostalCode,
				@Phone,
				@Email,
				@MemberPassword,
				@Salt,
				@DateOfBirth,
				@MembershipType,
				@Sponsor1ID,
				@Sponsor2ID,
				@ApplicationStatus,
				@DateJoined,
				1)
		DECLARE @Sponsor1Name VARCHAR(255);
		DECLARE @Sponsor2Name VARCHAR(255);

	    SELECT @Sponsor1Name = FirstName +' ' + LastName FROM Members WHERE MemberID = @Sponsor1ID
		SELECT @Sponsor2Name =  FirstName +' ' + LastName FROM Members WHERE MemberID = @Sponsor2ID
		INSERT INTO ClubMemberApplications(
		Sponsor1Name,
		Sponsor2Name,
		ApplicationStatus,
		ApplicationDate,
		ApplicationFormFile,
		ApplicantName)

		VALUES(
		@Sponsor1Name,
		@Sponsor2Name,
		@ApplicationStatus,
		@DateJoined,
		@ApplicationFile,
		@FirstName + ' ' +@LastName)
	END
--Drop Procedure CreateApplication

CREATE PROCEDURE BookTeeTime(@PlayerID INT, @Date DATE, @Time TIME, @NumberOFPlayers INT)
AS
 IF @PlayerID is NULL
  RAISERROR('The Player ID is Required',16,1)
 ELSE IF @Date IS NULL
  RAISERROR('The Date is Required',16,1)
 ELSE IF @Time IS NULL
  RAISERROR ('The Time is Required',16,1)
 ELSE IF @NumberOFPlayers IS NULL
  RAISERROR('The Number of Players Is Required',16,1)
BEGIN
	IF @NumberOFPlayers > 3
	
	 INSERT INTO TeeTimes(
	 MemberID,
	 Date,
	 TeeTime,
	 NumberOfPlayers,
	 ReservationStatus)

	 VALUES(
	 @PlayerID,
	 @Date,
	 @Time,
	 @NumberOFPlayers,
	 'Reserved')
	 ELSE 
	 INSERT INTO TeeTimes(
	 MemberID,
	 Date,
	 TeeTime,
	 NumberOfPlayers,
	 ReservationStatus)

	 VALUES(
	 @PlayerID,
	 @Date,
	 @Time,
	 @NumberOFPlayers,
	 'Open')
END




	INSERT INTO Members (
    FirstName,
    LastName,
    Address,
    City,
    Province,
    Country,
    PostalCode,
    Phone,
    Email,
    MemberPassword,
    Salt,
    DateOfBirth,
    MembershipType,
    Sponsor1ID,
    Sponsor2ID,
    ApplicationStatus,
    DateJoined
)
VALUES (
    'Eric',
    'Ekwom',
    '123 Main St',
    'Anytown',
    'Province1',
    'Country1',
    'A1B 2C3',
    '555-1234',
    'ekwom.doe@example.com',
    'hashed_password', -- Replace with your hashed password
    'random_salt',     -- Replace with your random salt
    '1990-01-01',
    'ShareHolder',            -- Replace with the desired membership type
    123,               -- Replace with an actual Sponsor1ID
    456,               -- Replace with an actual Sponsor2ID
    'Approved',         -- Replace with the desired application status
    GETDATE()          -- Use the current date and time
);

-- Execute the stored procedure with random values
EXEC CreateApplication 
    'John',
    'Doe',
    '123 Main St',
    'Anytown',
    'Province1',
    'Country1',
    'A1B 2C3',
    '555-1234',
    'john.doe@example.com',
    'hashed_password',
    '1990-02-25',  -- Correct date format (YYYY-MM-DD)
    'Gold',
    1,  -- Replace with an actual Sponsor1ID
    2,  -- Replace with an actual Sponsor2ID
    'random_salt',
    'Pending',
    '2023-02-25';  -- C

CREATE PROCEDURE GetMember(@Email NVARCHAR(100))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN

    IF @Email IS NULL
        RAISERROR('Email Cannot BE Null', 16, 1);
	ELSE
	SELECT * FROM Members WHERE Email = @Email
IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Get User - Find error: Users table.', 16, 1)
	END
RETURN @ReturnCode

Exec GetMember 'ekwomnick@gmail.com'

Delete From Members where Email = 'ekwomnick@gmail.com'