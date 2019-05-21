CREATE TABLE [dbo].[UserWorkoutTemplates] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [TemplateID] INT NOT NULL,
    [WorkoutID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserWorkoutTemplates_ToTemplate] FOREIGN KEY ([TemplateID]) REFERENCES [dbo].[UserTemplates] ([TemplateID]),
    CONSTRAINT [FK_UserWorkoutTemplates_ToWorkOuts] FOREIGN KEY ([WorkoutID]) REFERENCES [dbo].[Workouts] ([WorkoutID])
);

