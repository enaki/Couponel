USE [Couponel]
GO

INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('29a7fb75-0bc7-422e-996a-ccdd763be963'
           ,'Romania'
           ,'Bucuresti'
           ,'Piata Romană'
           ,'6')
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('dd33d84b-51e7-49d5-8c83-914f80cff938'
           ,'Romania'
           ,'Timisoara'
           ,'Bulevardul V. Pârvan'
           ,'4')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('05ad0db3-dba9-432c-a1e4-9b95acde901a'
           ,'Romania'
           ,'Iasi'
           ,'General Berthelot'
           ,'16')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('c44c5b59-23eb-4fcb-9bd3-7dba7627949b'
           ,'Romania'
           ,'Bucuresti'
           ,'Academiei'
           ,'14')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('f1910c0a-5d8e-402c-9e86-652d355f07eb'
           ,'Romania'
           ,'Timisoara'
           ,'Bulevardul Vasile Pârvan'
           ,'2')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('da590317-3b53-4ec4-9bcb-7982fb43e801'
           ,'Romania'
           ,'Bucuresti'
           ,'Dionisie Lupu'
           ,'37')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('3785829d-8604-4f13-ad5e-4c84b3d95190'
           ,'Romania'
           ,'Iasi'
           ,'Bulevardul Profesor Dr. doc. Dimitrie Mangeron'
           ,'27')
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('17736749-a379-4757-aaeb-a339557b325b'
           ,'Romania'
           ,'Timsoara'
           ,'Piaţa Eftimie Murgu'
           ,'2')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('8b54a373-7314-4eee-933c-00e119930821'
           ,'Romania'
           ,'Iasi'
           ,'Universității'
           ,'16')
		   
		   
INSERT INTO [dbo].[Addresses]
           ([Id]
           ,[Country]
           ,[City]
           ,[Street]
           ,[Number])
     VALUES
           ('869022ac-f363-4e5e-baa2-261c6971f57d'
           ,'Romania'
           ,'Iasi'
           ,'Dumbrava Roșie'
           ,'35')
		   

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ( '9b43ec3c-6518-4f3f-82ad-0ec37644bbf5'
           ,'Universitatea Tehnica Gheorghe Asachi'
           ,'contact@tuiasi.ro' 
           ,' +40-232-212322'
           ,'3785829D-8604-4F13-AD5E-4C84B3D95190')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
          ( '21c36828-ef02-44f2-b5a7-e3a16250a39e'
           ,'Universitatea de Medicina Grigore T. Popa'
           ,'rectorat@umfiasi.ro' 
           ,' +40.232.301.603'
           ,'8B54A373-7314-4EEE-933C-00E119930821')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
          ( '8d5f24cc-56b5-468c-b797-f84df5a666ab'
           ,'Universitatea Alexandru Ioan Cuza'
           ,'contact@uaic.ro' 
           ,' 0232 20 1000'
           ,'05AD0DB3-DBA9-432C-A1E4-9B95ACDE901A')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
         ( 'a99ec720-cef6-41a3-a5f8-63432d3f76d5'
           ,'Universitatea de Ştiinţe Agricole şi Medicină Veterinară "Ion Ionescu de la Brad"'
           ,'rectorat@uaiasi.ro' 
           ,' 0232 407.407'
           ,'869022AC-F363-4E5E-BAA2-261C6971F57D')
		   
		   
INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('c46f8bc2-05c9-400f-8118-536a8a93699d'
           ,'Universitatea din Bucuresti'
           ,'office@g.unibuc.ro' 
           ,' +4021-313.17.60'
           ,'C44C5B59-23EB-4FCB-9BD3-7DBA7627949B')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('35d19bc6-fee9-41cf-a64f-abb9c8cd891c'
           ,'Academia de Studii Economice din Bucuresti'
           ,'rectorat@ase.ro' 
           ,' +40213191900'
           ,'29A7FB75-0BC7-422E-996A-CCDD763BE963')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('c2c82fda-6221-4a36-9586-5cdf741eb0b4'
           ,'Universitatea de Medicina si Farmacie Carol Davila'
           ,'rectorat@umfcd.ro' 
           ,' +4021 3180719'
           ,'DA590317-3B53-4EC4-9BCB-7982FB43E801')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('535a6e22-d462-497e-b793-3d18a06548e6'
           ,'Universitatea de Vest'
           ,'secretariat@e-uvt.ro' 
           ,' +40-(0)256-592111'
           ,'DD33D84B-51E7-49D5-8C83-914F80CFF938')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('b00cf8cf-c6e9-4438-be39-e97515e6b649'
           ,'Universitatea Politehnica Timisoara'
           ,'rector@upt.ro' 
           ,'0256 - 403021'
           ,'F1910C0A-5D8E-402C-9E86-652D355F07EB')

