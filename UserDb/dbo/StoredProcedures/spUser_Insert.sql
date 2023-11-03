create procedure [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DoB dateTime2(7),
	@EmailAddress nvarchar(50),
	@Id int out
as
begin
	set nocount on;
	set @Id = 0;

    insert into [dbo].[User]
    (FirstName, LastName, DoB, EmailAddress)
    values
    (@FirstName, @LastName, @DoB, @EmailAddress);

	set @Id = SCOPE_IDENTITY();
	select @Id;
end
