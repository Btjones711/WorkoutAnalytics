CREATE TABLE [dbo].[UserWorkoutTemplates]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TemplateID] INT NOT NULL, 
    [WorkoutID] INT NOT NULL, 
    CONSTRAINT [FK_UserWorkoutTemplates_ToTemplate] FOREIGN KEY (TemplateID) REFERENCES UserTemplates(TemplateID), 
    CONSTRAINT [FK_UserWorkoutTemplates_ToWorkOuts] FOREIGN KEY (WorkoutID) REFERENCES Workouts(WorkoutID)
)
