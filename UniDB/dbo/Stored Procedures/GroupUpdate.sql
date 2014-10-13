
CREATE PROCEDURE [dbo].[GroupUpdate]
(
@GroupId int = null OUTPUT,
@Name varchar(50),
@SubjectId int,
@TeacherId int
)
AS
BEGIN

IF @GroupId IS NULL
BEGIN
	INSERT [Group](Name,SubjectId, TeacherId)
	VALUES (@Name, @SubjectId, @TeacherId)
	
	SET @GroupId = SCOPE_IDENTITY()
END
ELSE
BEGIN
	UPDATE [Group]
	SET Name = @Name,
		SubjectId = @SubjectId,
		TeacherId = @TeacherId
	WHERE
		GroupId = @GroupId
END

END