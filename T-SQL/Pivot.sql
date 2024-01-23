DECLARE @DynamicPivotColumns NVARCHAR(MAX);

-- Kategorileri al
DECLARE @Cat_Names NVARCHAR(MAX);
SELECT @Cat_Names = CONCAT(@Cat_Names, '['+C.CategoryName+']', ',') FROM Categories AS C;
SET @Cat_Names = LEFT(@Cat_Names, LEN(@Cat_Names) - 1);
pRINT(@Cat_Names);

-- Dinamik PIVOT sorgusu
DECLARE @PivotQuery NVARCHAR(MAX);

SET @PivotQuery = '
    SELECT *
    FROM
    (
        SELECT CategoryName,
               COUNT(*) AS [Toplam Ürün Sayısı]
        FROM Products P
            JOIN Categories C
                ON P.CategoryID = C.CategoryID
        WHERE P.CategoryID IS NOT NULL
        GROUP BY CategoryName
    ) tbl
    PIVOT
    (
        SUM([Toplam Ürün Sayısı])
        FOR CategoryName IN (' + @Cat_Names + ')
    ) AS PivotTable;';

-- Dinamik sorguyu çalıştır
EXEC sp_executesql @PivotQuery;
