CREATE  TRIGGER  update_trigger3
ON PetOwners
FOR update AS
declare
@onwer_id int
    BEGIN
        IF UPDATE (OwnerName)
        BEGIN
            INSERT INTO Log (
                Name
                ,UpdateDate
                ,Operation
                )
            SELECT OwnerName
                ,GetDate() 
                ,(SELECT OwnerName from PetOwners where onwer_id = @onwer_id)
            FROM INSERTED
        END
END
GO