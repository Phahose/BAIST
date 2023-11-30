-- IIS web user IIS APPPOOL\nekwom1AppPool
-- IIS automatially adds the IIS_IUSRS membership to the worker process token at runtime

use nekwom1

sp_helpuser -- this give information about all the users in the database


Create User aspnetcore For Login [BUILTIN\IIS_IUSRS] -- adds a user to the DB 
													 -- with the name by which the user is identified inside the Database
DROP USER aspnetcore -- This is used to drop a User In the DB

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

	GRANT EXECUTE ON GETDATABASEUSER TO aspnetcore  -- grants execute privilege
	REVOKE EXECUTE ON GETDATABASEUSER FROM aspnetcore -- revokes execute privilege

	sp_help

	GRANT EXECUTE ON AddItem TO aspnetcore
	GRANT EXECUTE ON AddProgram TO aspnetcore
	GRANT EXECUTE ON AddStudent TO aspnetcore
	GRANT EXECUTE ON DeleteItem TO aspnetcore
	GRANT EXECUTE ON DeleteStudent TO aspnetcore
	GRANT EXECUTE ON GetItem TO aspnetcore
	GRANT EXECUTE ON GetItems TO aspnetcore
	GRANT EXECUTE ON GetProgram TO aspnetcore
	GRANT EXECUTE ON GetPrograms TO aspnetcore
	GRANT EXECUTE ON GetStudent TO aspnetcore
	GRANT EXECUTE ON GetStudentByProgram TO aspnetcore
	GRANT EXECUTE ON UpdateItem TO aspnetcore
	GRANT EXECUTE ON UpdateStudent TO aspnetcore