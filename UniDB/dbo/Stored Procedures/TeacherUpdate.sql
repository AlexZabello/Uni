
CREATE PROCEDURE [dbo].[TeacherUpdate]
(
@TeacherId int = null OUTPUT,
@FirstName varchar(50),
@LastName varchar(50),
@SubjectId int,
@UserId int
)
AS
BEGIN

IF @TeacherId IS NULL
BEGIN
	INSERT Teacher(FirstName,LastName,SubjectId,UserId)
	VALUES (@FirstName, @LastName,@SubjectId, @UserId)
	
	SET @TeacherId = SCOPE_IDENTITY()
END
ELSE
BEGIN
	UPDATE Teacher
	SET FirstName = @FirstName,
		LastName = @LastName,
		SubjectId = @SubjectId,
		UserId = @UserId
	WHERE
		TeacherId = @TeacherId
END

END