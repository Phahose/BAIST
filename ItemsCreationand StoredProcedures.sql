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
	   DeleteItem

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
					RAISERROR ('AddProgram - INSERT error: Program table.', 16, 1)
			END
		RETURN @ReturnCode

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
					RAISERROR ('AddProgram - INSERT error: Program table.', 16, 1)
			END
		RETURN @ReturnCode

 Create Procedure GetItem(@ItemNumber INT)
 As
	DECLARE @ReturnCode INT
		SET @ReturnCode = 1

		Begin 
			Select 
				ItemNumber, Description,UnitPrice
				From 
				Item
				Where Item.ItemNumber = @ItemNumber
			IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('AddProgram - INSERT error: Program table.', 16, 1)
			END
		RETURN @ReturnCode