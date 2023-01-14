CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select [Id], [FirstName], [LastName], [DoB], [EmailAddress]
    from [dbo].[User];
end
