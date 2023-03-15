CREATE TABLE [Workshop].[District]
(
	[DistrictId] INT NOT NULL IDENTITY,
	[Description] VARCHAR(250) NOT NULL,
	ProvinceId INT NOT NULL,
		
	CONSTRAINT PK_District PRIMARY KEY (DistrictId),
	CONSTRAINT FK_DistrictProvince FOREIGN KEY (ProvinceId) REFERENCES [Workshop].[Province](ProvinceId),
)
