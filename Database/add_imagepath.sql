-- Migration Script: Add ImagePath column to Cars table
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ImagePath' AND Object_ID = Object_ID(N'Cars'))
BEGIN
    ALTER TABLE Cars ADD ImagePath NVARCHAR(255) NULL;
    PRINT 'ImagePath column added to Cars table successfully.';
END
ELSE
BEGIN
    PRINT 'ImagePath column already exists.';
END
GO
