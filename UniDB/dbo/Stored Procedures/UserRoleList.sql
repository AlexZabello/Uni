
CREATE PROCEDURE [dbo].[UserRoleList]
AS
SELECT ur.UserRoleId
	  ,ur.Name
FROM UserRole as ur
