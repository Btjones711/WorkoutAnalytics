CREATE TABLE [dbo].[User] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (MAX) NULL,
    [Password] NVARCHAR (MAX) NULL,
    [Gender]   BIT            NOT NULL,
    [Height]   INT            NOT NULL,
    [Weight]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);



GO
