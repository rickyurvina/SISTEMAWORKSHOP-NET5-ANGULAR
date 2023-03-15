CREATE TABLE [Workshop].[Category]
(
	[CategoryId] INT IDENTITY(1,1) NOT NULL,
	[Description] VARCHAR(250) NOT NULL,
	
	CONSTRAINT PK_Category PRIMARY KEY (CategoryId)
)
