﻿CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	select [Id], [FirstName], [LastName], [DoB], [EmailAddress]
    from [dbo].[User]
    where Id = @Id;
end
