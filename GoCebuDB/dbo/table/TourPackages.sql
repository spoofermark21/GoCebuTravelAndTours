CREATE TABLE [dbo].[TourPackages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourPackageName] NVARCHAR(100) NOT NULL, 
    [TourPackageDescription] NVARCHAR(1000) NULL, 
	[TourItineraryDetails] NVARCHAR(MAX) NULL,
	[AdditionalDetails] NVARCHAR(1000) NULL,
	[InclusionDetails] NVARCHAR(1000) NULL,
    [ImgFileName] NVARCHAR(50) NULL, 
    [TourDurationInHours] INT NULL, 
    [IsSharedFlag] BIT NULL,
	[IsCustomizeFlag] BIT NULL, 
	[BestSellerFlag] BIT NULL, 
	[ForeignPrice] MONEY NULL,
	[ExtendedPaxPrice] MONEY NULL,
    [OrderByDisplay] INT NULL, 
    [EnabledFlag] BIT NULL, 
    [GroupBy] VARCHAR(50) NULL, 
    [CreatedDate] DATE NULL , 
	[CreatedBy] NVARCHAR(50) NULL,
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL
    
)
