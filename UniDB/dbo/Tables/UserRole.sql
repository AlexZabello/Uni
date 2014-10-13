CREATE TABLE [dbo].[UserRole] (
    [UserRoleId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
);

