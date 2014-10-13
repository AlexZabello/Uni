
CREATE PROCEDURE [dbo].[SubjectList]
AS
BEGIN
SELECT s.SubjectId
	  ,s.Name
FROM Subject s
END
