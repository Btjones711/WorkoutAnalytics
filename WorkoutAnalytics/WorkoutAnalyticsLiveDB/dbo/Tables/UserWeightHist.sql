CREATE TABLE [dbo].[UserWeightHist]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [Weight] INT NOT NULL, 
    [WeightDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_UserWeightHist_ToTable] FOREIGN KEY (UserID) REFERENCES [User]([UserID])
)
