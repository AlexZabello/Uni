CREATE PROCEDURE [dbo].[SubjectUpdate]
(
@SubjectId int = null OUTPUT,
@Name varchar(20)
)
AS
BEGIN

IF @SubjectId IS NULL
BEGIN
	INSERT Subject(Name)
	VALUES (@Name)
	
	SET @SubjectId = SCOPE_IDENTITY()
END
ELSE
BEGIN
	UPDATE Subject
	SET Name = @Name
	WHERE
		SubjectId = @SubjectId
END

END