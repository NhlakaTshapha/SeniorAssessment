create trigger loggingOwners
on PetOwners
after UPDATE AS
begin

    insert into Log (UpdateDate,Operation)
        values (GetDate(),
		('Old name was ' +(SELECT OwnerName from deleted) + (',New name is ' + (SELECT OwnerName from inserted)) + 
		',Old Surname was ' + (SELECT Surname from deleted) + (',New Surname is ' + (SELECT Surname from inserted)) +
		',Old Phonenumber was ' +(SELECT Phone_number from deleted) + (',New Phonenumber is ' + (SELECT Phone_number from inserted)) +
		',Old EmailAdress was ' + (SELECT Email_address from deleted) + (',New Email Adress is ' + (SELECT Email_address from inserted)) +
		',Old PostalAdress was ' + (SELECT Postal_Address from deleted) + (',New Postal_Address is ' + (SELECT Postal_Address from inserted)) +
		',Old ID was ' + (SELECT ID_Number from deleted) + (',New ID is ' + (SELECT ID_Number from inserted)) +
		',Old Account No was ' + (SELECT AccountNumber from deleted) + (',New Account No is ' + (SELECT AccountNumber from inserted))
		));

end;