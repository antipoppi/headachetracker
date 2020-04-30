CREATE TABLE [dbo].[HeadacheTriggers]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [AcheID] INT NULL, 
    [TriggerID] INT NULL,

    CONSTRAINT [T_TriggerID] FOREIGN KEY ([TriggerID]) REFERENCES [Triggers]([TriggerID]),
    CONSTRAINT [T_AcheID] FOREIGN KEY ([AcheID]) REFERENCES [Headache]([AcheID])

)
