
CREATE PROCEDURE [dbo].[TeacherDelete]
(
@TeacherId int
)
AS
BEGIN

DELETE Teacher
WHERE TeacherId = @TeacherId

END