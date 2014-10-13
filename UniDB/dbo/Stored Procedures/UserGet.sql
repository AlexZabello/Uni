CREATE PROCEDURE [dbo].[UserGet]
(
@UserId int
)
AS
SELECT u.UserId
	  ,u.Login
	  ,u.UserRoleId
FROM [User] as u
WHERE u.UserId = @UserId
