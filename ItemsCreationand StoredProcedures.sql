Use nekwom1

Create Table Item 
(
   ItemNumber INT IDENTITY (1,1) NOT NULL,
   Description VARCHAR (50)      NOT NULL,
   UnitPrice MONEY               NOT NULL
)

ALTER TABLE Item 
	ADD CONSTRAINT PK_Item PRIMARY KEY (ItemNumber)


	/*
	   Create Stored Procedure 

	   GetItems done
	   GetItem done
	   AddItem done
	   UpdateItem
	   DeleteItem done

	*/

	Create Procedure AddItem (@Description Varchar(50), @UnitPrice Money)
	As 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	 if @Description is Null 
		RAISERROR('AddItem - Required parameter: @Description', 16, 1)
	else if @UnitPrice is Null 
		RAISERROR('AddItem - Required parameter: @UnitPrice', 16, 1)
	else

		Begin 
			Insert into Item (Description, UnitPrice)
			Values(@Description,@UnitPrice)

			IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('AddProgram - INSERT error: Item table.', 16, 1)
			END
		RETURN @ReturnCode

Drop Procedure AddItem

		/*Get Items*/
	Create Procedure GetItems
		As
		DECLARE @ReturnCode INT
		SET @ReturnCode = 1



		Begin 
			Select 
				ItemNumber, Description,UnitPrice
				From 
				Item

	   IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('AddProgram - INSERT error: Item table.', 16, 1)
			END
		RETURN @ReturnCode

Drop Procedure GetItems

--GetItem

 Create Procedure GetItem(@ItemNumber INT)
 As
	DECLARE @ReturnCode INT
		SET @ReturnCode = 1

		if @ItemNumber is null
			RAISERROR('GetItem - Required parameter: @ItemNumber', 16, 1)
		else

		Begin 
			Select 
				ItemNumber, Description,UnitPrice
				From 
				Item
				Where Item.ItemNumber = @ItemNumber
			IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('AddProgram - INSERT error: Item table.', 16, 1)
			END
		RETURN @ReturnCode

Drop Procedure GetItem

Create Procedure DeleteItem(@ItemNumber INT)
As
	DECLARE @ReturnCode INT
		SET @ReturnCode = 1

		if @ItemNumber is null
		RAISERROR('DeleteItem - Required parameter: @ItemNumber', 16, 1)
		else

		Begin 
		Delete From Item
		Where Item.ItemNumber = @ItemNumber
		IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('DeleteItem - INSERT error: Item table.', 16, 1)
			END

		RETURN @ReturnCode

Drop Procedure DeleteItem

Create Procedure UpdateItem (@ItemNumber INT = NULL,@Description Varchar(50) = NULL, @UnitPrice Money = NULL)
	As 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1
	if @ItemNumber is null
	RAISERROR('UpdateItem - Required parameter: @ItemNumber', 16, 1)
	 else if @Description is Null 
		RAISERROR('AddItem - Required parameter: @Description', 16, 1)
	else if @UnitPrice is Null 
		RAISERROR('AddItem - Required parameter: @UnitPrice', 16, 1)
	else

		Begin 
		Update Item
		Set Description = @Description,
		    UnitPrice = @UnitPrice
			Where ItemNumber = @ItemNumber
			IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('UpdateItem - INSERT error: Item table.', 16, 1)
			END

		RETURN @ReturnCode



		Drop Procedure UpdateItem
		Exec AddItem "AirPod Max", "5500"
		Exec DeleteItem "18"

		Select * from Item

		Exec UpdateItem 3, 'Not Needed Description', 100000.43