CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuthorId] INT NOT NULL, 
	[IsPublic] BIT NOT NULL DEFAULT 0,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [CreatedOn] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [LastModified] DATETIME2 NULL,
	CONSTRAINT [FK_Post_User] FOREIGN KEY ([AuthorId]) REFERENCES [User]([Id])
)
