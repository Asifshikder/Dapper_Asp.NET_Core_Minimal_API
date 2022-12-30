CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@Id int,
	@FirstName  nvarchar(MAX),
	@LastName  nvarchar(MAX)
AS
begin
	update dbo.[User] 
	set FirstName = @FirstName, LastName = @LastName 
	where Id =@Id
end