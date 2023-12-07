CREATE TABLE Customer (
	CustomerID VARCHAR(25) NOT NULL,
    FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
    Address VARCHAR(25),
    City VARCHAR(25),
    Province VARCHAR(25),
    PostalCode VARCHAR(7)
);


Drop table Customer

CREATE TABLE Item (
    ItemCode VARCHAR(6) NOT NULL,
    Description VARCHAR(50) NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    Deleted BIT NOT NULL
);

Drop table Item

CREATE TABLE Sale (
    SaleNumber INT NOT NULL,
    SaleDate DATE NOT NULL,
    Salesperson VARCHAR(25),
    CustomerName VARCHAR(25),
    SubTotal DECIMAL(10, 2),
    GST DECIMAL(10, 2),
    SaleTotal DECIMAL(10, 2)
);
ALTER TABLE Customer
ADD Deleted BIT

	ALTER TABLE Sale
DROP COLUMN CustomerName;
Drop Table Sale 

CREATE TABLE SaleItem (
    SaleNumber INT NOT NULL,
    ItemCode VARCHAR(6) NOT NULL,
    Quantity INT,
    ItemTotal DECIMAL(10, 2)
);


ALTER TABLE Customer
ADD CONSTRAINT PK_Customer PRIMARY KEY (CustomerID);

ALTER TABLE Item
ADD CONSTRAINT PK_Item PRIMARY KEY (ItemCode);

ALTER TABLE Sale
ADD CONSTRAINT PK_Sale PRIMARY KEY (SaleNumber);

ALTER TABLE SaleItem
ADD CONSTRAINT PK_SaleItem PRIMARY KEY (SaleNumber, ItemCode);

ALTER TABLE SaleItem
ADD CONSTRAINT FK_ItemCode FOREIGN KEY (ItemCode) REFERENCES Item(ItemCode);


-- Add To Inventory
Create Procedure AddToInventory (@ItemCode VARCHAR(6), @Description VARCHAR(50), @UnitPrice DECIMAL(10,2), @Deleted BIT)
AS 
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @ItemCode is NULL OR @Description is NULL OR @UnitPrice is NULL OR @Deleted is NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		INSERT INTO Item (ItemCode, Description, UnitPrice, Deleted)
		VALUES (@ItemCode,@Description,@UnitPrice,@Deleted)
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Item table.', 16, 1)
	END
		RETURN @ReturnCode
		Drop Procedure AddToInventory




		-- Update Inventory
Create Procedure UpdateInventory (@Description VARCHAR(50), @UnitPrice DECIMAL(10,2), @Deleted BIT, @ItemCode VARCHAR(6))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @Description is NULL OR @UnitPrice is NULL OR @Deleted is NULL OR @ItemCode is NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		Update Item 
		SET Description = @Description,
			UnitPrice = @UnitPrice,
			@Deleted = @Deleted
		WHERE ItemCode = @ItemCode
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('UpdateItem - INSERT error: Item table.', 16, 1)
			END

		RETURN @ReturnCode

Drop Procedure UpdateInventory


		-- Delete From Inventory
Create Procedure DeleteFromInventory (@ItemCode VARCHAR(6))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @ItemCode is NULL
		RAISERROR('Item Code Cannot be null',16,1)
	ELSE
	UPDATE Item
		SET Deleted = 0
		WHERE Item.ItemCode = @ItemCode
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('DeleteItem - Delete error: Item table.', 16, 1)
			END

		RETURN @ReturnCode

Create Procedure BringBackInventory (@ItemCode VARCHAR(6))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @ItemCode is NULL
		RAISERROR('Item Code Cannot be null',16,1)
	ELSE
	UPDATE Item
		SET Deleted = 1
		WHERE Item.ItemCode = @ItemCode
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('DeleteItem - Delete error: Item table.', 16, 1)
			END

		RETURN @ReturnCode

		-- Add Customer
