CREATE TABLE [Workshop].[Address]
(
	[AddressId] INT NOT NULL IDENTITY,
	[DepartmentId] INT NOT NULL,
	[ProvinceId] INT NOT NULL,
	[DistrictId] INT NOT NULL,

	CONSTRAINT PK_Address PRIMARY KEY (AddressId),
	CONSTRAINT FK_AddressDepartment FOREIGN KEY (DepartmentId) REFERENCES [Workshop].[Department](DepartmentId),
	CONSTRAINT FK_AddressProvince FOREIGN KEY (ProvinceId) REFERENCES [Workshop].[Province](ProvinceId),
	CONSTRAINT FK_AddressDistrict FOREIGN KEY (DistrictId) REFERENCES [Workshop].[District](DistrictId),
)
