Alter FUNCTION dbo.VerifyAgeCompletion(@birthDate DATE, @age INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @result NVARCHAR(MAX);

    -- Kişinin doğum tarihinden bugüne kadar geçen yılı, ayı ve günü hesapla
    DECLARE @yearsPassed INT = DATEDIFF(YEAR, @birthDate, GETDATE());
    DECLARE @monthsPassed INT = DATEDIFF(MONTH, @birthDate, GETDATE());
    DECLARE @daysPassed INT = DATEDIFF(DAY, @birthDate, GETDATE());

    -- Eğer kişi henüz yıl, ay ve gün olarak yaşını doldurmamışsa
    IF (@yearsPassed < @age)
    BEGIN
        SET @result = 'Kişi henüz yıl, ay ve gün olarak yaşını doldurmamıştır';
    END
    -- Eğer kişi yıl olarak yaşını doldurmuş ama ay ve gün olarak doldurmamışsa
    ELSE IF (@yearsPassed = @age AND @monthsPassed % 12 > 0)
    BEGIN
        SET @result = 'Yıl olarak doldurmuştur, ay ve gün olarak doldurmamıştır';
    END
    -- Eğer kişi yıl ve ay olarak yaşını doldurmuş ama gün olarak doldurmamışsa
    ELSE IF (@yearsPassed = @age AND @monthsPassed % 12 = 0 AND @daysPassed > 0)
    BEGIN
        SET @result = 'Yıl ve ay olarak doldurmuştur, gün olarak doldurmamıştır';
    END
    -- Diğer durumlar için
    ELSE
    BEGIN
        SET @result = 'Kişi yaşını doldurmuştur';
    END

    -- Sonuç mesajını döndür
    RETURN @result;
END;




SELECT dbo.VerifyAgeCompletion('1990-01-01', 32) AS Result1;
SELECT dbo.VerifyAgeCompletion('1985-08-15', 40) AS Result2;
SELECT dbo.VerifyAgeCompletion('2000-01-30', 24) AS Result3;
