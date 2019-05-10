CREATE TABLE [dbo].[UserWorkouts]
(
	[WorkoutId] INT NOT NULL , 
    [UserId] INT NOT NULL, 
    [WeightLifted] INT NULL, 
    [TimeOfWorkout] TIME NULL, 
    [Distance] INT NULL, 
    [DistanceUnits] BIT NULL, 
    [WeightUnits] BIT NULL, 
    [SentimentID] INT NULL, 
    [WorkoutDate] DATETIME NULL, 
    [UserWorkoutID] INT NOT NULL IDENTITY, 
    CONSTRAINT [FK_UserWorkouts_ToTable] FOREIGN KEY (UserID) REFERENCES [User]([UserID]), 
    PRIMARY KEY ([UserWorkoutID])
)