INSERT INTO [dbo].[Universities]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressId])
     VALUES
           ('f63c98a8-d6a7-44f1-9f8c-c1b7fd93b1c5'
           ,'Universitatea de Medicina si Farmacie Victor Babes'
           ,'rector@umft.ro' 
           ,'+40.0256.204.400'
           ,'17736749-A379-4757-AAEB-A339557B325B')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('939e1d38-5a17-4144-a497-89e3a39303d6'
           ,'Facultatea de Automatica si Calculatoare'
           ,'decanat@ac.tuiasi.ro'
           ,'+40-232-278680'
           ,'9B43EC3C-6518-4F3F-82AD-0EC37644BBF5'
           ,'3785829D-8604-4F13-AD5E-4C84B3D95190')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('23b51624-e181-434d-9b43-17152dc1a9f5'
           ,'Facultatea de Matematică şi Informatică'
           ,'secretariat.mateinfo@e-uvt.ro'
           ,'+40-(0)256-592155'
           ,'535A6E22-D462-497E-B793-3D18A06548E6'
           ,'DD33D84B-51E7-49D5-8C83-914F80CFF938')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('bf470f70-6796-4624-bf46-5215a82ed69c'
           ,'Facultatea de Matematică şi Informatică'
           ,'secretariat@fmi.unibuc.ro'
           ,' +4021–314.28.63'
           ,'C46F8BC2-05C9-400F-8118-536A8A93699D'
           ,'C44C5B59-23EB-4FCB-9BD3-7DBA7627949B')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('1f898fae-2bb9-408d-acd3-190c14db46f4'
           ,'Facultatea de Informatică'
           ,'secretariat@info.uaic.ro'
           ,'+40 232 201090'
           ,'8D5F24CC-56B5-468C-B797-F84DF5A666AB'
           ,'05AD0DB3-DBA9-432C-A1E4-9B95ACDE901A')
		   
		   
INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('d2df3769-a91b-4502-bee3-b0af1b6f4945'
           ,'Facultatea de Medicina'
           ,'decanat.mg@umft.ro'
           ,'0256/220 484'
           ,'F63C98A8-D6A7-44F1-9F8C-C1B7FD93B1C5'
           ,'17736749-A379-4757-AAEB-A339557B325B')


INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('11e55b49-087e-4105-beb6-0b01ce682121'
           ,'Facultatea de Drept'
           ,'ovidiu.dumitru@drept.ase.ro'
           ,'+04 021 319 19 00'
           ,'35D19BC6-FEE9-41CF-A64F-ABB9C8CD891C'
           ,'29A7FB75-0BC7-422E-996A-CCDD763BE963')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('f83f6ab6-9cb4-41b0-8cb0-b567f6b9150b'
           ,'Facultatea de Medicina'
           ,'oana.crasmaru@umfiasi.ro'
           ,'0232 30 16 15'
           ,'21C36828-EF02-44F2-B5A7-E3A16250A39E'
           ,'8B54A373-7314-4EEE-933C-00E119930821')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('6c679218-a79e-4cd2-b26e-562fec7ab4be'
           ,'Facultatea Automatica si calculatoare'
           ,'ac@upt.ro'
           ,'0256 - 403.211'
           ,'B00CF8CF-C6E9-4438-BE39-E97515E6B649'
           ,'F1910C0A-5D8E-402C-9E86-652D355F07EB')

INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('d9bf3497-c5bc-416e-a42e-86184fbaaabf'
           ,'Facultatea de Medicina'
           ,'rectorat@umfcd.ro'
           ,'+4021 3180719'
           ,'C2C82FDA-6221-4A36-9586-5CDF741EB0B4'
           ,'DA590317-3B53-4EC4-9BCB-7982FB43E801')
		   
INSERT INTO [dbo].[Faculties]
           ([Id]
           ,[Name]
           ,[Email]
           ,[PhoneNumber]
           ,[UniversityId]
           ,[AddressId])
     VALUES
           ('2dff3497-c5bc-416e-a42e-86184fbaaabf'
           ,'Facultatea de Agricultura'
           ,'secr_agr@uaiasi.ro'
           ,'0232 407 424'
           ,'A99EC720-CEF6-41A3-A5F8-63432D3F76D5'
           ,'869022AC-F363-4E5E-BAA2-261C6971F57D')
GO


