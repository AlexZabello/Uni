CREATE PROCEDURE [dbo].[SubjectDelete]
(
@SubjectId int
)
AS
BEGIN

DELETE Subject
WHERE SubjectId = @SubjectId

END