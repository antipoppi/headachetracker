CREATE TABLE [dbo].[HeadacheReliefs]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AcheID] INT NULL, 
    [ReliefID] INT NULL,
    CONSTRAINT [R_TriggerID] FOREIGN KEY ([ReliefID]) REFERENCES [Reliefs]([ReliefID]),
    CONSTRAINT [R_AcheID] FOREIGN KEY ([AcheID]) REFERENCES [Headache]([AcheID])
)
