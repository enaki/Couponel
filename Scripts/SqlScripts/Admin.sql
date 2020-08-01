USE[Couponel]
GO

INSERT INTO [dbo].[Admins]
           ([Id]
           ,[FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[AddressId]
           ,[UserId])
     VALUES
           (CONVERT(uniqueidentifier,'2EECAE0A-7017-472F-B09A-65D2618D7D69')
           ,'Abraham'
           ,'Lincoln' 
           ,'0701234123'
           ,CONVERT(uniqueidentifier,'E7D2CE46-D6AF-4FF8-8FE6-FE5C3ED31DA6')
           ,CONVERT(uniqueidentifier,'1DA65838-E57D-44EB-A93D-7DA8EA37448A'))

GO
