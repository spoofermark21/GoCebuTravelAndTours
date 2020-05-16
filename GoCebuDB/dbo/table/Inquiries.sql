CREATE TABLE [dbo].[Inquiries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sender] NVARCHAR(100) NULL, 
	[Name] NVARCHAR(100) NULL, 
    [ContactNumber] NVARCHAR(100) NULL,
    [Message] NVARCHAR(MAX) NULL, 
    [Status] NVARCHAR(50) NULL, 
    [CreatedDate] DATE NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL, 
    [LastUpdatedBy] NVARCHAR(50) NULL, 
    
)
