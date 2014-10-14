CREATE PROCEDURE [dbo].[TeacherGetByUser]
(
@Login varchar(20)
)
AS
SELECT t.FirstName
	  ,t.LastName
	  ,t.SubjectId
	  ,t.TeacherId
	  ,t.UserId
FROM Teacher t
	JOIN [User] u
	ON t.UserId = u.UserId
WHERE u.Login = @Login