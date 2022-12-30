CREATE PROCEDURE [dbo].[sp_InsertUser]
	@FirstName nvarchar(MAX),
	@LastName nvarchar(MAX)
AS
begin
	insert into dbo.[User] (FirstName,LastName)
	values (@FirstName,@LastName);
end
