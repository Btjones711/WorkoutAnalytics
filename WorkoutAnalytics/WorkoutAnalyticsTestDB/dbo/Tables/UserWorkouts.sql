CREATE TABLE [dbo].[UserWorkouts] (
    [WorkoutId]     INT      NOT NULL,
    [UserId]        INT      NOT NULL,
    [WeightLifted]  INT      NULL,
    [TimeOfWorkout] TIME (7) NULL,
    [Distance]      INT      NULL,
    [DistanceUnits] BIT      NULL,
    [WeightUnits]   BIT      NULL,
    [SentimentID]   INT      NULL,
    [WorkoutDate]   DATETIME NULL,
    [UserWorkoutID] INT      IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserWorkoutID] ASC),
    CONSTRAINT [FK_UserWorkouts_ToTable] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

