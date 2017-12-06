-- Ads for banner
CREATE TABLE [dbo].[Advertisement]
(
    [AdvertisementId] INT NOT NULL PRIMARY KEY Identity(1, 1),
    [Title] NVarChar(50) Not Null,
	[Description] NVarChar(200) Null,
	[Picture] VARBINARY(MAX),
	[PictureMimeType] VARCHAR(50)
)
Go