CREATE TABLE [dbo].[tags] (
    [Id]    VARCHAR(20)        NOT NULL,
    [tag] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC, [tag] ASC),
    CONSTRAINT [FK_tags_users] FOREIGN KEY ([Id]) REFERENCES [dbo].[users] ([Id])
);

