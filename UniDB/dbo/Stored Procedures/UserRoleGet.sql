
CREATE PROCEDURE [dbo].[UserRoleGet]
(
@Login varchar(20)
)
AS
SELECT ur.UserRoleId
	  ,ur.Name
FROM [UserRole] as ur
	JOIN [User] as u
	ON ur.UserRoleId = u.UserRoleId
WHERE u.Login = @Login
