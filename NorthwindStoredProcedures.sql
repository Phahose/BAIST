
Create Procedure nekwom1.GetCustomers
As
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
Begin 
Select * From Customers
IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('newom1.GetCutomers - Get error', 16, 1)
End
		RETURN @ReturnCode

--Drop Procedure nekwom1.GetCustomers

Create Procedure nekwom1.GetCustomer(@CustomerID NCHAR(5))
As
DECLARE @ReturnCode INT
	SET @ReturnCode = 1
if(@CustomerID is Null)
	RaisError('nekwom1.GetCustomer: The Customer ID is Required',16,1)
else
Begin 
Select 
*
From Customers 
Where CustomerID =@CustomerID

IF @@ERROR = 0

					SET @ReturnCode = 0
				ELSE
					RAISERROR ('newom1.GetCutomer - Get error', 16, 1)
			END
RETURN @ReturnCode
Drop Procedure nekwom1.GetCustomer


Exec nekwom1.GetCustomers

Exec nekwom1.GetCustomer 'ANATR'

Exec nekwom1.GetCustomersByCountry 'Germany'


