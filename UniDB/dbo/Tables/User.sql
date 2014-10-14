CREATE TABLE dbo.[User] (
    [UserId]     INT          IDENTITY (1, 1) NOT NULL,
    [Login]      VARCHAR (20) NOT NULL,
    [UserRoleId] INT          NULL,
    [Password]   VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserRoleId]) REFERENCES [dbo].[UserRole] ([UserRoleId])
);

