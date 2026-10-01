SET NOCOUNT ON;
DECLARE @db sysname;
DECLARE dbs CURSOR FOR SELECT name FROM sys.databases WHERE name IN ('Live24','Next23','Next25') ORDER BY name;
OPEN dbs; FETCH NEXT FROM dbs INTO @db;
WHILE @@FETCH_STATUS = 0
BEGIN
  DECLARE @sql nvarchar(max) = N'
  USE ' + QUOTENAME(@db) + N';
  SELECT ''' + @db + N''' AS db, ''CO_SET.SL_AMT_TYPE'' AS probe, ISNULL(NULLIF(LTRIM(RTRIM(SL_AMT_TYPE)),''''),''<blank>'') AS value, COUNT(*) AS n FROM CO_SET GROUP BY ISNULL(NULLIF(LTRIM(RTRIM(SL_AMT_TYPE)),''''),''<blank>'');
  SELECT ''' + @db + N''' AS db, ''AC_GROUP rows per company'' AS probe, CO_CODE AS value, COUNT(*) AS n FROM AC_GROUP GROUP BY CO_CODE;
  SELECT ''' + @db + N''' AS db, ''BOOK_DATA code length'' AS probe, CAST(LEN(CO_BOOK) AS varchar(5)) AS value, COUNT(*) AS n FROM BOOK_DATA GROUP BY LEN(CO_BOOK);
  SELECT ''' + @db + N''' AS db, ''AC_DATA LEDR_KEY length (sales books)'' AS probe, CAST(LEN(a.LEDR_KEY) AS varchar(5)) AS value, COUNT(*) AS n
    FROM AC_DATA a JOIN BOOK_DATA b ON b.CO_CODE=a.CO_CODE AND b.CO_BOOK=a.CO_BOOK AND b.LC_CODE=a.LC_CODE WHERE b.MAIN_BOOK=''SALES'' GROUP BY LEN(a.LEDR_KEY);
  SELECT ''' + @db + N''' AS db, ''SL_DATA.AC_NAME filled'' AS probe, CASE WHEN LEN(LTRIM(RTRIM(ISNULL(AC_NAME,'''')))) > 0 THEN ''filled'' ELSE ''blank'' END AS value, COUNT(*) AS n FROM SL_DATA GROUP BY CASE WHEN LEN(LTRIM(RTRIM(ISNULL(AC_NAME,'''')))) > 0 THEN ''filled'' ELSE ''blank'' END;
  SELECT ''' + @db + N''' AS db, ''SL_DATA.MOB_ENTRY_SAVE'' AS probe, ISNULL(NULLIF(MOB_ENTRY_SAVE,''''),''<blank>'') AS value, COUNT(*) AS n FROM SL_DATA GROUP BY ISNULL(NULLIF(MOB_ENTRY_SAVE,''''),''<blank>'');
  SELECT ''' + @db + N''' AS db, ''SL_DATA.EMP_CODE filled'' AS probe, CASE WHEN LEN(LTRIM(RTRIM(ISNULL(EMP_CODE,'''')))) > 0 THEN ''filled'' ELSE ''blank'' END AS value, COUNT(*) AS n FROM SL_DATA GROUP BY CASE WHEN LEN(LTRIM(RTRIM(ISNULL(EMP_CODE,'''')))) > 0 THEN ''filled'' ELSE ''blank'' END;
  SELECT ''' + @db + N''' AS db, ''desktop table count'' AS probe, ''user tables'' AS value, COUNT(*) AS n FROM sys.tables;';
  BEGIN TRY EXEC sp_executesql @sql; END TRY BEGIN CATCH SELECT @db AS db, 'ERROR' AS probe, ERROR_MESSAGE() AS value, 0 AS n; END CATCH;
  FETCH NEXT FROM dbs INTO @db;
END
CLOSE dbs; DEALLOCATE dbs;
USE NextMain;
SELECT 'NextMain' AS db, 'MENU_DATA rows' AS probe, 'all' AS value, COUNT(*) AS n FROM MENU_DATA;
