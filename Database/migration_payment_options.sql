USE CarRentingDB;
GO

IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('Bookings') AND name = 'PaymentMethod'
)
BEGIN
    ALTER TABLE Bookings ADD PaymentMethod NVARCHAR(50) NULL;
    PRINT 'Column PaymentMethod added to Bookings.';
END
GO
