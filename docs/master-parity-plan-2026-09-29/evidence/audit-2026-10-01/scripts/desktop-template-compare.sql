SET NOCOUNT ON;
DECLARE @db sysname, @sql nvarchar(max);
DECLARE c CURSOR FOR SELECT name FROM sys.databases WHERE name IN ('Live24','Next23','Next24','Next25') ORDER BY name;
OPEN c; FETCH NEXT FROM c INTO @db;
WHILE @@FETCH_STATUS=0 BEGIN
 SET @sql = N'USE '+QUOTENAME(@db)+N';
 SELECT '''+@db+N''' db, ''AC_GROUP checksum per CO'' probe, CO_CODE k, CAST(CHECKSUM_AGG(CHECKSUM(AC_GR, AC_GR_NAME, AC_MAIN_GR)) AS varchar(20)) v, COUNT(*) n FROM AC_GROUP GROUP BY CO_CODE;
 SELECT '''+@db+N''' db, ''BOOK_DATA by LC_CODE'' probe, LC_CODE k, CAST(SUM(CASE WHEN CUR_USE=''Y'' THEN 1 ELSE 0 END) AS varchar(10))+'' in use'' v, COUNT(*) n FROM BOOK_DATA GROUP BY LC_CODE;
 SELECT '''+@db+N''' db, ''AC_MAST code shape'' probe, CASE WHEN AC_CODE LIKE ''[0-9][0-9][0-9][0-9][0-9]'' THEN ''5-digit'' ELSE ''other'' END k, '''' v, COUNT(*) n FROM AC_MAST GROUP BY CASE WHEN AC_CODE LIKE ''[0-9][0-9][0-9][0-9][0-9]'' THEN ''5-digit'' ELSE ''other'' END;
 SELECT '''+@db+N''' db, ''default accounts 00001-00099 present'' probe, '''' k, '''' v, COUNT(*) n FROM AC_MAST WHERE AC_CODE BETWEEN ''00001'' AND ''00099'';
 SELECT '''+@db+N''' db, ''TAX_MAST checksum'' probe, CO_CODE k, CAST(CHECKSUM_AGG(CHECKSUM(TAX_CODE, TAX_NAME, TAX_PRC, TAX_AC)) AS varchar(20)) v, COUNT(*) n FROM TAX_MAST GROUP BY CO_CODE;';
 BEGIN TRY EXEC sp_executesql @sql; END TRY BEGIN CATCH SELECT @db, 'ERROR', ERROR_MESSAGE(), '', 0; END CATCH;
 FETCH NEXT FROM c INTO @db; END
CLOSE c; DEALLOCATE c;
