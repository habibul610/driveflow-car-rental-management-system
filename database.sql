-- ============================================================
-- DriveFlow - Car Rental Management System
-- Master Database Setup Script
-- ============================================================

-- Step 1: Create the database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CarRentingDB')
BEGIN
    CREATE DATABASE CarRentingDB;
    PRINT 'Database CarRentingDB created successfully.';
END
GO

USE CarRentingDB;
GO

-- ============================================================
-- Step 2: Create Tables
-- ============================================================

-- Users Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users (
        UserID          INT             IDENTITY(1,1)   PRIMARY KEY,
        FullName        NVARCHAR(100)   NOT NULL,
        Username        NVARCHAR(50)    NOT NULL UNIQUE,
        Email           NVARCHAR(150)   NOT NULL UNIQUE,
        Phone           NVARCHAR(15)    NOT NULL,
        PasswordHash    NVARCHAR(255)   NOT NULL,
        Role            NVARCHAR(20)    NOT NULL CHECK (Role IN ('Admin', 'Customer')),
        RegistrationDate DATETIME       NOT NULL DEFAULT GETDATE(),
        IsActive        BIT             NOT NULL DEFAULT 1
    );
    PRINT 'Table Users created.';
END
GO

-- Cars Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')
BEGIN
    CREATE TABLE Cars (
        CarID       INT             IDENTITY(1,1)   PRIMARY KEY,
        Brand       NVARCHAR(50)    NOT NULL,
        Model       NVARCHAR(50)    NOT NULL,
        Year        INT             NOT NULL,
        Color       NVARCHAR(30)    NOT NULL,
        PlateNumber NVARCHAR(20)    NOT NULL UNIQUE,
        DailyRate   DECIMAL(10,2)   NOT NULL,
        Status      NVARCHAR(20)    NOT NULL DEFAULT 'Available'
                    CHECK (Status IN ('Available', 'Rented', 'Maintenance')),
        AddedDate   DATETIME        NOT NULL DEFAULT GETDATE(),
        ImagePath   NVARCHAR(MAX)   NULL
    );
    PRINT 'Table Cars created.';
END
GO

-- Bookings Table (Includes PaymentMethod and Coupons)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bookings' AND xtype='U')
BEGIN
    CREATE TABLE Bookings (
        BookingID           INT             IDENTITY(1,1)   PRIMARY KEY,
        UserID              INT             NOT NULL,
        CarID               INT             NOT NULL,
        PickupDate          DATETIME        NOT NULL,
        ExpectedReturnDate  DATETIME        NOT NULL,
        ActualReturnDate    DATETIME        NULL,
        Status              NVARCHAR(20)    NOT NULL DEFAULT 'Pending'
                            CHECK (Status IN ('Pending', 'Active', 'Completed', 'Cancelled')),
        TotalAmount         DECIMAL(10,2)   NULL,
        BookingDate         DATETIME        NOT NULL DEFAULT GETDATE(),
        Notes               NVARCHAR(500)   NULL,
        PaymentMethod       NVARCHAR(50)    NULL, -- New Column
        CouponCode          NVARCHAR(20)    NULL, -- New Column
        DiscountAmount      DECIMAL(10,2)   NULL, -- New Column
        CONSTRAINT FK_Bookings_Users FOREIGN KEY (UserID) REFERENCES Users(UserID),
        CONSTRAINT FK_Bookings_Cars  FOREIGN KEY (CarID)  REFERENCES Cars(CarID)
    );
    PRINT 'Table Bookings created.';
END
GO

-- Billing Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Billing' AND xtype='U')
BEGIN
    CREATE TABLE Billing (
        BillID      INT             IDENTITY(1,1)   PRIMARY KEY,
        BookingID   INT             NOT NULL UNIQUE,
        DaysRented  INT             NOT NULL,
        DailyRate   DECIMAL(10,2)   NOT NULL,
        BaseCost    DECIMAL(10,2)   NOT NULL,
        LateFee     DECIMAL(10,2)   NOT NULL DEFAULT 0,
        TotalAmount DECIMAL(10,2)   NOT NULL,
        BillDate    DATETIME        NOT NULL DEFAULT GETDATE(),
        PaymentStatus NVARCHAR(20)  NOT NULL DEFAULT 'Unpaid',
        CONSTRAINT FK_Billing_Bookings FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
    );
    PRINT 'Table Billing created.';
END
GO

-- DiscountCoupons Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DiscountCoupons' AND xtype='U')
BEGIN
    CREATE TABLE DiscountCoupons (
        CouponID            INT             IDENTITY(1,1)   PRIMARY KEY,
        Code                NVARCHAR(20)    NOT NULL UNIQUE,
        DiscountPercentage  DECIMAL(5,2)    NOT NULL,
        IsActive            BIT             NOT NULL DEFAULT 1,
        CreatedDate         DATETIME        NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Table DiscountCoupons created.';
END
GO

-- ============================================================
-- Step 3: Seed Default Admin Account
-- Password: Admin@123
-- ============================================================
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash, Role)
    VALUES (
        'System Administrator',
        'admin',
        'admin@driveflow.com',
        '01700000000',
        '$2a$11$H8PjV1NremXrYocjJuOzfeszzukWfd0DR9/tu9y.Q0CctxyRJDXtG',
        'Admin'
    );
    PRINT 'Default admin created: admin | Admin@123';
END
GO

-- ============================================================
-- Step 4: Seed Sample Data
-- ============================================================

-- Sample Cars
IF NOT EXISTS (SELECT * FROM Cars WHERE PlateNumber = 'DHA-KA-1234')
BEGIN
    INSERT INTO Cars (Brand, Model, Year, Color, PlateNumber, DailyRate, Status)
    VALUES
        ('Toyota',  'Corolla',    2020, 'White',  'DHA-KA-1234', 2500.00, 'Available'),
        ('Honda',   'Civic',      2021, 'Silver', 'DHA-KA-5678', 3000.00, 'Available'),
        ('Nissan',  'X-Trail',    2019, 'Black',  'DHA-KA-9101', 4500.00, 'Available'),
        ('Toyota',  'RAV4',       2022, 'Blue',   'DHA-KA-1121', 5000.00, 'Available'),
        ('Suzuki',  'Swift',      2020, 'Red',    'DHA-KA-5161', 2000.00, 'Available'),
        ('BMW',     '3 Series',   2023, 'White',  'DHA-KA-7181', 8000.00, 'Available');
END
GO

-- Sample Coupons
IF NOT EXISTS (SELECT * FROM DiscountCoupons WHERE Code = 'WELCOME10')
BEGIN
    INSERT INTO DiscountCoupons (Code, DiscountPercentage, IsActive)
    VALUES ('WELCOME10', 10.00, 1), ('DRIVE20', 20.00, 1);
END
GO

PRINT '============================================';
PRINT 'DriveFlow Database Setup Complete!';
PRINT '============================================';
