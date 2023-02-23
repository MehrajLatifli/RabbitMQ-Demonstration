Create Database [RabbitMQ_Db]


USE [RabbitMQ_Db]


CREATE TABLE [RabbitMQ_Db].[dbo].[User]
(
[IdUser] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
[Name]  NVARCHAR(max) NOT NULL,
[Surname] NVARCHAR(max) NOT NULL,
[City] NVARCHAR(max) NOT NULL,
[When]  datetime2 DEFAULT GETDATE(),
[PhoneNumber]  NVARCHAR(max) NOT NULL,
)


CREATE TABLE [RabbitMQ_Db].[dbo].[Wallet]
(
[IdWallet] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
[Currency] NVARCHAR(max) NOT NULL,
[Balance] money  NOT NULL,

[UserId_forWallet] int NOT NULL,

Constraint FK_UserId_forWallet Foreign key ([UserId_forWallet]) References [User] ([IdUser]) On Delete NO ACTION On Update NO ACTION
)


CREATE TABLE [RabbitMQ_Db].[dbo].[CartToCart]
(
[IdCartToCart] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
[Amount] money  NOT NULL,

[SenderUserId_forCartToCart] int NOT NULL,
[ReceiverUserId_forCartToCart] int NOT NULL,

Constraint FK_SenderUserId_forCartToCart Foreign key ([SenderUserId_forCartToCart]) References [User] ([IdUser]) On Delete NO ACTION On Update NO ACTION,
Constraint FK_ReceiverUserId_forCartToCart Foreign key ([ReceiverUserId_forCartToCart]) References [User] ([IdUser]) On Delete NO ACTION On Update NO ACTION
)


--------------------

Select *From [RabbitMQ_Db].[dbo].[User]

Select *From [RabbitMQ_Db].[dbo].[Wallet]

Select *From [RabbitMQ_Db].[dbo].[CartToCart]

----------------------------


INSERT INTO [RabbitMQ_Db].[dbo].[User] ([Name], [Surname], [City], [PhoneNumber])
VALUES (N'string', N'string', N'string', N'string'); 

INSERT INTO [RabbitMQ_Db].[dbo].[Wallet] ([Currency], [Balance], [UserId_forWallet])
VALUES (N'string', 100, 2); 

INSERT INTO [RabbitMQ_Db].[dbo].[CartToCart]([Amount], [SenderUserId_forCartToCart], [ReceiverUserId_forCartToCart])
VALUES (10, 1, 2); 

UPDATE [RabbitMQ_Db].[dbo].[Wallet]
SET [RabbitMQ_Db].[dbo].[Wallet].Balance = 10
WHERE  [UserId_forWallet]= 1;


DELETE FROM [RabbitMQ_Db].[dbo].[User]  WHERE [RabbitMQ_Db].[dbo].[User].IdUser=2;

DELETE FROM [RabbitMQ_Db].[dbo].[Wallet]  WHERE [RabbitMQ_Db].[dbo].[Wallet].IdWallet=2;
