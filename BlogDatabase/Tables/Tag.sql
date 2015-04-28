CREATE TABLE [dbo].[Tag]
(
	[Id] INT NOT NULL  IDENTITY, 
    [TagName] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id]),
	CONSTRAINT [U_TagName] UNIQUE([TagName])
)
