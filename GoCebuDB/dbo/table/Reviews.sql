CREATE TABLE [dbo].[Reviews]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Review] NVARCHAR(MAX) NULL, 
	[ProfileLink] NVARCHAR(1000) NULL, 
    [ReviewLink] NVARCHAR(1000) NULL, 
    [ImgFileName] NVARCHAR(50) NULL, 
    [Ratings] INT NULL, 
    [EnabledFlag] BIT NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] DATE NULL
)
