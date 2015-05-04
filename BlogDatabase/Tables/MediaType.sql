CREATE TABLE [dbo].[MediaType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeName] VARCHAR(50) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
