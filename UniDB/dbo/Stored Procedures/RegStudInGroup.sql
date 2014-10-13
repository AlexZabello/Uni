
CREATE PROCEDURE [dbo].[RegStudInGroup]
(
@StudentId int,
@GroupId int
)
AS
BEGIN
	INSERT StudentGroup(StudentId, GroupId)
	VALUES (@StudentId, @GroupId)
END
