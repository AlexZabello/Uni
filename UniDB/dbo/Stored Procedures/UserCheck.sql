CREATE PROCEDURE [dbo].[UserCheck]
(
@Login varchar(20),
@Password varchar(20),
@UserId int OUTPUT,
@UserRoleId int = null OUTPUT
)
AS

BEGIN
	SELECT @UserRoleId = u.UserRoleId
		  ,@UserId = u.UserId
	FROM [User] as u
	WHERE 
		CAST(u.Login as varbinary(20)) = CAST(@Login as varbinary(20)) 
		AND CAST(u.Password as varbinary(20)) = CAST(@Password as varbinary(20))
	
RETURN
END
