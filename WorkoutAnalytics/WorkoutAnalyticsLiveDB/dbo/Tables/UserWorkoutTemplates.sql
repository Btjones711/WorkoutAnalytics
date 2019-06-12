CREATE TABLE [dbo].[UserWorkoutTemplates] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [TemplateID] INT NOT NULL,
    [WorkoutID]  INT NOT NULL,
    CONSTRAINT [PK_dbo.UserWorkoutTemplates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserWorkoutTemplates_dbo.UserTemplates_TemplateID] FOREIGN KEY ([TemplateID]) REFERENCES [dbo].[UserTemplates] ([TemplateID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.UserWorkoutTemplates_dbo.Workouts_WorkoutID] FOREIGN KEY ([WorkoutID]) REFERENCES [dbo].[Workouts] ([WorkoutID]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_WorkoutID]
    ON [dbo].[UserWorkoutTemplates]([WorkoutID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TemplateID]
    ON [dbo].[UserWorkoutTemplates]([TemplateID] ASC);

