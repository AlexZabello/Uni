CREATE PROCEDURE [dbo].[RemoveSubjectToStudent]
(
@StudentId int,
@SubjectId int
)
AS
BEGIN
	DELETE StudentSubject
	WHERE StudentId = @StudentId AND SubjectId = @SubjectId
END
