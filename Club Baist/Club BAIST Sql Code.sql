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
    DateJoined DATE
);

-- TeeTimes Table
--CREATE TABLE TeeTimes (
--    TeeTimeID INT PRIMARY KEY,
--    MemberID INT,
--    Date DATE,
--    Time TIME,
--    NumberOfPlayers INT,
--    EmployeeID INT,
--    CartCount INT,
--    SpecialEventID INT,
--    ReservationStatus VARCHAR(20),
--    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
--    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
--    FOREIGN KEY (SpecialEventID) REFERENCES SpecialEvents(EventID)
--);

-- StandingTeeTimeRequests Table
CREATE TABLE StandingTeeTimeRequests (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT,
    RequestedDayOfWeek VARCHAR(20),
    RequestedTeeTime TIME,
    RequestedStartDate DATE,
    RequestedEndDate DATE,
    PriorityNumber INT,
    ApprovedTeeTime TIME,
    ApprovedBy VARCHAR(50),
    ApprovedDate DATE,
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

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
									@Sponsor1ID INT,     @Sponsor2ID INT)
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
	ELSE IF @DateOfBirth IS NULL 
	 RAISERROR ('The DateOfBirth Cannot Be Empty ~ INSERT ERROR',0,1)
	ELSE IF @MembershipType IS NULL 
	 RAISERROR ('The MembershipType Cannot Be Empty ~ INSERT ERROR',0,1)