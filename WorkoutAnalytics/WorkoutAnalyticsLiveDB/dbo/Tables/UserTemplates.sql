CREATE TABLE [dbo].[UserTemplates] (
    [TemplateID]   INT            IDENTITY (1, 1) NOT NULL,
    [UserID]       INT            NOT NULL,
    [TemplateDesc] NVARCHAR (MAX) NULL,
    [DayOfTheWeek] INT            NOT NULL,
    CONSTRAINT [PK_dbo.UserTemplates] PRIMARY KEY CLUSTERED ([TemplateID] ASC),
    CONSTRAINT [FK_dbo.UserTemplates_dbo.User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[UserTemplates]([UserID] ASC);

