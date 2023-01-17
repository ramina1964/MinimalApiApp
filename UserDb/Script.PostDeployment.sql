if not exists (select 1 from [dbo].[User])
begin
    insert into [dbo].[User]
    (FirstName, LastName, DoB, EmailAddress)
    values
    ('Ramin', 'Anvar', '1964-08-10', 'lion@gmail.com'),
    ('Anita', 'Halvorsen', '1972-12-10', 'Anita@outlook.com'),
    ('Hassan', 'Ranjbar', '1961-04-15', 'Hassan@yahoo.com'),
    ('David', 'Tehrani', '1967-05-18', 'David@live.com');
end
