CREATE PROCEDURE [dbo].[UserUpdate]
(
@UserId int = null OUTPUT,
@Login varchar(20),
@Password varchar(20) = '',
@UserRoleId int = null
)
AS

BEGIN
	IF @UserId is null
	BEGIN
		INSERT [User]([Login], [Password], UserRoleId)
		VALUES (@Login, @Password, @UserRoleId)
		
		SET @UserId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE [User]
		SET 
			UserRoleId = @UserRoleId
		WHERE UserId = @UserId
	END
	
END
