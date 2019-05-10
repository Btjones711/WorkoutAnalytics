CREATE TABLE [dbo].[User] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [Gender]   BIT           NOT NULL,
    [Height]   INT           NOT NULL,
    [Weight]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [AK_User_Column] UNIQUE NONCLUSTERED ([UserName] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_User_Weight]
    ON [dbo].[User]
    AFTER UPDATE 
    AS
    BEGIN
        SET NoCount ON;
		IF UPDATE (Weight)
		BEGIN
			INSERT INTO UserWeightHist (UserID,[Weight], WeightDate) VALUES (UserID, [Weight], GETDATE())
		END
    END