CREATE TABLE [dbo].[PaymentTransaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookingId] INT NOT NULL, 
    [PaymentAmount] INT NULL, 
    [PaymentType] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL
)
