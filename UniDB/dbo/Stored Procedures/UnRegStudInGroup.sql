
CREATE PROCEDURE [dbo].[UnRegStudInGroup]
(
@StudentId int,
@GroupId int
)
AS
BEGIN
DELETE StudentGroup
	WHERE StudentId = @StudentId AND GroupId = @GroupId
END
