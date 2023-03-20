create trigger loggingUsers
on AspNetUsers
after INSERT AS
begin

insert into Users (SurName,UserName)
        values ((SELECT SUBSTRING(Email,0,CHARINDEX('@',Email)) from AspNetUsers where Id =(select Id from Inserted)),(Select UserName from AspNetUsers where Id =(select Id from Inserted))
		);

end;

