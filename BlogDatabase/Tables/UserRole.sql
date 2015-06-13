CREATE TABLE [dbo].[UserRole]
(
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL,
	PRIMARY KEY ([UserId], [RoleId]),
	CONSTRAINT [FK_User_UserRole] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Role_UserRole] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)
