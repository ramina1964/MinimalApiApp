create procedure [dbo].[spUser_GetAll]
as
begin
	select [Id], [FirstName], [LastName], [DoB], [EmailAddress]
    from [dbo].[User];
end
