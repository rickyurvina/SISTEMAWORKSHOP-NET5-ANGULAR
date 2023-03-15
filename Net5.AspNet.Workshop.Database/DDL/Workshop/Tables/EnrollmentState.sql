CREATE TABLE [WorkShop].[EnrollmentState]
(
	EnrollmentStateId INT IDENTITY NOT NULL,
	[Description] VARCHAR(250) NOT NULL,
	
	CONSTRAINT PK_EnrollmentState PRIMARY KEY (EnrollmentStateId)
)
