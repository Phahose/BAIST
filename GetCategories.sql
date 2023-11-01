Create Procedure GetProducts
as
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1
begin 
	Select *from Categories
end

if @@ERROR = 0
	Set @ReturnCode = 0
else 
	RaisError('GetStudent stored procedure An Error Occured',16,1)
RETURN @ReturnCode
