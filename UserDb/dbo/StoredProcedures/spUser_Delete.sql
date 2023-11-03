create procedure [dbo].[spUser_Delete]
	@Id int
AS
begin
    set nocount on;

    delete from [dbo].[User]
    where Id = @Id;
end
