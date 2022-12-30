CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@id int
AS
begin
	Delete from dbo.[User] where Id =@id
end
