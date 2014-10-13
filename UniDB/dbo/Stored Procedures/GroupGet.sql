
CREATE PROCEDURE [dbo].[GroupGet]
(
@GroupId int
)
AS
BEGIN
SELECT g.GroupId
	  ,g.Name
	  ,g.SubjectId
	  ,g.TeacherId
FROM [Group] g
WHERE g.GroupId = @GroupId
END
