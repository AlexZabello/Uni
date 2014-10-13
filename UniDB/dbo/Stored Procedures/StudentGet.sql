CREATE PROCEDURE dbo.StudentGet
(
@StudentId int
)
AS
BEGIN
SELECT s.StudentId
	  ,s.FirstName
	  ,s.LastName
	  ,s.UserId
FROM Student s
WHERE s.StudentId = @StudentId
END
