CREATE PROCEDURE dbo.StudentGet
(
@StudentId int
)
AS
BEGIN
SELECT s.StudentId
	  ,s.FirstName
	  ,s.LastName
FROM Student s
WHERE s.StudentId = @StudentId
END
