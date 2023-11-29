use nekwom1

sp_helpuser

CREATE PROCEDURE GetDatabaseUser
AS
	DECLARE @Returncode INT
	SET @Returncode = 1

	SELECT CURRENT_USER AS CurrentUser, -- return the name of the current user 
			SYSTEM_USER AS SystemUser, -- returns the name of the currently executing context,
			SESSION_USER AS SessionUser, -- returns the name of the current context in the current databased