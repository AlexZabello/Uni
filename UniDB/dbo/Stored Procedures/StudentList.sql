CREATE PROCEDURE [dbo].[StudentList]
AS
BEGIN
SELECT s.StudentId
	  ,s.FirstName
	  ,s.LastName
	  ,s.SubjectId
	  ,sb.Name as SubjectName
	  ,s.GroupId
	  ,g.Name as GroupName
	  ,t.FirstName as pFirstName
	  ,t.LastName as pLastName
FROM Student s
	JOIN [Subject] sb
	ON s.SubjectId = sb.SubjectId
	LEFT JOIN [Group] g
		JOIN Teacher t
		ON g.TeacherId = t.TeacherId
	ON s.GroupId = g.GroupId
END
