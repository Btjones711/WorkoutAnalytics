CREATE TABLE [dbo].[Workouts] (
    [WorkoutID]       INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutDesc]     VARCHAR (50) NOT NULL,
    [WorkoutBodyArea] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkoutID] ASC)
);

