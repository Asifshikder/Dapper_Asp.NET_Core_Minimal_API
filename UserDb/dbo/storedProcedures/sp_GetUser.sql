CREATE PROCEDURE [dbo].[sp_GetUser]
	@id int
AS
begin
	Select Id,FirstName,LastName from dbo.[User]
	where Id =@id
end
