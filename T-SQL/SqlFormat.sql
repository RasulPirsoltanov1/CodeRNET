CREATE FUNCTION GENERATE_PHONE_NUMBER(@NUM NVARCHAR(15))
RETURNS NVARCHAR(100)
BEGIN
  --optional
	--SET @NUM= REPLACE(REPLACE(REPLACE(@NUM, '-', ''), '(', ''), ')', '');
  DECLARE @RESULT NVARCHAR(100);
	DECLARE @LEN_OF_NUM NVARCHAR(15);
	SET @LEN_OF_NUM=LEN(@NUM);
    
    IF LEN(@NUM) = 10 AND ISNUMERIC(@NUM) = 1
    BEGIN
        SET @RESULT = '+994 (' + SUBSTRING(@NUM, 2, 2) + ') ' + SUBSTRING(@NUM, 4, 3) + ' ' + SUBSTRING(@NUM, 7, 2)+' ' + SUBSTRING(@NUM, 9, 2);
    END
	ELSE IF LEN(@NUM) = 9 AND ISNUMERIC(@NUM) = 1
	BEGIN 
		SET @RESULT = '+994 (' + SUBSTRING(@NUM, 0, 2) + '0) ' + SUBSTRING(@NUM, 3, 3) + ' ' + SUBSTRING(@NUM, 5, 2)+' ' + SUBSTRING(@NUM, 7, 2);
	END
	ELSE IF LEN(@NUM)=13 AND ISNUMERIC(@NUM)=1
	BEGIN 
		SET @RESULT = '+'+SUBSTRING(@NUM,1,3)+' ('+SUBSTRING(@NUM,5,2)+') '+SUBSTRING(@NUM,7,3)+' '+SUBSTRING(@NUM,10,2)+' '+SUBSTRING(@NUM,12,2)
	END
	ELSE IF LEN(@NUM)=14 AND SUBSTRING(@NUM,1,1)='+' AND ISNUMERIC(SUBSTRING(@NUM,2,LEN(@NUM)))=1
		SET @RESULT = SUBSTRING(@NUM,1,4)+' ('+SUBSTRING(@NUM,6,2)+') '+SUBSTRING(@NUM,8,3)+' '+SUBSTRING(@NUM,11,2)+' '+SUBSTRING(@NUM,13,2)
    ELSE
    BEGIN
        SET @RESULT = 'ERROR: {'+@NUM+'} IS INVALID FORMAT';
    END
    RETURN @RESULT;
END;


SELECT DBO.GENERATE_PHONE_NUMBER('0501112222');

SELECT DBO.GENERATE_PHONE_NUMBER('501112222');

SELECT DBO.GENERATE_PHONE_NUMBER('9940501112222');
SELECT DBO.GENERATE_PHONE_NUMBER('+9940501112222');

--ERROR CASES
SELECT DBO.GENERATE_PHONE_NUMBER('+49940501112222');
SELECT DBO.GENERATE_PHONE_NUMBER('+3142');
SELECT DBO.GENERATE_PHONE_NUMBER('++9940501112222');
SELECT DBO.GENERATE_PHONE_NUMBER('+#9940501112222');