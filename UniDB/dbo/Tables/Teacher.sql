CREATE TABLE [dbo].[Teacher] (
    [TeacherId] INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [SubjectId] INT          NOT NULL,
    [UserId]    INT          NOT NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED ([TeacherId] ASC),
    CONSTRAINT [FK_Teacher_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
    CONSTRAINT [FK_Teacher_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

