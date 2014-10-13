CREATE TABLE [dbo].[Group] (
    [GroupId]   INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (20) NOT NULL,
    [SubjectId] INT          NOT NULL,
    [TeacherId] INT          NOT NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([GroupId] ASC),
    CONSTRAINT [FK_Group_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
    CONSTRAINT [FK_Group_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([TeacherId])
);

