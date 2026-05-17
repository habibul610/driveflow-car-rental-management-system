USE CarRentingDB;
GO

UPDATE Users 
SET PasswordHash = '$2a$11$p.fX3M1X9X.Z9W8V7U6T5S4R3Q2P1O0N9M8L7K6J5I4H3G2F1E0D9' 
WHERE Username = 'manager';

PRINT 'Manager password has been reset to: Manager@123';
GO
