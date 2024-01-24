ALTER PROCEDURE sp_AddCategoryAndProduct 
    @categoryName NVARCHAR(MAX),
    @productName NVARCHAR(MAX),
    @description NVARCHAR(MAX),
    @unitprice DECIMAL,
    @unitinstock INT
AS
BEGIN
    DECLARE @count INT;
    DECLARE @cat_Id INT;
    DECLARE @cat_Id2 INT;

    SELECT @count = COUNT(*) FROM Categories AS c WHERE TRIM(c.CategoryName) = TRIM(@categoryName);

    IF (@count > 0)
    BEGIN
        SELECT TOP 1 @cat_Id = CategoryID FROM Categories AS c WHERE TRIM(c.CategoryName) = TRIM(@categoryName);
        INSERT INTO Products (CategoryID, ProductName, UnitPrice, UnitsInStock)
        VALUES (@cat_Id, @productName, @unitprice, @unitinstock);
    END
    ELSE
    BEGIN
        INSERT INTO Categories (CategoryName, Description) VALUES (@categoryName, @description);
        SELECT TOP 1 @cat_Id2 = CategoryID FROM Categories AS c WHERE TRIM(c.CategoryName) = TRIM(@categoryName);
        INSERT INTO Products (CategoryID, ProductName, UnitPrice, UnitsInStock)
        VALUES (@cat_Id2, @productName, @unitprice, @unitinstock);
    END;
END;


sp_AddCategoryAndProduct 'Bevarages', 'test1','desc',12,232



select * from Categories;

select * from Products;


