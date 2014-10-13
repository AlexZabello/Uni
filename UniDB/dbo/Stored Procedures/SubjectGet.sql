
CREATE PROCEDURE [dbo].[SubjectGet]
(
@SubjectId int
)
AS
BEGIN
SELECT s.SubjectId
	  ,s.Name
FROM Subject s
WHERE s.SubjectId = @SubjectId
END
