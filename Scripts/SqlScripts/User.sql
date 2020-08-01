USE[Couponel]
GO

INSERT INTO [dbo].[Users]
           ([Id]
           ,[UserName]
           ,[Email]
           ,[PasswordHash]
           ,[Role])
     VALUES
           (CONVERT(uniqueidentifier,'1DA65838-E57D-44EB-A93D-7DA8EA37448A')
           ,'admin'
           ,'iamgod@gmail.com'
           ,'9pNA5D4UGeZ8RkCuQkidNQ==.HRe22A0jC+dbE0AEOZb1+fSZ/cjlYafkmh7mNJfqgSU='
           ,'admin')

GO
