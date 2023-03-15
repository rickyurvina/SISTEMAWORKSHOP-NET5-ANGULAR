CREATE TABLE [Workshop].[Department]
(
	[DepartmentId] INT NOT NULL IDENTITY,
	[Description] VARCHAR(256) NOT NULL,

	CONSTRAINT PK_Department PRIMARY KEY (DepartmentId)
)
