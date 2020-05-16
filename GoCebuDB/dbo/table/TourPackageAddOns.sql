CREATE TABLE [dbo].[TourPackageAddOns]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourPackageId] INT NOT NULL, 
    [Name] VARCHAR(100) NOT NULL, 
    [Price] MONEY NULL, 
    [EnabledFlag] BIT NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL
)
