﻿CREATE TABLE [Workshop].[FileData]
(
	[FileDataId] INT NOT NULL IDENTITY,
	[FileName] VARCHAR(250) NOT NULL,
	[Type] VARCHAR(250) NOT NULL,
	[Extension] VARCHAR(250) NOT NULL,
	[Size] INT NOT NULL,
	[Path] VARCHAR(MAX) NOT NULL,

	CONSTRAINT PK_FileData PRIMARY KEY (FileDataId)
)
