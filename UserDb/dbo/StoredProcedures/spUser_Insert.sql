CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DoB dateTime2(7),
	@EmailAddress nvarchar(50)
AS
begin
    insert into [dbo].[User]
    (FirstName, LastName, DoB, EmailAddress)
    values
    (@FirstName, @LastName, @DoB, @EmailAddress);
end
