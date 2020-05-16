CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TourPackageId] INT NOT NULL, 
	[GuestName] VARCHAR(100) NOT NULL,
    [ContactNumber] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(100) NULL, 
	[Address] NVARCHAR(1000) NULL, 
    [FacebookAccount] NVARCHAR(1000) NULL, 
    [BookingStartDate] DATE NULL, 
    [BookingEndDate] DATE NULL, 
    [TotalLocalGuest] INT NULL, 
	[TotalChildGuest] INT NULL,
    [TotalForeignGuest] INT NULL, 
	[DownPaymentAmount]	MONEY NULL,
	[TotalAmount] MONEY NULL,
	[TotalAddOnsAmount] MONEY NULL, 
    [PickUpLocation] NVARCHAR(500) NULL, 
    [DropOffLocation] NVARCHAR(500) NULL, 
    [SpecialRequest] NVARCHAR(1000) NULL, 
	[PaymentDate] DATE NULL, 
	[PaymentStatus] NVARCHAR(50) NULL,
    [BookingStatus] NVARCHAR(50) NULL, 
    [PaymentOptions] NVARCHAR(100) NULL, 
	[IsConfirmed] BIT NULL,
	[CreatedDate] DATE NULL,
	[CreatedBy] NVARCHAR(50) NULL, 
    [LastUpdatedDate] DATE NULL,
    [LastUpdatedBy] NVARCHAR(50) NULL
	
	
    
  
)
