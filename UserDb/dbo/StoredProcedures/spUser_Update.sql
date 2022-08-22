CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DoB datetime2(7),
	@EmailAddress nvarchar(50)
AS
begin
    update dbo.[User]
    set
    FirstName = @FirstName,
    LastName = @LastName,
    DoB = @DoB,
    EmailAddress = @EmailAddress
    where Id = @Id;
end
