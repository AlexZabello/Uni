CREATE PROCEDURE [dbo].[TeacherList]
AS
BEGIN
SELECT t.TeacherId
	  ,t.FirstName
	  ,t.LastName
	  ,t.SubjectId
	  ,t.UserId
FROM Teacher t
END
