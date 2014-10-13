CREATE PROCEDURE [dbo].[UsersList]
AS
SELECT u.UserId
	  ,u.Login
	  ,u.UserRoleId
	  ,ud.Name as UserRoleName
FROM [User] as u
	LEFT JOIN UserRole as ud
	ON u.UserRoleId = ud.UserRoleId
