CREATE PROCEDURE [dbo].[SetSubjectToStudent]
(
@StudentId int,
@SubjectId int
)
AS
BEGIN
	INSERT StudentSubject(StudentId, SubjectId)
	VALUES (@StudentId, @SubjectId)
END
