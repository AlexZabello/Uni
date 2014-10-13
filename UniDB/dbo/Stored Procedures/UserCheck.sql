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
	WHERE u.Login = @Login AND u.Password = @Password
	
RETURN
END
