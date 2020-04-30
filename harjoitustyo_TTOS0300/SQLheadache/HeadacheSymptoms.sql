CREATE TABLE [dbo].[HeadacheSymptoms]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [AcheID] INT NULL, 
    [SymptomID] INT NULL,

    CONSTRAINT [S_SymptomID] FOREIGN KEY ([SymptomID]) REFERENCES [Symptoms]([SymptomID]),
    CONSTRAINT [S_AcheID] FOREIGN KEY ([AcheID]) REFERENCES [Headache]([AcheID])
)
