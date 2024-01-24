CREATE TRIGGER ADD_SHIPPER
ON SHIPPERS
AFTER INSERT
AS
BEGIN
	PRINT('Kayıt Ekleme İşlemi Yapıldı')
END;

Create TRIGGER DELETE_SHIPPER
ON SHIPPERS
AFTER delete
AS
BEGIN
DECLARE @ID INT;
SELECT @ID = deleted.ShipperID from deleted
	PRINT('Kayıt Silme İşlemi Yapıldı id: '+CAST(@id AS NVARCHAR(10)))
END;


CREATE TRIGGER Update_SHIPPER
ON SHIPPERS
AFTER UPDATE
AS
BEGIN
DECLARE @ID INT;
SELECT @ID = deleted.ShipperID from deleted
	PRINT('Kayıt Guncelleme İşlemi Yapıldı id: '+CAST(@id AS NVARCHAR(10)))
END;



select * from Shippers;
delete Shippers where ShipperID =6

update Shippers set CompanyName='updated' where ShipperID =7

INSERT INTO Shippers(CompanyName)VALUES('SDDA')



