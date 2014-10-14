CREATE TABLE [dbo].[Test3]
(
	[IdTest3] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdTest1] INT NOT NULL, 
    [IdTest2] INT NOT NULL, 
    CONSTRAINT [FK_Test3_To_Test1] FOREIGN KEY ([IdTest1]) REFERENCES Test1([IdTest1])
)

GO

CREATE UNIQUE INDEX [IX_Test3_IdTest1] ON [dbo].[Test3] ([IdTest1])
