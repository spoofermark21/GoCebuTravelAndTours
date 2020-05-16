CREATE TABLE [dbo].[TourBookingAddOns]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourBookingId] INT NOT NULL, 
    [TourPackageAddOnsId] INT NOT NULL, 
    [EnabledFlag] BIT NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL
)
