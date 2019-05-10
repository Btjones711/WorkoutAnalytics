CREATE TABLE [dbo].[UserPredictionData] (
    [Id]     INT NOT NULL,
    [UserID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPredictionData_ToTable] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserId])
);

