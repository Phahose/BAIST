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

ALTER TABLE Item
DROP COLUMN ItemCode;

ALTER TABLE Item
ADD QOH INT 
ADD ItemCode VARCHAR(6) PRIMARY KEY;

ALTER TABLE Customer
DROP COLUMN Deleted;

Drop Table Sale 
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
ADD CustomerID INT IDENTITY(1,1) PRIMARY KEY;

ALTER TABLE Customer
DROP COLUMN CustomerID;
Drop Table Sale 

CREATE TABLE SaleItem (
    SaleNumber INT NOT NULL,
    ItemCode VARCHAR(6) NOT NULL,
    Quantity INT,
    ItemTotal DECIMAL(10, 2)
);

ALTER TABLE SaleItem
ADD ItemCode VARCHAR(6) PRIMARY KEY;

ALTER TABLE SaleItem
DROP CONSTRAINT CK_SaleItemItemCodeFormat
CHECK (ItemCode LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9]' AND LEN(ItemCode) = 6);



ALTER TABLE Customer
ADD CONSTRAINT PK_Customer PRIMARY KEY (CustomerID);

ALTER TABLE Item
DROP CONSTRAINT PK__Item__3ECC0FEB4FDD3670
ADD CONSTRAINT PK_Item PRIMARY KEY (ItemCode);

-- Get Constraint Name
SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_NAME = 'SaleItem' AND COLUMN_NAME = 'ItemCode' AND CONSTRAINT_NAME LIKE 'PK%';



ALTER TABLE Sale
ADD CONSTRAINT PK_Sale PRIMARY KEY (SaleNumber);

ALTER TABLE SaleItem
ADD CONSTRAINT PK_SaleItem PRIMARY KEY (SaleNumber);

ALTER TABLE SaleItem
DROP CONSTRAINT PK_SaleItem
ADD CONSTRAINT FK_ItemCode FOREIGN KEY (ItemCode) REFERENCES Item(ItemCode);


-- Add To Inventory
Create Procedure AddToInventory (@Description VARCHAR(50), @UnitPrice DECIMAL(10,2), @Deleted INT, @ItemCode VARCHAR(6), @QOH INT)
AS 
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @ItemCode is Null or @Description is NULL OR @UnitPrice is NULL OR @Deleted is NULL OR @QOH IS NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		INSERT INTO Item (ItemCode, Description, UnitPrice, Deleted, QOH)
		VALUES (@ItemCode, @Description,@UnitPrice,@Deleted, @QOH)
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add User - INSERT error: Item table.', 16, 1)
	END
		RETURN @ReturnCode
		Drop Procedure AddToInventory


-- Update Inventory
Create Procedure UpdateInventory (@Description VARCHAR(50), @UnitPrice DECIMAL(10,2), @Deleted INT, @ItemCode VARCHAR(6), @QOH INT)
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @Description is NULL OR @UnitPrice is NULL OR @Deleted is NULL OR @ItemCode is NULL OR @QOH IS NULL
		RAISERROR('Must have a value for all of the Inputs',16,1)
	ELSE
		Update Item 
		SET Description = @Description,
			UnitPrice = @UnitPrice,
			QOH = @QOH,
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
		Drop Procedure DeleteFromInventory

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
		Drop Procedure BringBackInventory

-- Add Customer
Create Procedure AddCustomer (@FirstName VARCHAR(25),
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
		INSERT INTO Customer (FirstName, LastName, Address, City, Province, PostalCode,Deleted)
		VALUES (@FirstName,@LastName,@Address,@City,@Province,@PostalCode,1)
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR ('Add Customer - INSERT error: Customer table.', 16, 1)
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
							  @Deleted INT)
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

Drop Procedure UpdateCustomer


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
		Drop Procedure FindItem
-- Find Customer 
Create Procedure FindCustomer (@FirstName VARCHAR(25),
							   @LastName VARCHAR(25))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
BEGIN
	IF @FirstName is NULL
		RAISERROR('FirstName Cannot be null',16,1)
	ELSE IF @LastName is NULL
		RAISERROR('LastName Cannot be Null',16,1)
	ELSE
	SELECT * FROM Customer
	WHERE FirstName = @FirstName AND LastName = @LastName AND Deleted = 1
	IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('Find Customer  - Find error: Customer table.', 16, 1)
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

