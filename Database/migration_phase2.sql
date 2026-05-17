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
