CREATE TABLE [dbo].[UserWorkouts] (
    [UserWorkoutID] INT      IDENTITY (1, 1) NOT NULL,
    [WorkoutID]     INT      NOT NULL,
    [UserID]        INT      NOT NULL,
    [WeightLifted]  INT      NOT NULL,
    [TimeOfWorkout] INT      NOT NULL,
    [Distance]      INT      NOT NULL,
    [DistanceUnits] INT      NOT NULL,
    [WeightUnits]   INT      NOT NULL,
    [SentimentID]   INT      NULL,
    [WorkoutDate]   DATETIME NOT NULL,
    [Reps]          INT      NOT NULL,
    CONSTRAINT [PK_dbo.UserWorkouts] PRIMARY KEY CLUSTERED ([UserWorkoutID] ASC),
    CONSTRAINT [FK_dbo.UserWorkouts_dbo.User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.UserWorkouts_dbo.Workouts_WorkoutID] FOREIGN KEY ([WorkoutID]) REFERENCES [dbo].[Workouts] ([WorkoutID]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_WorkoutID]
    ON [dbo].[UserWorkouts]([WorkoutID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[UserWorkouts]([UserID] ASC);

