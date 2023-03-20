create trigger logging
on PetOwners
after UPDATE AS
begin

    insert into Log (Name,UpdateDate,Operation)
        values (('New name is ' + (SELECT OwnerName from inserted)),GetDate(),('Old name was' +(SELECT OwnerName from deleted)));

end;