Create Procedure GetAllCustomers
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
	BEGIN
	SELECT * FROM Customer
	Where Deleted = 1
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('Get All Customers - SELECT error: Customer table.', 16, 1)
			END

		RETURN @ReturnCode

		Drop Procedure GetAllCustomers

Create Procedure AddSaleItem (@SaleNumber INT, 
							  @Quantity INT, 
							  @ItemTotal decimal (10,2),
							  @ItemCode VARCHAR(6))
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
	BEGIN
	IF @SaleNumber IS NULL
	RAISERROR('The Sale Number is Required',16,1)
	ELSE IF @Quantity IS NULL
	RAISERROR('The Quantity is Required',16,1)
	ELSE IF @ItemTotal IS NULL
	RAISERROR('The ItemTotal  is Required',16,1)
	ELSE IF @ItemCode IS NULL
	RAISERROR('The ItemCode is Required',16,1)
	ELSE

	INSERT INTO SaleItem(SaleNumber, Quantity,ItemTotal, ItemCode)
	VALUES (@SaleNumber,@Quantity,@ItemTotal,@ItemCode)

	UPDATE Item
	SET QOH = QOH- @Quantity
	WHERE Item.ItemCode = @ItemCode
	IF @@ERROR = 0
		SET @ReturnCode = 0
			ELSE
				RAISERROR ('Add Sale Item - Insert error: SaleItem table.', 16, 1)
			END
			RETURN @ReturnCode

			Drop Procedure AddSaleItem
CREATE PROCEDURE AddSale
	@SaleNumber INT,
    @SaleDate DATE,
    @Salesperson VARCHAR(25),
    @FirstName VARCHAR(25),
    @LastName VARCHAR(25),
    @SubTotal DECIMAL(12, 2),
    @GST DECIMAL(10, 2),
    @SaleTotal DECIMAL(10, 2)
AS
DECLARE @ReturnCode INT
	SET @ReturnCode = 1


 BEGIN
    -- Validate parameters for null values
    IF @SaleNumber IS NULL
	    OR @SaleDate IS NULL
        OR @Salesperson IS NULL
        OR @FirstName IS NULL
        OR @LastName IS NULL
        OR @SubTotal IS NULL
        OR @GST IS NULL
        OR @SaleTotal IS NULL
   
        RAISERROR('All parameters must have non-null values.', 16, 1);
 

    -- Insert into Sale table
    INSERT INTO Sale (SaleNumber,SaleDate, Salesperson, FirstName, LastName, SubTotal, GST, SaleTotal)
    VALUES (@SaleNumber,@SaleDate, @Salesperson, @FirstName, @LastName, @SubTotal, @GST, @SaleTotal)
	IF @@ERROR = 0
		SET @ReturnCode = 0
			ELSE
				RAISERROR ('Add Sale Item - Insert error: SaleItem table.', 16, 1)
			END
			RETURN @ReturnCode

			Drop Procedure AddSale

Exec GetAllCustomers

Exec  AddToInventory 3,'MacBook Pro',2300,1

Exec UpdateInventory'MacBook',5500.34,0,2

Exec DeleteFromInventory 4

Exec BringBackInventory 4

Exec FindItem 4

Exec AddCustomer 'Christine','Ekwom','CollAddress 123Street','Toronto','Canada','T4V5V4'

Exec UpdateCustomer '1','Chidubem','Ekwom','CollAddress 123Street','Calgary','Alberta','T4V5V4',1

Exec DeleteCustomer '3'

Exec BringBackCustomer '3'

Exec FindCustomer 'Joan','Ekwom'

	GRANT EXECUTE ON FindCustomer TO aspnetcore
	GRANT EXECUTE ON AddToInventory TO aspnetcore
	GRANT EXECUTE ON UpdateInventory TO aspnetcore
	GRANT EXECUTE ON DeleteFromInventory TO aspnetcore
	GRANT EXECUTE ON FindItem TO aspnetcore
	GRANT EXECUTE ON UpdateCustomer TO aspnetcore
	GRANT EXECUTE ON DeleteCustomer TO aspnetcore
	GRANT EXECUTE ON BringBackCustomer TO aspnetcore
	GRANT EXECUTE ON FindCustomer TO aspnetcore
	GRANT EXECUTE ON GetAllCustomers TO aspnetcore
	GRANT EXECUTE ON AddSaleItem TO aspnetcore
	GRANT EXECUTE ON AddSale TO aspnetcore
	GRANT EXECUTE ON AddCustomer TO aspnetcore
	