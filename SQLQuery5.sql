create trigger loggingUsers
on AspNetUsers
after INSERT AS
begin

insert into Users (Name,UserName)
        values ((Select Email from AspNetUsers where Id =(select Id from Inserted)),(Select UserName from AspNetUsers where Id =(select Id from Inserted))
		);

end;