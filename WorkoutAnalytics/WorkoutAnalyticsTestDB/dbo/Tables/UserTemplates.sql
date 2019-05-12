CREATE TABLE [dbo].[UserTemplates] (
    [TemplateID]   INT           IDENTITY (1, 1) NOT NULL,
    [UserID]       INT           NOT NULL,
    [TemplateDesc] VARCHAR (MAX) NOT NULL,
    [DayOfTheWeek] INT           NULL,
    PRIMARY KEY CLUSTERED ([TemplateID] ASC),
    CONSTRAINT [FK_UserTemplates_ToTable] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserId])
);

