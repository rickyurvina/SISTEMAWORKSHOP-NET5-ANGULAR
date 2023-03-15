CREATE TABLE [Workshop].[Workshop]
(
	WorkshopId INT IDENTITY NOT NULL,
	Title VARCHAR(250) NOT NULL,
	[Description] VARCHAR(500) NOT NULL,
	CategoryId INT NOT NULL,
	InstructorPersonId INT NOT NULL,
	StartDate DATE NOT NULL,
	StartTime TIME NOT NULL,	
	WorkshopStateId INT NOT NULL,
	CoverFileDataId INT NOT NULL,
	AgendaFileDataId INT NOT NULL,
	
	SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime),

	CONSTRAINT PK_Workshop PRIMARY KEY (WorkshopId),
	CONSTRAINT FK_WorkshopCategory FOREIGN KEY (CategoryId) REFERENCES [Workshop].[Category](CategoryId),
	CONSTRAINT FK_WorkshopInstructorPerson FOREIGN KEY (InstructorPersonId) REFERENCES [Workshop].[Person](PersonId),
	CONSTRAINT FK_WorkshopWorkshopState FOREIGN KEY (WorkshopStateId) REFERENCES [Workshop].[WorkshopState](WorkshopStateId),
	CONSTRAINT FK_WorkshopCoverFileData FOREIGN KEY (CoverFileDataId) REFERENCES [Workshop].[FileData](FileDataId),
	CONSTRAINT FK_WorkshopAgendaFileData FOREIGN KEY (AgendaFileDataId) REFERENCES [Workshop].[FileData](FileDataId),
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Workshop].[WorkshopHistory]));
