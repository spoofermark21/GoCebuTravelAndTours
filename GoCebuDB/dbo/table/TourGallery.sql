CREATE TABLE [dbo].[TourGallery]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourPackageId] INT NOT NULL, 
    [ImgFileName] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(1000) NULL ,
	 [EnabledFlag] BIT NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL
)
