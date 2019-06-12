CREATE TABLE [dbo].[Workouts] (
    [WorkoutID]       INT            IDENTITY (1, 1) NOT NULL,
    [WorkoutDesc]     NVARCHAR (MAX) NULL,
    [WorkoutBodyArea] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Workouts] PRIMARY KEY CLUSTERED ([WorkoutID] ASC)
);


