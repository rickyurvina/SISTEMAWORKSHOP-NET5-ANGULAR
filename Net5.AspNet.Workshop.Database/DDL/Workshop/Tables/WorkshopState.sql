CREATE TABLE [Workshop].[WorkshopState]
(
	WorkshopStateId INT IDENTITY NOT NULL,
	[Description] VARCHAR(250) NOT NULL,
	
	CONSTRAINT PK_WorkshopState PRIMARY KEY (WorkshopStateId)
)
