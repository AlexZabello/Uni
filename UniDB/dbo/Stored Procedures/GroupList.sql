
CREATE PROCEDURE [dbo].[GroupList]
AS
BEGIN
SELECT g.GroupId
	  ,g.Name
	  ,g.SubjectId
	  ,sb.Name as SubjectName
	  ,g.TeacherId
	  ,t.FirstName as PFirstName
	  ,t.LastName as PLastName
FROM [Group] g
	JOIN [Subject] sb
	ON g.SubjectId = sb.SubjectId
	
	JOIN Teacher t
	ON g.TeacherId = t.TeacherId
END
