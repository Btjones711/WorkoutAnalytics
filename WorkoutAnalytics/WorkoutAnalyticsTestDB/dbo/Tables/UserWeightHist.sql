CREATE TABLE [dbo].[UserWeightHist] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [UserID]     INT      NOT NULL,
    [Weight]     INT      NOT NULL,
    [WeightDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserWeightHist_ToTable] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserId])
);

