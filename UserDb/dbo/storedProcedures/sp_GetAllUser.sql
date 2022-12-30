CREATE PROCEDURE [dbo].[sp_GetAllUser]
as
begin
	select Id,FirstName,LastName
	from dbo.[User];
end
