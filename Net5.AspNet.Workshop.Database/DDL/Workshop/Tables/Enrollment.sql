CREATE TABLE [Workshop].[Enrollment]
(
	EnrollmentId INT IDENTITY NOT NULL,
	WorkshopId INT NOT NULL,
	EnrolledPersonId INT NOT NULL,
	EnrollmentDate Date NOT NULL DEFAULT(GETDATE()),
	EnrollmentStateId INT NOT NULL,

	CONSTRAINT PK_Enrollment PRIMARY KEY (EnrollmentId),
	CONSTRAINT FK_EnrollmentWorkshop FOREIGN KEY (WorkshopId) REFERENCES [Workshop].[Workshop](WorkshopId),
	CONSTRAINT FK_EnrollmentEnrolledPerson FOREIGN KEY (EnrolledPersonId) REFERENCES [Workshop].[Person](PersonId),
	CONSTRAINT FK_EnrollmentEnrollmentState FOREIGN KEY (EnrollmentStateId) REFERENCES [Workshop].[EnrollmentState](EnrollmentStateId),
)