Create Procedure AddCustomer (@CustomerID VARCHAR(25), 
							  @FirstName VARCHAR(25),
							  @LastName VARCHAR(25),
							  @Address VARCHAR(25),
							  @City VARCHAR(25),
							  @Province VARCHAR(25),
							  @PostalCode VARCHAR(7))
AS 
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @FirstName is NULL OR @LastName is NULL OR @Address is NULL OR @City is NULL OR @Province is NULL OR @PostalCode is NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		INSERT INTO Customer (CustomerID,FirstName, LastName, Address, City, Province, PostalCode,Deleted)
		VALUES (@CustomerID,@FirstName,@LastName,@Address,@City,@Province,@PostalCode,1)
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Customer table.', 16, 1)
	END
		RETURN @ReturnCode

Drop Procedure AddCustomer
		-- Update  Customer 
Create Procedure UpdateCustomer(@CustomerID VARCHAR(25), 
							  @FirstName VARCHAR(25),
							  @LastName VARCHAR(25),
							  @Address VARCHAR(25),
							  @City VARCHAR(25),
							  @Province VARCHAR(25),
							  @PostalCode VARCHAR(7),
							  @Deleted BIT)
AS 
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @FirstName is NULL OR @LastName is NULL OR @Address is NULL OR @City is NULL OR @Province is NULL OR @PostalCode is NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		Update
		Customer 
		SET FirstName = @FirstName, 
			LastName = @LastName, 
			Address = @Address,
			City = @City,
			Province = @Province,
			PostalCode = @PostalCode,
			Deleted = @Deleted
		WHERE CustomerID = @CustomerID

	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Customer table.', 16, 1)
	END
		RETURN @ReturnCode


		--- Delete Customer
Create Procedure DeleteCustomer (@CustomerID VARCHAR(25))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @CustomerID is NULL
		RAISERROR('Item Code Cannot be null',16,1)
	ELSE
	UPDATE Customer
		SET Deleted = 0
		WHERE CustomerID = @CustomerID
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('DeleteItem - Delete error: Customer table.', 16, 1)
			END

		RETURN @ReturnCode


-- Find Item
Create Procedure FindItem (@ItemCode VARCHAR(6))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @ItemCode is NULL
		RAISERROR('Item Code Cannot be null',16,1)
	ELSE
	SELECT * FROM Item
	WHERE ItemCode = @ItemCode AND Deleted = 1
	IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('FindItem - Find error: Item table.', 16, 1)
			END

		RETURN @ReturnCode


-- Find Customer 

Create Procedure FindCustomer (@CustomerID VARCHAR(25))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @CustomerID is NULL
		RAISERROR('CustomerID Cannot be null',16,1)
	ELSE
	SELECT * FROM Customer
	WHERE CustomerID = @CustomerID AND Deleted = 1
	IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('Fins Customer  - Find error: Customer table.', 16, 1)
			END

		RETURN @ReturnCode
		Drop procedure FindCustomer

-- Bring Back Customer
Create Procedure BringBackCustomer (@CustomerID VARCHAR(25))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @CustomerID is NULL
		RAISERROR('Customer ID Cannot be null',16,1)
	ELSE
	UPDATE Customer
		SET Deleted = 1
		WHERE CustomerID = @CustomerID
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('Bring Back Customer Error - Update error: Customer table.', 16, 1)
			END

		RETURN @ReturnCode


Exec  AddToInventory 4,'AirPods Max',700.34,1

Exec UpdateInventory'MacBook',5500.34,1,2

Exec DeleteFromInventory 4

Exec BringBackInventory 4

Exec FindItem 4

Exec AddCustomer '3','Davicdo','Oluws','Rogers Place','Toronto','Canada','T4V5V4'

Exec UpdateCustomer '1','Nicholas','Ekwom','CollAddress 123Street','Calgary','Alberta','T4V5V4',1

Exec DeleteCustomer '3'

Exec BringBackCustomer '3'

Exec FindCustomer 3

