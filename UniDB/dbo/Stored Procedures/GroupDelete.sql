
CREATE PROCEDURE [dbo].[GroupDelete]
(
@GroupId int
)
AS
BEGIN

DELETE [Group]
WHERE GroupId = @GroupId

END