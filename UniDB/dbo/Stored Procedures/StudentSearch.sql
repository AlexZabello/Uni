CREATE PROCEDURE [dbo].[StudentSearch]
(
@FirstName varchar(20) = null,
@LastName varchar(20) = null,
@SubjectId int = null,
@GroupId int = null
)
AS
BEGIN
SELECT @FirstName = LTRIM(RTRIM(ISNULL(@FirstName,''))) + '%'
SELECT @LastName = LTRIM(RTRIM(ISNULL(@LastName,''))) + '%'


SELECT s.StudentId
	  ,s.FirstName
	  ,s.LastName
	  ,s.SubjectId
	  ,sb.Name as SubjectName
	  ,g.GroupId
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
WHERE (@FirstName IS NULL OR s.FirstName LIKE @FirstName) AND
	  (@LastName IS NULL OR s.LastName LIKE @LastName) AND
	  (@SubjectId IS NULL OR s.SubjectId = @SubjectId) AND
	  (@GroupId IS NULL OR g.GroupId = @GroupId) AND
	  1=1
END
