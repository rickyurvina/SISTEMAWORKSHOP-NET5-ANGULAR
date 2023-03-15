CREATE TABLE [Workshop].[Person]
(
	[PersonId] INT NOT NULL IDENTITY,
	Title VARCHAR(250) NOT NULL,
	FirstName VARCHAR(250) NOT NULL,
	LastName VARCHAR(250) NOT NULL,
	SurName VARCHAR(250) NOT NULL,
	IdentificationNumber VARCHAR(250) NOT NULL,
	Phone VARCHAR(250) NOT NULL,
	AddressId INT NOT NULL,	

	CONSTRAINT PK_Person PRIMARY KEY (PersonId),
	CONSTRAINT FK_PersonAddress FOREIGN KEY (AddressId) REFERENCES [Workshop].[Address](AddressId),	
)
