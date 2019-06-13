CREATE TABLE [dbo].[UserWeightHist] (
    [UserID]     INT      NOT NULL,
    [WeightDate] DATETIME NOT NULL,
    [UserWeight] INT      NOT NULL,
    CONSTRAINT [PK_dbo.UserWeightHist] PRIMARY KEY CLUSTERED ([UserID] ASC, [WeightDate] ASC),
    CONSTRAINT [FK_dbo.UserWeightHist_dbo.User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[UserWeightHist]([UserID] ASC);

