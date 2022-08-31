CREATE TABLE [dbo].[user]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [email] NVARCHAR(MAX) NOT NULL, 
    [password] NVARCHAR(MAX) NOT NULL, 
    [active] BIT NOT NULL
)
