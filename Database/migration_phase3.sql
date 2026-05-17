-- ============================================================
-- Car Rental Management System - Migration Phase 3
-- ============================================================

USE CarRentingDB;
GO

-- 1. Create DiscountCoupons Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DiscountCoupons' AND xtype='U')
BEGIN
    CREATE TABLE DiscountCoupons (
        CouponID            INT             IDENTITY(1,1)   PRIMARY KEY,
        Code                NVARCHAR(50)    NOT NULL UNIQUE,
        DiscountPercentage  DECIMAL(5,2)    NOT NULL CHECK (DiscountPercentage > 0 AND DiscountPercentage <= 100),
        IsActive            BIT             NOT NULL DEFAULT 1,
        CreatedDate         DATETIME        NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Table DiscountCoupons created.';
END
GO

-- 2. Create Reviews Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Reviews' AND xtype='U')
BEGIN
    CREATE TABLE Reviews (
        ReviewID        INT             IDENTITY(1,1)   PRIMARY KEY,
        CarID           INT             NOT NULL,
        UserID          INT             NOT NULL,
        Rating          INT             NOT NULL CHECK (Rating >= 1 AND Rating <= 5),
        Comment         NVARCHAR(MAX)   NULL,
        ReviewDate      DATETIME        NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Reviews_Cars FOREIGN KEY (CarID) REFERENCES Cars(CarID),
        CONSTRAINT FK_Reviews_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Table Reviews created.';
END
GO

-- 3. Alter Bookings Table to support Discounts
IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('Bookings') AND name = 'CouponCode'
)
BEGIN
    ALTER TABLE Bookings ADD CouponCode NVARCHAR(50) NULL;
    PRINT 'Column CouponCode added to Bookings.';
END
GO

IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('Bookings') AND name = 'DiscountAmount'
)
BEGIN
    ALTER TABLE Bookings ADD DiscountAmount DECIMAL(18,2) NULL DEFAULT 0;
    PRINT 'Column DiscountAmount added to Bookings.';
END
GO

-- Seed default coupon
IF NOT EXISTS (SELECT * FROM DiscountCoupons WHERE Code = 'WELCOME10')
BEGIN
    INSERT INTO DiscountCoupons (Code, DiscountPercentage, IsActive) VALUES ('WELCOME10', 10.00, 1);
    PRINT 'Default coupon WELCOME10 created.';
END
GO
