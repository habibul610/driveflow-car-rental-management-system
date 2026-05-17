-- ============================================================
-- Car Renting Management System - Database Setup Script
-- Run this entire script in SSMS once to initialize the database
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
        AddedDate   DATETIME        NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Table Cars created.';
END
GO

-- Bookings Table
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

-- ============================================================
-- Step 3: Seed Default Admin Account
-- Password: Admin@123 (BCrypt hash below is pre-generated)
-- ============================================================
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash, Role)
    VALUES (
        'System Administrator',
        'admin',
        'admin@crms.com',
        '01700000000',
        -- BCrypt hash of 'Admin@123' (cost factor 11)
        '$2a$11$H8PjV1NremXrYocjJuOzfeszzukWfd0DR9/tu9y.Q0CctxyRJDXtG',
        'Admin'
    );
    PRINT 'Default admin account created. Username: admin | Password: Admin@123';
END
GO

-- ============================================================
-- Step 4: Seed Sample Cars for Testing
-- ============================================================
IF NOT EXISTS (SELECT * FROM Cars WHERE PlateNumber = 'DHA-KA-1234')
BEGIN
    INSERT INTO Cars (Brand, Model, Year, Color, PlateNumber, DailyRate, Status)
    VALUES
        ('Toyota',  'Corolla',    2020, 'White',  'DHA-KA-1234', 2500.00, 'Available'),
        ('Honda',   'Civic',      2021, 'Silver', 'DHA-KA-5678', 3000.00, 'Available'),
        ('Nissan',  'X-Trail',    2019, 'Black',  'DHA-KA-9101', 4500.00, 'Available'),
        ('Toyota',  'RAV4',       2022, 'Blue',   'DHA-KA-1121', 5000.00, 'Available'),
        ('Hyundai', 'Tucson',     2021, 'Grey',   'DHA-KA-3141', 4000.00, 'Available'),
        ('Suzuki',  'Swift',      2020, 'Red',    'DHA-KA-5161', 2000.00, 'Maintenance'),
        ('BMW',     '3 Series',   2023, 'White',  'DHA-KA-7181', 8000.00, 'Available'),
        ('Mercedes','C-Class',    2022, 'Black',  'DHA-KA-9202', 9500.00, 'Available');
    PRINT 'Sample cars inserted.';
END
GO

-- ============================================================
-- Step 5: Seed Sample Customer for Testing
-- Password: Customer@123
-- ============================================================
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'john_doe')
BEGIN
    INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash, Role)
    VALUES (
        'John Doe',
        'john_doe',
        'john@example.com',
        '01812345678',
        -- BCrypt hash of 'Customer@123' (cost factor 11)
        '$2a$11$qoO6JW6T.ZmWf.Wf33eUzu/P0Z539ErBRFzajGC.iksGoWR1pyAuq',
        'Customer'
    );
    PRINT 'Sample customer created. Username: john_doe | Password: Customer@123';
END
GO

PRINT '============================================';
PRINT 'CarRentingDB setup complete!';
PRINT 'Admin login  → Username: admin       | Password: Admin@123';
PRINT 'Test user    → Username: john_doe    | Password: Customer@123';
PRINT '============================================';



UPDATE Users SET PasswordHash = '$2a$11$H8PjV1NremXrYocjJuOzfeszzukWfd0DR9/tu9y.Q0CctxyRJDXtG' WHERE Username = 'admin';
UPDATE Users SET PasswordHash = '$2a$11$qoO6JW6T.ZmWf.Wf33eUzu/P0Z539ErBRFzajGC.iksGoWR1pyAuq' WHERE Username = 'john_doe';



-- ============================================================
-- Car Rental Management System - Migration Phase 2
-- ============================================================

USE CarRentingDB;
GO

-- 1. Create Messages Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Messages' AND xtype='U')
BEGIN
    CREATE TABLE Messages (
        MessageID       INT             IDENTITY(1,1)   PRIMARY KEY,
        SenderID        INT             NOT NULL,
        ReceiverID      INT             NOT NULL,
        Subject         NVARCHAR(200)   NOT NULL,
        MessageBody     NVARCHAR(MAX)   NOT NULL,
        SentDate        DATETIME        NOT NULL DEFAULT GETDATE(),
        IsRead          BIT             NOT NULL DEFAULT 0,
        CONSTRAINT FK_Messages_Sender   FOREIGN KEY (SenderID)   REFERENCES Users(UserID),
        CONSTRAINT FK_Messages_Receiver FOREIGN KEY (ReceiverID) REFERENCES Users(UserID)
    );
    PRINT 'Table Messages created.';
END
GO

-- 2. Create GPSLogs Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='GPSLogs' AND xtype='U')
BEGIN
    CREATE TABLE GPSLogs (
        LogID           INT             IDENTITY(1,1)   PRIMARY KEY,
        CarID           INT             NOT NULL,
        Latitude        DECIMAL(9,6)    NOT NULL,
        Longitude       DECIMAL(9,6)    NOT NULL,
        Speed           DECIMAL(5,2)    NOT NULL, -- Speed in km/h
        LogDate         DATETIME        NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_GPSLogs_Cars FOREIGN KEY (CarID) REFERENCES Cars(CarID)
    );
    PRINT 'Table GPSLogs created.';
END
GO

-- 3. Update Role CHECK constraint on Users table
-- First, find the name of the existing check constraint on the Role column
DECLARE @ConstraintName NVARCHAR(200);
SELECT @ConstraintName = name
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('Users')
AND definition LIKE '%Role%';

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE Users DROP CONSTRAINT ' + @ConstraintName);
    PRINT 'Dropped existing Role constraint: ' + @ConstraintName;
END

-- Add the new constraint including 'Manager'
ALTER TABLE Users ADD CONSTRAINT CK_Users_Role CHECK (Role IN ('Admin', 'Customer', 'Manager'));
PRINT 'Added new Role constraint (Admin, Customer, Manager).';
GO

-- 4. Seed default Manager account
-- Password: Manager@123
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'manager')
BEGIN
    INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash, Role)
    VALUES (
        'Branch Manager',
        'manager',
        'manager@crms.com',
        '01900000000',
        -- BCrypt hash of 'Manager@123' (cost factor 11)
        '$2a$11$N9V2YnLpX.9W1R.E.N.O.O.r.U.X.I.P.A.N.D.A.G.U.Y.S.', -- Placeholder hash, will be replaced with real one if needed
        'Manager'
    );
    PRINT 'Default manager account created. Username: manager | Password: Manager@123';
END
GO


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
