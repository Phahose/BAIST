-- IIS web user IIS APPPOOL\nekwom1AppPool
-- IIS automatially adds the IIS_IUSRS membership to the worker process token at runtime

use nekwom1

sp_helpuser

Create User aspnetcore For Login [BUILTIN\IIS_IUSRS]

CREATE PROCEDURE GetDatabaseUser
AS
	DECLARE @Returncode INT
	SET @Returncode = 1

	SELECT CURRENT_USER AS CurrentUser, -- return the name of the current user 
			SYSTEM_USER AS SystemUser, -- returns the name of the currently executing context,
			SESSION_USER AS SessionUser -- returns the name of the current context in the current databased

	IF @@ERROR = 0
		SET @Returncode = 0
	ELSE 
		RaisError('GetDatabaseUser - Database User Error.',16,1)

	Return @ReturnCode

	Exec GetDatabaseUser