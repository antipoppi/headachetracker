CREATE TABLE [dbo].[Headache]
(
	[AcheID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NULL, 
    [AcheTypeID] INT NULL, 
    [PainLevel] INT NULL, 
    [MedicationID] INT NULL, 
    [AcheSymptomsID] INT NULL, 
    [AcheReliefsID] INT NULL, 
    [AcheTriggersID] INT NULL, 
    [Notes] TEXT NULL, 
    [Date] DATE NOT NULL,

    CONSTRAINT [UserID] FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]),
    CONSTRAINT [AcheTypeID] FOREIGN KEY ([AcheTypeID]) REFERENCES [AcheType]([AcheTypeID]),
    CONSTRAINT [MedicationID] FOREIGN KEY ([MedicationID]) REFERENCES [Medications]([MedicationID]),
    CONSTRAINT [AcheSymptomsID] FOREIGN KEY ([AcheSymptomsID]) REFERENCES [HeadacheSymptoms]([ID]),
    CONSTRAINT [AcheReliefsID] FOREIGN KEY ([AcheReliefsID]) REFERENCES [HeadacheReliefs]([ID]),
    CONSTRAINT [AcheTriggersID] FOREIGN KEY ([AcheTriggersID]) REFERENCES [HeadacheTriggers]([ID]),

)
