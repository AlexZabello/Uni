CREATE PROCEDURE [dbo].[StudentUpdate]
(
@StudentId int = null OUTPUT,
@FirstName varchar(50),
@LastName varchar(50),
@SubjectId int
--@UserId int
)
AS
BEGIN

IF @StudentId is null
BEGIN
	INSERT Student(FirstName,LastName,SubjectId)
	VALUES (@FirstName, @LastName, @SubjectId)
	
	SET @StudentId = SCOPE_IDENTITY()
END
ELSE
BEGIN
	UPDATE Student
	SET FirstName = @FirstName,
		LastName = @LastName,
		SubjectId = @SubjectId
	WHERE
		StudentId = @StudentId
END

END