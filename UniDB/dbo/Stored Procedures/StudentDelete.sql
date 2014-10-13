CREATE PROCEDURE dbo.StudentDelete
(
@StudentId int
)
AS
BEGIN

DELETE Student
WHERE StudentId = @StudentId

END