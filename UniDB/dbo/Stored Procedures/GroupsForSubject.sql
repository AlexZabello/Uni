CREATE PROCEDURE [dbo].[GroupsForSubject]
	@SubjectId int
AS
SELECT v.*
FROM vGropList as v
WHERE v.SubjectId = @SubjectId
