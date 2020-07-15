CREATE TABLE [dbo].[users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] NCHAR(20) NOT NULL, 
    [password] NCHAR(10) NOT NULL
)
