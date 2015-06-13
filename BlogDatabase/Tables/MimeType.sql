CREATE TABLE [dbo].[MimeType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Definition] VARCHAR(250) NOT NULL,
	[AssociatedFileExtensions] VARCHAR(MAX) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [U_MimeType_Definition] UNIQUE([Definition])
)