CREATE TABLE [dbo].[Workouts]
(
	[WorkoutID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [WorkoutDesc] VARCHAR(50) NOT NULL, 
    [WorkoutBodyArea] VARCHAR(50) NOT NULL
)
