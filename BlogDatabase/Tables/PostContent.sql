﻿CREATE TABLE [dbo].[PostContent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PostId] INT NOT NULL, 
    [Title] VARCHAR(50) NOT NULL DEFAULT '(Untitled)', 
    [Content] TEXT NULL, 
    [SavedOn] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [IsDisplayed] BIT NOT NULL DEFAULT 0, 
    [EditedBy] INT NOT NULL,
	CONSTRAINT [FK_PostContent_Post] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id]) 
)
