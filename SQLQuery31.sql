create trigger loggingOwners
on PetOwners
after UPDATE AS
begin

    insert into Logs (UpdateDate,Operation)
        values (GetDate(),
		('Table: Pet Owners ' + ' Changes Made ='+ ' ( Old Name:' +(SELECT OwnerName from deleted) + (' , New name:' + (SELECT OwnerName from inserted))+' ) ' + 
		'  ,( Old Surname:' + (SELECT Surname from deleted) + (' , New Surname:' + (SELECT Surname from inserted))+' ) ' +
		' ,  ( Old Phonenumber:' +CONVERT(varchar(50),(SELECT Phone_number from deleted)) + (' , New Phonenumber:' + CONVERT(varchar(50),(SELECT Phone_number from inserted))) +' ) ' +
		'  ,  ( Old EmailAdress:' + (SELECT Email_address from deleted) + (' , New EmailAdress:' + (SELECT Email_address from inserted))+' ) ' +
		'  ,  ( Old PostalAdress:' + (SELECT Postal_Address from deleted) + (' , New Postal_Address:' + (SELECT Postal_Address from inserted))+' ) ' +
		'  ,  ( Old ID:' + CONVERT(varchar(50),(SELECT ID_Number from deleted)) + (' , New ID:' + CONVERT(varchar(50),(SELECT ID_Number from inserted)))+' ) ' +
		'  ,  ( Old Account:' + CONVERT(varchar(50),(SELECT AccountNumber from deleted)) + (' , New Account: ' + CONVERT(varchar(50),(SELECT AccountNumber from inserted)))+' ) '
		));

end;


