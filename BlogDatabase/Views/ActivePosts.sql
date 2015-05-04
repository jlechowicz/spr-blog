CREATE VIEW [dbo].[ActivePosts] AS 
	SELECT	[Post].Id as PostId,
			[Post].AuthorId,
			[Post].IsPublic,
			[Post].IsDeleted,
			[Post].CreatedOn,
			[Post].LastModified,
			[PostContent].Id as PostContentId,
			[PostContent].Title,
			[PostContent].Content,
			[PostContent].SavedOn,
			[PostContent].EditedBy,
			[PostContent].IsDisplayed
	FROM [Post]
	INNER JOIN [PostContent] ON [Post].Id = [PostContent].PostId
	WHERE [Post].IsPublic = 1 AND [PostContent].IsDisplayed = 1
