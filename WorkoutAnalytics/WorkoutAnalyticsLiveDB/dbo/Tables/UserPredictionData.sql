CREATE TABLE [dbo].[UserPredictionData]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    CONSTRAINT [FK_UserPredictionData_ToTable] FOREIGN KEY (UserID) REFERENCES [User](UserID)
)
