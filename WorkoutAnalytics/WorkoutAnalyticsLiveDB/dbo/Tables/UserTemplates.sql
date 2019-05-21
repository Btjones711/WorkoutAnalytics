CREATE TABLE [dbo].[UserTemplates]
(
	[TemplateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [TemplateDesc] VARCHAR(MAX) NOT NULL, 
    [DayOfTheWeek] INT NULL, 
    CONSTRAINT [FK_UserTemplates_ToTable] FOREIGN KEY (UserID) REFERENCES [User](UserID)
)
