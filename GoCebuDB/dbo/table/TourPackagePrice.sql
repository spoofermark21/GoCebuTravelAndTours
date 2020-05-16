CREATE TABLE [dbo].[TourPackagePrice]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourPackageId] INT NOT NULL, 
    [Pax] INT NULL, 
    [Amount] MONEY NULL, 
    [GuestType] NVARCHAR(50) NULL, 
    [MaxFlag] BIT NULL, 
	[EnabledFlag] BIT NULL,
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL,
    
)
