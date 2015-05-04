CREATE TABLE [dbo].[Media]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Path] VARCHAR(1000) NULL, 
    [MediaTypeId] INT NULL, 
    [Name] VARCHAR(50) NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [CreatedOn] DATETIME2 NOT NULL DEFAULT GetDate()
)
