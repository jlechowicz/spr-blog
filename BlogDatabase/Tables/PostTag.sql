CREATE TABLE [dbo].[PostTag]
(
	[PostId] INT NOT NULL, 
    [TagId] INT NOT NULL, 
    PRIMARY KEY ([TagId], [PostId]), 
    CONSTRAINT [FK_PostTag_Post] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id]),
	CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag]([Id]) 
)
