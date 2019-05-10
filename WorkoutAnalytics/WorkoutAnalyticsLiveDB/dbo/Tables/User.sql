CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [Gender] BIT NOT NULL, 
    [Height] INT NOT NULL, 
    [Weight] INT NOT NULL, 
    CONSTRAINT [AK_User_Column] UNIQUE ([UserName])
)

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