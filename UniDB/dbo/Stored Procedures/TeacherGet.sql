
CREATE PROCEDURE [dbo].[TeacherGet]
(
@TeacherId int
)
AS
BEGIN
SELECT t.TeacherId
	  ,t.FirstName
	  ,t.LastName
	  ,t.SubjectId
	  ,t.UserId
FROM Teacher t
WHERE t.TeacherId = @TeacherId
END
