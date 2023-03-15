CREATE TABLE [Workshop].[Province]
(
	[ProvinceId] INT NOT NULL IDENTITY,
	[Description] VARCHAR(250) NOT NULL,
	[DepartmentId] INT NOT NULL,

	CONSTRAINT PK_Province PRIMARY KEY (ProvinceId),
	CONSTRAINT FK_ProvinceDepartment FOREIGN KEY (DepartmentId) REFERENCES [Workshop].[Department](DepartmentId),	
)
