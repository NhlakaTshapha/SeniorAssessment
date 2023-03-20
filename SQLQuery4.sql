create trigger loggingPets
on Pets
after UPDATE AS
begin

    insert into Logs (UpdateDate,Operation)
        values (GetDate(),
		('Table: Pet' + ' Changes Made ='+ ' ( Old Name:' +(SELECT Name from deleted) + (' , New name:' + (SELECT Name from inserted))+' ) ' + 
		'  ,( Old Breed:' + (SELECT Breed from deleted) + (' , New Breed:' + (SELECT Breed from inserted))+' ) ' +
		' ,  ( Old Birthdate:' +(SELECT Birthdate from deleted) + (' , New Birthdate:' + (SELECT Birthdate from inserted)) +' ) ' +
		'  ,  ( Old PetOwner:' + (SELECT OwnerName from PetOwners where onwer_id=(select onwer_id from deleted)) + (' , New PetOwner:' + (SELECT OwnerName from PetOwners where onwer_id=(SELECT onwer_id from inserted)))+' ) ' +
		'  ,  ( Old AnimalType:' + CONVERT(varchar(10),(SELECT AnimalTypeID from deleted)) + (' , New AnimalType: ' + CONVERT(varchar(10),(SELECT AnimalTypeID from inserted)))+' ) '
		));

end;

drop trigger loggingPets